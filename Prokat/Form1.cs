using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using xNet.Text;
namespace Prokat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Auto> L = new List<Auto>();//объектный полиморфизм - это список L типа Auto, а на самом деле там три его наследника классы Bus  Сargo_car Passenger_car
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            comboBox1.Items.Add("Легковий автомобіль");
            comboBox1.Items.Add("Вантажний автомобіль");
            comboBox1.Items.Add("Автобус");
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            dataGridView1.Columns.Add("newColumnName", "VRP");
            dataGridView1.Columns.Add("newColumnName", "Колір");
            dataGridView1.Columns.Add("newColumnName", "Виробник");
            dataGridView1.Columns.Add("newColumnName", "Модель");
            dataGridView1.Columns.Add("newColumnName", "Рік випуску");
            dataGridView1.Columns.Add("newColumnName", "Опис");
            dataGridView1.Columns.Add("newColumnName", "Статус");

            dataGridView1.AllowUserToAddRows = false;
            DataGridViewColumn column = dataGridView1.Columns[5];
            column.Width = 150;

            string []s = File.ReadAllLines("memory.txt");
            int kol = Convert.ToInt32(s[0]);
            for(int i=1;i<kol+1;i++)
            {
                string[] str1 = s[i].Split('|');
                if(str1[5].IndexOf("Легковий")!=-1)
                {
                    if(str1[6]=="Вільний")
                    {
                        Passenger_car a = new Passenger_car(str1[0], str1[1], str1[2], str1[3], false, Convert.ToInt32(str1[4]), str1[5].Replace("Легковий", ""));
                        L.Add(a);
                        this.dataGridView1.Rows.Add(a.GEtVRP(), a.GEtColor(), a.GEtCompany(), a.GEtModel(), a.GEtYear(), "Легковий. Тип кузова: " + a.GetOpisniye(), "Вільний");
                    }
                    else
                    {
                        Passenger_car a = new Passenger_car(str1[0], str1[1], str1[2], str1[3], false, Convert.ToInt32(str1[4]), str1[5].Replace("Легковий", ""));
                        L.Add(a);
                        this.dataGridView1.Rows.Add(a.GEtVRP(), a.GEtColor(), a.GEtCompany(), a.GEtModel(), a.GEtYear(), "Легковий. Тип кузова: " + a.GetOpisniye(), "Зайнято");
                    }

     
                }
                if (str1[5].IndexOf("Вантажний") != -1)
                {

                    if (str1[6] == "Вільний")
                    {
                        Сargo_car a = new Сargo_car(str1[0], str1[1], str1[2], str1[3], false, Convert.ToInt32(str1[4]), Convert.ToInt32( str1[5].Replace("Вантажний", "")));
                        L.Add(a);
                        this.dataGridView1.Rows.Add(a.GEtVRP(), a.GEtColor(), a.GEtCompany(), a.GEtModel(), a.GEtYear(), "Вантажний. Тип кузова: " + a.GetOpisniye(), "Вільний");
                    }
                    else
                    {
                        Сargo_car a = new Сargo_car(str1[0], str1[1], str1[2], str1[3], false, Convert.ToInt32(str1[4]), Convert.ToInt32(str1[5].Replace("Вантажний", "")));
                        L.Add(a);
                        this.dataGridView1.Rows.Add(a.GEtVRP(), a.GEtColor(), a.GEtCompany(), a.GEtModel(), a.GEtYear(), "Вантажний. Тип кузова: " + a.GetOpisniye(), "Зайнято");
                    }

                }
                if (str1[5].IndexOf("Автобус") != -1)
                {
                    if (str1[6] == "Вільний")
                    {
                        Bus a = new Bus(str1[0], str1[1], str1[2], str1[3], false, Convert.ToInt32(str1[4]), Convert.ToInt32(str1[5].Replace("Автобус", "")));
                        L.Add(a);
                        this.dataGridView1.Rows.Add(a.GEtVRP(), a.GEtColor(), a.GEtCompany(), a.GEtModel(), a.GEtYear(), "Автобус. Кільк. місць: " + a.GetOpisniye(), "Вільний");
                    }
                    else
                    {
                        Bus a = new Bus(str1[0], str1[1], str1[2], str1[3], false, Convert.ToInt32(str1[4]), Convert.ToInt32(str1[5].Replace("Автобус", "")));
                        L.Add(a);
                        this.dataGridView1.Rows.Add(a.GEtVRP(), a.GEtColor(), a.GEtCompany(), a.GEtModel(), a.GEtYear(), "Автобус. Кільк. місць: " + a.GetOpisniye(), "Зайнято");
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label6.Text = "Тип кузова:";
            }
            if (comboBox1.SelectedIndex == 1)
            {

                label6.Text = "Вантажопідйомність:";
            }
            if (comboBox1.SelectedIndex == 2)
            {
                label6.Text = "Кількість місць:";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                try
                {
                    Passenger_car a = new Passenger_car(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, false, Convert.ToInt32(textBox5.Text), textBox6.Text);
                    L.Add(a);
                    this.dataGridView1.Rows.Add(a.GEtVRP(), a.GEtColor(), a.GEtCompany(), a.GEtModel(), a.GEtYear(), "Легковий. Тип кузова: " + a.GetOpisniye(), "Вільний");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";


                }
                catch
                {
                    MessageBox.Show("Коректно заповніть поля. ");
                }

            }
            if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    Сargo_car a = new Сargo_car(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, false, Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text));
                    L.Add(a);
                    this.dataGridView1.Rows.Add(a.GEtVRP(), a.GEtColor(), a.GEtCompany(), a.GEtModel(), a.GEtYear(), "Вантажний. Вантажопідйомність: " + a.GetOpisniye(), "Вільний");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                }
                catch
                {
                    MessageBox.Show("Коректно заповніть поля. ");
                }

                
            }
            if (comboBox1.SelectedIndex == 2)
            {
                try
                {

                    Bus a = new Bus(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, false, Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text));
                    L.Add(a);
                    this.dataGridView1.Rows.Add(a.GEtVRP(), a.GEtColor(), a.GEtCompany(), a.GEtModel(), a.GEtYear(), "Автобус. Кількість місць: " + a.GetOpisniye(), "Вільний");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";


                }
                catch
                {
                    MessageBox.Show("Коректно заповніть поля. ");
                }
            }

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            if (index != -1)
            {
                L[index].ChangeStatus();
            }

            dataGridView1.Rows.Clear();


            for(int i=0;i<L.Count;i++)
            {
                Type t = L[i].GetType();
                if(t.Name== "Passenger_car")
                {
                    Passenger_car t1 = (Passenger_car)L[i];
                    if (L[i].GEtStatus() == false)
                        this.dataGridView1.Rows.Add(t1.GEtVRP(), t1.GEtColor(), t1.GEtCompany(), t1.GEtModel(), t1.GEtYear(), "Легковий. Тип кузова: " + t1.GetOpisniye(), "Вільний");
                    if (L[i].GEtStatus() == true)
                        this.dataGridView1.Rows.Add(t1.GEtVRP(), t1.GEtColor(), t1.GEtCompany(), t1.GEtModel(), t1.GEtYear(), "Легковий. Тип кузова: " + t1.GetOpisniye(), "Зайнято");
                }
                if (t.Name == "Сargo_car")
                {
                    Сargo_car t1 = (Сargo_car)L[i];
                    if (L[i].GEtStatus()==false)
                       this.dataGridView1.Rows.Add(t1.GEtVRP(), t1.GEtColor(), t1.GEtCompany(), t1.GEtModel(), t1.GEtYear(), "Вантажний. Вантажопідйомність: " + t1.GetOpisniye(), "Вільний");
                    if (t1.GEtStatus() == true)
                       this.dataGridView1.Rows.Add(t1.GEtVRP(), t1.GEtColor(), t1.GEtCompany(), t1.GEtModel(), t1.GEtYear(), "Вантажний. Вантажопідйомність: " + t1.GetOpisniye(), "Зайнято");


                }
                if (t.Name == "Bus")
                {
                    Bus t1 = (Bus)L[i];
                    if (t1.GEtStatus() == false)
                        this.dataGridView1.Rows.Add(t1.GEtVRP(), t1.GEtColor(), t1.GEtCompany(), t1.GEtModel(), t1.GEtYear(), "Автобус. Кількість місць: " + t1.GetOpisniye(), "Вільний");
                    if (t1.GEtStatus() == true)
                        this.dataGridView1.Rows.Add(t1.GEtVRP(), t1.GEtColor(), t1.GEtCompany(), t1.GEtModel(), t1.GEtYear(), "Автобус. Кількість місць: " + t1.GetOpisniye(), "Зайнято");
                }

            }


        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if(dataGridView1.CurrentCell!=null)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                if (index != -1)
                {
                    L.RemoveAt(index);
                }

                dataGridView1.Rows.Clear();
                for (int i = 0; i < L.Count; i++)
                {
                    Type t = L[i].GetType();
                    if (t.Name == "Passenger_car")
                    {
                        Passenger_car t1 = (Passenger_car)L[i];
                        if (L[i].GEtStatus() == false)
                            this.dataGridView1.Rows.Add(t1.GEtVRP(), t1.GEtColor(), t1.GEtCompany(), t1.GEtModel(), t1.GEtYear(), "Легковий. Тип кузова: " + t1.GetOpisniye(), "Вільний");
                        if (L[i].GEtStatus() == true)
                            this.dataGridView1.Rows.Add(t1.GEtVRP(), t1.GEtColor(), t1.GEtCompany(), t1.GEtModel(), t1.GEtYear(), "Легковий. Тип кузова: " + t1.GetOpisniye(), "Зайнято");
                    }
                    if (t.Name == "Сargo_car")
                    {
                        Сargo_car t1 = (Сargo_car)L[i];
                        if (L[i].GEtStatus() == false)
                            this.dataGridView1.Rows.Add(t1.GEtVRP(), t1.GEtColor(), t1.GEtCompany(), t1.GEtModel(), t1.GEtYear(), "Вантажний. Вантажопідйомність: " + t1.GetOpisniye(), "Вільний");
                        if (t1.GEtStatus() == true)
                            this.dataGridView1.Rows.Add(t1.GEtVRP(), t1.GEtColor(), t1.GEtCompany(), t1.GEtModel(), t1.GEtYear(), "Вантажний. Вантажопідйомність: " + t1.GetOpisniye(), "Зайнято");


                    }
                    if (t.Name == "Bus")
                    {
                        Bus t1 = (Bus)L[i];
                        if (t1.GEtStatus() == false)
                            this.dataGridView1.Rows.Add(t1.GEtVRP(), t1.GEtColor(), t1.GEtCompany(), t1.GEtModel(), t1.GEtYear(), "Автобус. Кількість місць: " + t1.GetOpisniye(), "Вільний");
                        if (t1.GEtStatus() == true)
                            this.dataGridView1.Rows.Add(t1.GEtVRP(), t1.GEtColor(), t1.GEtCompany(), t1.GEtModel(), t1.GEtYear(), "Автобус. Кількість місць: " + t1.GetOpisniye(), "Зайнято");
                    }

                }
            }   
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string s = "";
            s += L.Count.ToString();
            s += Environment.NewLine;
            for (int i=0;i<L.Count;i++)
            {
                Type t = L[i].GetType();
                if (t.Name == "Passenger_car")
                {
                    Passenger_car t1 = (Passenger_car)L[i];
                    if(t1.GEtStatus()==false)
                    {
                        s += t1.GEtVRP() + "|" + t1.GEtColor() + "|" + t1.GEtCompany() + "|" + t1.GEtModel() + "|" + t1.GEtYear() + "|" + "Легковий" + t1.GetOpisniye() + "|" + "Вільний";
                    }
                    else
                    {
                        s += t1.GEtVRP() + "|" + t1.GEtColor() + "|" + t1.GEtCompany() + "|" + t1.GEtModel() + "|" + t1.GEtYear() + "|" + "Легковий" + t1.GetOpisniye() + "|" + "Зайнято";
                    }
                    s += Environment.NewLine;
                }
                if (t.Name == "Сargo_car")
                {
                    Сargo_car t1 = (Сargo_car)L[i];
                    if (t1.GEtStatus() == false)
                    {
                        s += t1.GEtVRP() + "|" + t1.GEtColor() + "|" + t1.GEtCompany() + "|" + t1.GEtModel() + "|" + t1.GEtYear() + "|" + "Вантажний" + t1.GetOpisniye() + "|" + "Вільний";
                    }
                    else
                    {
                        s += t1.GEtVRP() + "|" + t1.GEtColor() + "|" + t1.GEtCompany() + "|" + t1.GEtModel() + "|" + t1.GEtYear() + "|" + "Вантажний" + t1.GetOpisniye() + "|" + "Зайнято";
                    }      
                    s += Environment.NewLine;

                }
                if (t.Name == "Bus")
                {
                    Bus t1 = (Bus)L[i];
                    if (t1.GEtStatus() == false)
                    {
                        s += t1.GEtVRP() + "|" + t1.GEtColor() + "|" + t1.GEtCompany() + "|" + t1.GEtModel() + "|" + t1.GEtYear() + "|" + "Автобус" + t1.GetOpisniye() + "|" + "Вільний";
                    }
                    else
                    {
                        s += t1.GEtVRP() + "|" + t1.GEtColor() + "|" + t1.GEtCompany() + "|" + t1.GEtModel() + "|" + t1.GEtYear() + "|" + "Автобус" + t1.GetOpisniye() + "|" + "Зайнято";
                    }
                    s += Environment.NewLine;
                }
            }
            File.WriteAllText("memory.txt", s);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string hour = DateTime.Now.ToShortTimeString();
            string data_text = DateTime.Now.ToLongDateString();
            label8.Text = data_text  + "  "
                + hour;

        }
    }
}
