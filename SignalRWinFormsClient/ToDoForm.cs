using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json;
//using RestSharp.Serialization.Json;
using SignalRServer.Models.DB;

namespace SignalRWinFormsClient
{
    public partial class ToDoForm : Form
    {

        private readonly string addressUrl = "http://localhost:55001/notification";

        private HubConnection _connection;

        public ToDoForm()
        {
            InitializeComponent();

        }

        private void ToDo_Load(object sender, EventArgs e)
        {

	        //txtUserName.Focus();
        }

        private void addressTextBox_Enter(object sender, EventArgs e)
        {
            AcceptButton = connectButton;
        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            UpdateState(connected: false);

            _connection = new HubConnectionBuilder()
                .WithUrl(addressUrl)
                .Build();

            //_connection.On<string, string>("broadcastMessage", (s1, s2) => OnSend(s1, s2));

            //_connection.On<string, string>("broadcastMessage", (s1, s2) => OnSend(s1, s2));

            //_connection.On<string, string>("RegisterUser", (s1, s2) => OnRegisterUser(s1));

            _connection.On<string>("GetConnectionId", (connId) => OnSend(connId));

            _connection.On<string>("HelloServer", (message) => OnHelloServer(message));



            Log(Color.Gray, "Starting connection...");
            try
            {
                await _connection.StartAsync();

                await _connection.InvokeAsync("RegisterUser", comboBox1.Text);
            }
            catch (Exception ex)
            {
                Log(Color.Red, ex.ToString());
                return;
            }

            //Log(Color.Gray, "Connection established.");

            UpdateState(connected: true);

            //messageTextBox.Focus();
        }

        private void OnHelloServer(string message)
        {
            Invoke(new Action (async () =>
            {
                MessageBox.Show("Для Вас додалася ще одна задача!" + "\n" + "Задача: " + message);

                await GetTasks(comboBox1.Text);

                listBox1.Items.Add(message);
                //messagesList.Items.Add(new LogMessage(color, message));
            }));
        }

        private async void disconnectButton_Click(object sender, EventArgs e)
        {
            Log(Color.Gray, "Stopping connection...");
            try
            {
                await _connection.StopAsync();

            }
            catch (Exception ex)
            {
                Log(Color.Red, ex.ToString());
            }

            Log(Color.Gray, "Connection terminated.");

            UpdateState(connected: false);
        }

        private void messageTextBox_Enter(object sender, EventArgs e)
        {
            //AcceptButton = sendButton;
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                //await _connection.InvokeAsync("Send", "txtUserName", "messageTextBox.Text");
            }
            catch (Exception ex)
            {
                Log(Color.Red, ex.ToString());
            }
        }

        private void UpdateState(bool connected)
        {
            disconnectButton.Enabled = connected;
            connectButton.Enabled = !connected;
            //txtUserName.Enabled = !connected;

            //messageTextBox.Enabled = connected;
            //sendButton.Enabled = connected;
        }

        private void OnSend(string connId)
        {
	        Action callback = () =>
	        {
		        txtConnId.Text = connId;
	        };

	        Invoke(callback);
        }


        //private void OnRegisterUser(string name, string message)
        //{
        //    Log(Color.Black, name + ": " + message);
        //}

        private void Log(Color color, string message)
        {
            Action callback = () =>
            {
                //listBox1.Items.Add(message);
                //messagesList.Items.Add(new LogMessage(color, message));
            };

            Invoke(callback);
        }

        private class LogMessage
        {
            public Color MessageColor { get; }

            public string Content { get; }

            public LogMessage(Color messageColor, string content)
            {
                MessageColor = messageColor;
                Content = content;
            }
        }

        private void messagesList_DrawItem(object sender, DrawItemEventArgs e)
        {
            //var message1 = (LogMessage)messagesList.Items[e.Index];
            //e.Graphics.DrawString(
            //    message1.Content,
            //    messagesList.Font,
            //    new SolidBrush(message1.MessageColor),
            //    e.Bounds);
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var client = new RestClient($"http://localhost:55001/api/ToDo/tasksAsync/{comboBox1.Text}");

            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Content-Type", "application/json");
            //client.Timeout = -1;

            //IRestResponse response = client.Execute(request);

            //string json = response.Content;

            HttpClient client = new HttpClient();
            //var client = new RestClient($"http://localhost:55001/api/ToDo/GetEmployees");

            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Content-Type", "application/json");

            //var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            //var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);

            //var response = client.Execute<List<Employee>>(request);
        }

        private async void getTasks_Click(object sender, EventArgs e)
        {
            await GetTasks(comboBox1.Text);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            var streamTask = await client.GetStreamAsync("http://localhost:55001/api/ToDo/GetEmployees");

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            var employees = await JsonSerializer.DeserializeAsync<List<EmployeeDTO>>(streamTask, serializeOptions);

            var tasks = employees.Single(emp => emp.Name == comboBox1.Text).Tasks;

            dataGridView1.DataSource = tasks;

            //var client = new RestClient($"http://localhost:55001/api/ToDo/tasksAsync/{comboBox1.Text}");
        }

        private async Task GetTasks(string userName)
        {
            HttpClient client = new HttpClient();

            try
            {
                var streamTask = client.GetStreamAsync("http://localhost:55001/api/ToDo/GetEmployees");

                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                var employees = await JsonSerializer.DeserializeAsync<List<EmployeeDTO>>(await streamTask, serializeOptions);

                var tasks = employees.Single(emp => emp.Name == userName).Tasks;

                dataGridView1.DataSource = tasks;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
