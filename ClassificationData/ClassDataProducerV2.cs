﻿using System.IO;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ClassificationData
{
	public class ClassDataProducerV2
	{
		public string outputJson { get { return _outputJson; } set { _outputJson = value; } }
		public string inputXml { get { return _inputXml; } set { _inputXml = value; } }
		public int classCount { get { return _classCount; } set { _classCount = value; } }
		public int drugCount { get { return _drugCount; } set { _drugCount = value; } }
		public int drugsAdded { get { return _drugsAdded; } set { _drugsAdded = value; } }

		string _outputJson;
		string _inputXml;
		int _classCount;
		int _drugCount;
		int _drugsAdded;
		internal XDocument hierarchyXDoc { get; set; }
		internal List<DrugClass> DrugClassData { get; set; }

		public ClassDataProducerV2()
		{
			_outputJson = "";
			_inputXml = "";
			_classCount = 0;
			_drugCount = 0;

			DrugClassData = new List<DrugClass>();
		}

		//Collection<DrugClass> classes = new Collection<DrugClass>();

		internal void processDrugs()
		{
			try
			{

				//get hierarchy file into XDocument
				hierarchyXDoc = XDocument.Parse(_inputXml);

				//populate the class data from each drug
				var drugsonly = hierarchyXDoc.Descendants("drug");
				MessageBox.Show(drugsonly.Count().ToString());
				
				foreach (XElement node in drugsonly)
				{
					ProcessTopLevelClassifications(node);
					_drugCount++;
				}

				PublishOutput();

			}
			catch (XmlException)
			{
				MessageBox.Show("There was an error trying to derive the class data");
			}

		}

		//Get the Primary and Secondary Classification Elements and send to ProcessClassification(XElement Classification)
		private void ProcessTopLevelClassifications(XElement drug)
		{
			//Get drug data
			var _drugname = drug.Element("title").Value;
			var _drugId = drug.Element("id").Value;

			var classifications = drug.Descendants("classifications");

			foreach (var topClass in classifications)
			{
				//if ((cct.Attribute("type").Value == "primary") || (cct.Attribute("type").Value == "secondary"))
				if (topClass.HasAttributes)
				{
					ProcessLowestLevelClassDefinition(_drugname, _drugId, topClass);
				}
			}
		}

		private void ProcessLowestLevelClassDefinition(string drugName, string drugId, XElement topClass)
		{
			//if (topClass.Descendants("classifications").Count() > 0)
			//{

				//Upto 3 levels within each primary/secondary classification
				var classifications = topClass.Descendants("classifications");
				var dCount = classifications.Count();

				if (dCount == 0)
				{
					var primNode = topClass.Element("classification");
					var _classId = primNode.Element("id").Value;
					var _className = primNode.Element("title").Value;

					//Add classification to list
					AddClassification(_classId, _className);

					//Add drug to list
					AddDrug(_classId, drugName, drugId);
				}
				else
				{
					var nth = classifications.ElementAt(dCount - 1);

					//The bottom classification
					var classification = nth.Element("classification");
					var _classId = classification.Element("id").Value;
					var _className = classification.Element("title").Value;

					//Add classification to list
					AddClassification(_classId, _className);

					//Add drug to list
					AddDrug(_classId, drugName, drugId);

				}

			//}
		}

		private void AddClassification(string classId, string className)
		{
			if (!DrugClassData.Any(x => x.Id == classId))
			{
				DrugClass drugClass = new DrugClass();
				drugClass.Drug = new Collection<DrugInfoSubClass>();

				drugClass.Id = classId;
				drugClass.Name = className;

				DrugClassData.Add(drugClass);
				_classCount++;
			}
		}

		private void AddDrug(string classId, string drugname, string drugId)
		{
			DrugInfoSubClass drug = new DrugInfoSubClass();
			drug.Name = drugname;
			drug.Sid = drugId;

			var indx = DrugClassData.FindIndex(x => x.Id == classId);

			DrugClassData[indx].Drug.Add(drug);

			_drugsAdded++;
		}

		private void PublishOutput()
		{
			_outputJson = JsonConvert.SerializeObject(DrugClassData);
			//Make atomic
			_outputJson = _outputJson.TrimStart('[');
			_outputJson = _outputJson.TrimEnd(']');
			_outputJson = _outputJson.Replace("]},", "]}");
			System.IO.File.WriteAllText(@"C:\00 Customer First Projects\07 Drug Classes\05 Testing\outputs\output_v2.json", _outputJson);
		}
	}
}
