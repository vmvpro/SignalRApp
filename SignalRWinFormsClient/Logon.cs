using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SignalRWinFormsClient
{
    public partial class Logon : Form
    {
        public Logon()
        {
            InitializeComponent();
        }

        private async void btnConnection_Click(object sender, EventArgs e)
        {
            HubConnection _connection;

            string addressUrl = "http://localhost:55001/notification";

            var employeeName = cbxEpmployees.Text;

            if (string.IsNullOrEmpty(employeeName))
            {
                MessageBox.Show("Введіть будь ласка логін та пароль");
                cbxEpmployees.Focus();
                return;
            }

            try
            {
                _connection = new HubConnectionBuilder()
                .WithUrl(addressUrl)
                .Build();

                await _connection.StartAsync();

                await _connection.InvokeAsync("RegisterUser", cbxEpmployees.Text);

                this.Visible = false;

                new ToDoForm(employeeName, _connection).ShowDialog();

                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
