using System;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ClassificationData
{
		internal class DrugClass
		{
			[JsonProperty("name")]
			internal String Name { get; set; }
			[JsonProperty("id")]
			internal String Id { get; set; }
			[JsonProperty("drug")]
			internal Collection<DrugInfoSubClass> Drug { get; set; }
		}

		internal class DrugInfoSubClass
		{
			[JsonProperty("name")]
			internal String Name { get; set; }
			[JsonProperty("sid")]
			internal String Sid { get; set; }
		}

}
