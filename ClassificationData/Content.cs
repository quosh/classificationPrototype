using System;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ClassificationData
{
		internal class DrugClassification
		{
			[JsonProperty("name")]
			internal String Name { get; set; }
			[JsonProperty("id")]
			internal String Id { get; set; }
			[JsonProperty("drug")]
			internal Collection<DrugSubClass> Drug { get; set; }
		}

		internal class DrugSubClass
		{
			[JsonProperty("name")]
			internal String Name { get; set; }
			[JsonProperty("sid")]
			internal String Sid { get; set; }
		}

}
