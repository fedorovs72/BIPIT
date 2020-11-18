using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormClient.ServiceReference1;
using Exception = System.Exception;

namespace WinFormClient
{
    public partial class Form1 : Form
    {

        Service1Client sessionClient = new Service1Client("NetTcpBinding_IService1");
        static Uri address = new Uri("net.tcp://localhost:8734/");
        NetTcpBinding binding = new NetTcpBinding();

        public Form1()
        {
            InitializeComponent();
        }

        public void FillTable()
        {
            dataGridView1.DataSource = sessionClient.GetData();
            dataGridView1.Columns[0].HeaderText = "Код записи";
            dataGridView1.Columns[1].HeaderText = "Код Клиента";
            dataGridView1.Columns[2].HeaderText = "ФИО Клиента";
            dataGridView1.Columns[3].HeaderText = "Код Автобуса";
            dataGridView1.Columns[4].HeaderText = "Название автобуса";
            dataGridView1.Columns[5].HeaderText = "Стоимость";
            dataGridView1.Columns[6].HeaderText = "Дата";
            dataGridView1.Update();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                sessionClient.ConnectionInfo(binding.Name, address.Port.ToString(), address.LocalPath,
                    address.ToString(), address.Scheme);
                string idExp = comboBox1.SelectedValue.ToString();
                string idH = comboBox2.SelectedValue.ToString();
                string autorOrder = textBox1.Text;
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                if (sessionClient.RecCheck(idExp, idH,  date, autorOrder).Equals("1"))
                {
                    MessageBox.Show("Такая запись уже существует!");
                }
                else
                {
                    MessageBox.Show(sessionClient.InsertMethod(idExp, idH, date, autorOrder));
                    sessionClient.CountOfDBRows(dataGridView1.Rows.Count.ToString());
                    this.FillTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                sessionClient.ConnectionInfo(binding.Name, address.Port.ToString(), address.LocalPath,
                    address.ToString(), address.Scheme);
                comboBox1.DataSource = sessionClient.GetExpSelectData();
                comboBox1.DisplayMember = "name_exp";
                comboBox1.ValueMember = "id_exp";
                comboBox2.DataSource = sessionClient.GetHallSelectData();
                comboBox2.DisplayMember = "name_h";
                comboBox2.ValueMember = "id_h";
                FillTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }
    }
}
