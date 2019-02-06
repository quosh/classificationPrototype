using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ClassificationData
{
	class ClassDataProducerV3
	{
		public string outputJson { get { return _outputJson; } set { _outputJson = value; } }
		public string displayJason { get { return _displayJason; } set { _displayJason = value; } }
		public string inputXml { get { return _inputXml; } set { _inputXml = value; } }

		public int classesProcessedCount { get { return _classesProcessedCount; } set { _classesProcessedCount = value; } }
		public int classesAddedToListCount { get { return _classesAddedToListCount; } set { _classesAddedToListCount = value; } }
		public int drugsProcessedCount { get { return _drugsProcessedCount; } set { _drugsProcessedCount = value; } }
		public int drugsAddedToListCount { get { return _drugsAddedToListCount; } set { _drugsAddedToListCount = value; } }




		string _outputJson;
		string _displayJason;
		string _inputXml;

		int _classesProcessedCount;
		int _classesAddedToListCount;
		int _drugsProcessedCount;
		int _drugsAddedToListCount;

		internal XDocument hierarchyXDoc { get; set; }
		internal List<DrugClass> DrugClassData { get; set; }

		public ClassDataProducerV3()
		{
			_outputJson = "";
			_inputXml = "";

			_classesProcessedCount = 0;
			_classesAddedToListCount = 0;

			_drugsProcessedCount = 0;
			_drugsAddedToListCount = 0;

			DrugClassData = new List<DrugClass>();
		}

		internal void processDrugs()
		{
			try
			{
				hierarchyXDoc = XDocument.Parse(_inputXml);

				var drugsonly = hierarchyXDoc.Descendants("drug");

				foreach (XElement node in drugsonly)
				{
					processDrug(node);
					_drugsProcessedCount++;
				}

				PublishOutput();
			}
			catch (XmlException)
			{
				MessageBox.Show("There was an error trying to derive the class data");
			}

		}



		//get "primary" classification id and name
		private void processDrug(XElement drug)
		{
			string drugId = drug.Element("id").Value;
			string drugName = drug.Element("title").Value;

			XElement primClassification;
			
			string _classId = "";
			string _className = "";

			var classifications = drug.Descendants("classifications");

			//classifications
			foreach (var topClass in classifications)
			{
				//primary and secondary
				if (topClass.HasAttributes)
				{
					//classification elements
					foreach(var lowClass in topClass.Elements())
					{ 
						var classes = lowClass.Descendants("classifications");
						var dCount = classes.Count();

						if (dCount == 0)
						{
							_classId = lowClass.Element("id").Value;
							_className = lowClass.Element("title").Value;
						}
						else
						{
							//The bottom classification
							var nth = classes.ElementAt(dCount - 1);
							primClassification = nth.Element("classification");
							_classId = primClassification.Element("id").Value;
							_className = primClassification.Element("title").Value;
						}

						//Add classification to list
						AddClassification(_classId, _className);

						//Add drug to list
						AddDrug(_classId, drugName, drugId);

						_classesProcessedCount++;

					}
					
				}
			}

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

				_classesAddedToListCount++;
			}
		}

		private void AddDrug(string classId, string drugname, string drugId)
		{
			DrugInfoSubClass drug = new DrugInfoSubClass();
			drug.Name = drugname;
			drug.Sid = drugId;

			var indx = DrugClassData.FindIndex(x => x.Id == classId);

			DrugClassData[indx].Drug.Add(drug);

			_drugsAddedToListCount++;
		}

		private void PublishOutput()
		{
			_outputJson = JsonConvert.SerializeObject(DrugClassData);
			_displayJason = JsonConvert.SerializeObject(DrugClassData, Newtonsoft.Json.Formatting.Indented);

			//Make atomic
			_outputJson = _outputJson.TrimStart('[');
			_outputJson = _outputJson.TrimEnd(']');
			_outputJson = _outputJson.Replace("]},", "]}");
			System.IO.File.WriteAllText(@"C:\00 Customer First Projects\07 Drug Classes\05 Testing\outputs\output_v3.json", _outputJson);
		}

	}
}
