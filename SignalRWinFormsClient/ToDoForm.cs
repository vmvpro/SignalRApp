using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using SignalRServer.Models.DB;

namespace SignalRWinFormsClient
{
    public partial class ToDoForm : Form
    {

        private HubConnection _connection;
        private EmployeeDTO _employeeDTO;

        public ToDoForm()
        {
            InitializeComponent();
        }

        public ToDoForm(string employeeName, HubConnection connection)
        {
            InitializeComponent();

            txtEmployeeName.Text = employeeName;
            
            _connection = connection;
            _connection.On<string>("NotificationTask", (message) => OnNotificationTask(message));

        }

        private async void ToDo_Load(object sender, EventArgs e)
        {

            _employeeDTO = await RestClient.GetStreamAsync<EmployeeDTO>($"/getEmployee/{txtEmployeeName.Text}");

            txtConnId.Text = _connection.ConnectionId;

            dgvTasks.DataSource = await GetTasks(txtEmployeeName.Text);
        }

        private void OnNotificationTask(string message)
        {
            Invoke(new Action(async () =>
           {
               MessageBox.Show("Для Вас додалася ще одна задача!" + "\n" + "Задача: " + message);

               dgvTasks.DataSource = await GetTasks(txtEmployeeName.Text);

           }));
        }

        private async void getTasks_Click(object sender, EventArgs e)
        {
            dgvTasks.DataSource = await GetTasks(txtEmployeeName.Text);
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {

        }

        private void btnTaskEdit_Click(object sender, EventArgs e)
        {

        }

        private async void btnAddTask_Click(object sender, EventArgs e)
        {
            var newTask = new TaskDTO() { Name = "Add new Task", IdEmployee = _employeeDTO.EmployeeId };

            await RestClient.PostAsync(newTask, "/employee/createTask");

            dgvTasks.DataSource = await GetTasks(txtEmployeeName.Text);

        }

        private async Task<List<TaskDTO>> GetTasks(string userName)
        {
            try
            {
                var employees = await RestClient.GetStreamAsync<List<EmployeeDTO>>("/getEmployees");

                return employees.Single(emp => emp.Name == userName).Tasks;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return null;
            }
        }

        private async void ToDoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                await _connection.StopAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
