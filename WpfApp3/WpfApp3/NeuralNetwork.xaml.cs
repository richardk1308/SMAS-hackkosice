using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp3
{
	/// <summary>
	/// Interaction logic for NeuralNetwork.xaml
	/// </summary>
	public partial class NeuralNetwork : Window
	{
		public NeuralNetwork()
		{
			InitializeComponent();

		}
		
		static async void InvokeRequestResponseService()
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
								Values = new string[,] {  { "0", "1", "", "1", "", "1", "1", "1", "1", "1", "0", "0" },  { "0", "0", "", "0", "value", "0", "0", "0", "0", "0", "0", "0" },  }
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
					string result = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Result: {0}", result);
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

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			InvokeRequestResponseService();

		}
	}
}
