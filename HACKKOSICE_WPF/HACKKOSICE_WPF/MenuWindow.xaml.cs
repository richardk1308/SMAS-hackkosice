using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace HACKKOSICE_WPF
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    ///  public class StringTable
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }

    }

    public partial class MenuWindow : Window
    {
        private string __date;
        private string ___date;
        private string _id;
        private DataTable dt;
        private int valuesCount = 0;
        public List<string> listofvalues = new List<string>();

        

        public MenuWindow(string id)
        {
            InitializeComponent();
            dt = new DataTable();
            IDNurse.Content += id;
            _id = id;
            dt.Columns.Add("PatientID", typeof(string));
            dt.Columns.Add("Reason", typeof(string));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Start", typeof(string));
            dt.Columns.Add("Estimated End", typeof(string));
            dt.Columns.Add("NurseID", typeof(string));
            dt.Columns.Add("ScoreProbabilities", typeof(string));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MakeAnAppointmentGrid.Visibility = Visibility.Visible;
            AppointmentGrid.Visibility = Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AppointmentGrid.Visibility = Visibility.Visible;
            MakeAnAppointmentGrid.Visibility = Visibility.Hidden;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AppointmentDbs appointmentDbs = new AppointmentDbs();
            bool state = appointmentDbs.Appoint(id.Text, reason.Text, datePicker.Text.ToString(), start.Text, end.Text, _id);
            if (state)
            {
                status.Content = "Appointed";
                status.Foreground = Brushes.Green;
            }
            else
            {
                status.Content = "Appointed failed";
                status.Foreground = Brushes.Red;
            }

        }

        

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("PatientID", typeof(string));
            dt.Columns.Add("Reason", typeof(string));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Start", typeof(string));
            dt.Columns.Add("Estimated End", typeof(string));
            dt.Columns.Add("NurseID", typeof(string));
            dt.Columns.Add("ScoreProbabilities", typeof(string));
            dataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            var client = new MongoClient("mongodb://tomasj:tomas123@cluster0-shard-00-00-sqk5m.mongodb.net:27017,cluster0-shard-00-01-sqk5m.mongodb.net:27017,cluster0-shard-00-02-sqk5m.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true");
            var database = client.GetDatabase("hackkosice");
            
            var collection = database.GetCollection<BsonDocument>("appointment");
            string time = calendar.SelectedDate.Value.ToString("d MMMM yyyy");
            var filter = Builders<BsonDocument>.Filter.Eq("date", calendar.SelectedDate.Value.ToString("d MMMM yyyy"));
            var result = collection.Find(filter).ToList();
            if (result.Count > 0)
            {
                List<string> listofvalues = new List<string>();
                string _time = time;

                int asfa = listofvalues.Count;
                int helpNum = 0;

                foreach (var doc in result)
                {
                    var data = JObject.Parse(doc.ToJson().Replace("ObjectId(", " ").Replace(")", " "));
                    string patId = data["patientId"].ToString();
                    var collection_new = database.GetCollection<BsonDocument>("patient");
                    var filter_new = Builders<BsonDocument>.Filter.Eq("_id", patId);
                    var result_new = collection_new.Find(filter_new).ToList();

                    foreach (var d in result_new)
                    {
                        //var data_new = JObject.Parse(d.ToJson().Replace("ObjectId(", " ").Replace(")", " "));

                        string[,] str = { { d["_id"].ToString(), d["Gender"].ToString(), d["ScheduledDay"].ToString(), d["Age"].ToString(), d["Neighbourhood"].ToString(), d["Scholarship"].ToString(), d["Hipertension"].ToString(), d["Diabetes"].ToString(), d["Alcoholism"].ToString(), d["Handcap"].ToString(), d["SMS_received"].ToString(), d["No-show"].ToString() }, { "0", "0", "", "0", "value", "0", "0", "0", "0", "0", "0", "0" }, };
                        bool here = true;
                        Console.Write(here);
                        InvokeRequestResponseService(str, data["patientId"].ToString(), data["reason"].ToString(), data["date"].ToString(), data["start"].ToString(), data["end"].ToString(), data["nurseId"].ToString());
                    }

                }
            }
            dataGrid.ItemsSource = dt.DefaultView;
        }

        

        async void InvokeRequestResponseService(string[,] qqq, string patientid, string reason, string date, string start, string end, string nurseid)
        {
            using (var client = new HttpClient())
            {
                List<string> listofvalues = new List<string>();
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
                    string _replace = "{" + '"' + "Results" + '"' + ":{" + '"' + "output1" + '"' + ":{" + '"' + "type" + '"' + ":" + '"' + "table" + '"' + "," + '"' + "value" + '"' + ":{" + '"' + "ColumnNames" + '"' + ":[" + '"' + "PatientId" + '"' + "," + '"' + "Gender" + '"' + "," + '"' + "ScheduledDay" + '"' + "," + '"' + "Age" + '"' + "," + '"' + "Neighbourhood" + '"' + "," + '"' + "Scholarship" + '"' + "," + '"' + "Hipertension" + '"' + "," + '"' + "Diabetes" + '"' + "," + '"' + "Alcoholism" + '"' + "," + '"' + "Handcap" + '"' + "," + '"' + "SMS_received" + '"' + "," + '"' + "No-show" + '"' + "," + '"' + "Scored Labels" + '"' + "," + '"' + "Scored Probabilities" + '"' + "]," + '"' + "ColumnTypes" + '"' + ":[" + '"' + "Double" + '"' + "," + '"' + "Int32" + '"' + "," + '"' + "Nullable" + "`1" + '"' + "," + '"' + "Int32" + '"' + "," + '"' + "String" + '"' + "," + '"' + "Int32" + '"' + "," + '"' + "Int32" + '"' + "," + '"' + "Int32" + '"' + "," + '"' + "Int32" + '"' + "," + '"' + "Int32" + '"' + "," + '"' + "Int32" + '"' + "," + '"' + "Int32" + '"' + "," + '"' + "Int32" + '"' + "," + '"' + "Double" + '"' + "],";
                    string[] _result = result.Replace(_replace, string.Empty).Split(',');
                    //Console.WriteLine("Result: {0}", _result[7]);
                    string test = _result[13].Replace('"', ' ').Replace("]", string.Empty).Replace(" ", string.Empty);
                    int col = dt.Columns.Count;
                    int _col = col;
                    dt.Rows.Add(patientid, reason, date, start, end, nurseid, test);
                    if (dt.Rows.Count == valuesCount)
                    {
                        dataGrid.ItemsSource = dt.DefaultView;
                        ___date = __date;
                    }
                    Console.Write("result : " + test);
                    listofvalues.Add(test);
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

            //dataGrid.Items.Clear();

        }
    }
}
