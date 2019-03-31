using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp3
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 
	
	public class StringTable
	{
		public string[] ColumnNames { get; set; }
		public string[,] Values { get; set; }
	}

	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{

			var client = new MongoClient("mongodb://riso:riso@cluster0-shard-00-00-sqk5m.mongodb.net:27017,cluster0-shard-00-01-sqk5m.mongodb.net:27017,cluster0-shard-00-02-sqk5m.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true");
			
			var database = client.GetDatabase("hackkosice");
			var collection = database.GetCollection<BsonDocument>("appointment");

			/*var document = new BsonDocument
			{
				{ "name", "Zlatica Puskarova" },
				{ "password", "456" }
			};
			
			collection.InsertOne(document);*/
			
			var time = DateTime.Now.ToString("dd MMMM yyyy");

			var filter = Builders<BsonDocument>.Filter.Eq("date", "31 March 2019");
		
			var result = collection.Find(filter).ToList();

			foreach (var doc in result)
			{
				var data = JObject.Parse(doc.ToJson().Replace("ObjectId(", " ").Replace(")", " "));
				string patId = data["patientId"].ToString();
				var collection_new = database.GetCollection<BsonDocument>("patient");
				var filter_new = Builders<BsonDocument>.Filter.Eq("_id", patId);
				var result_new = collection_new.Find(filter_new).ToList();

				foreach(var d in result_new)
				{
					//var data_new = JObject.Parse(d.ToJson().Replace("ObjectId(", " ").Replace(")", " "));

					string[,] str = { { d["_id"].ToString(), d["Gender"].ToString(), d["ScheduledDay"].ToString(), d["Age"].ToString(), d["Neighbourhood"].ToString(), d["Scholarship"].ToString(), d["Hipertension"].ToString(), d["Diabetes"].ToString(), d["Alcoholism"].ToString(), d["Handcap"].ToString(), d["SMS_received"].ToString(), d["No-show"].ToString() }, { "0", "0", "", "0", "value", "0", "0", "0", "0", "0", "0", "0" }, };
					InvokeRequestResponseService(str);
				}
				
			}

		}
		
		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			//InvokeRequestResponseService();

		}

		static async void InvokeRequestResponseService(string[,] qqq)
		{
			using (var client = new HttpClient())
			{
				var scoreRequest = new
				{

					Inputs = new Dictionary<string, StringTable>() {
						{
							"input1",
							new StringTable()
							{
								ColumnNames = new string[] {"PatientId", "Gender", "ScheduledDay", "Age", "Neighbourhood", "Scholarship", "Hipertension", "Diabetes", "Alcoholism", "Handcap", "SMS_received", "No-show"},
								//Values = new string[,] {  { "0", "1", "", "1", "", "1", "1", "1", "1", "1", "0", "0" },  { "0", "0", "", "0", "value", "0", "0", "0", "0", "0", "0", "0" },  }
								Values = qqq,
							}
						},
					},
					GlobalParameters = new Dictionary<string, string>()
					{
					}
				};
				const string apiKey = "3frn40WM5kp2QHiWk10nzk6qhFrOVnkIVKkz29uZzXJdRQkZzWQla6QJ19i1fZd4QuqcJj1apZPe+efNc/JO2A=="; // Replace this with the API key for the web service
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

				client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/f9655f0d69d24a5887e46b2eafaaf857/services/0fef472adf6a4ffcba3755325e251a6b/execute?api-version=2.0&details=true");

				// WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
				// One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
				// For instance, replace code such as:
				//      result = await DoSomeTask()
				// with the following:
				//      result = await DoSomeTask().ConfigureAwait(false)


				HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Result: {0}", result);
					//var score = result["Scored Probabilities"];
					var data = (JObject)JsonConvert.DeserializeObject<JObject>(result);

					
					
				}
				else
				{
					Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

					// Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
					Console.WriteLine(response.Headers.ToString());

					string responseContent = await response.Content.ReadAsStringAsync();
					Console.WriteLine(responseContent);
				}
			}
		}

		private void Vypis_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{

		}
	}
}
