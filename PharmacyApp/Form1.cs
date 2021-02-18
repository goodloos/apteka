using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.клиентыTableAdapter.Update(this.pharmacyDataSet.Клиенты);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.сотрудникTableAdapter.Update(this.pharmacyDataSet.Сотрудник);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.лекарствоTableAdapter.Update(this.pharmacyDataSet.Лекарство);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //удаление выбраной строчки из таблицы
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            this.клиентыTableAdapter.Update(this.pharmacyDataSet.Клиенты);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //удаление выбраной строчки из таблицы
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.Remove(row);
            }
            this.сотрудникTableAdapter.Update(this.pharmacyDataSet.Сотрудник);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //удаление выбраной строчки из таблицы
            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                dataGridView3.Rows.Remove(row);
            }
            this.лекарствоTableAdapter.Update(this.pharmacyDataSet.Лекарство);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            клиентыBindingSource.Filter = "ФИО = \'" + textBox1.Text + "\'";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            сотрудникBindingSource.Filter = "ФИО = \'" + textBox2.Text + "\'"; ;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            лекарствоBindingSource.Filter= "Наименование = \'" + textBox3.Text + "\'";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";//обнуляем поле ввода
            var tb = new DataTable();//создаем новую таблицу как в бд
            tb.Columns.Add("ID_Клиента");//добавляем в таблицу столбцы с названиями, аналогичными в таблице в БД
            tb.Columns.Add("ФИО");
            tb.Columns.Add("Адрес");
            tb.Columns.Add("Номер");
            //проходим по таблицы Клиенты из БД
            foreach (var i in this.pharmacyDataSet.Клиенты)
            {
                //добавляем информацию в созданную таблицу
                tb.Rows.Add(i.ID_Клиента, i.ФИО, i.Адрес, i.Номер);
            }
            BindingSource t = new BindingSource();//для связывания таблицы с элементом dataGridView
            t.DataSource = tb;
            dataGridView1.DataSource = t;//добавляем в качестве данных для dataGridView только что заполненую таблицу
            //автоматически выведется информация о всех клиентах
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";//обнуляем поле ввода
            var tb = new DataTable();//создаем новую таблицу как в бд
            tb.Columns.Add("ID_Сотрудника");//добавляем в таблицу столбцы с названиями, аналогичными в таблице в БД
            tb.Columns.Add("ФИО");
            tb.Columns.Add("Должность");
            //проходим по таблицы Клиенты из БД
            foreach (var i in this.pharmacyDataSet.Сотрудник)
            {
                //добавляем информацию в созданную таблицу
                tb.Rows.Add(i.ID_Сотрудника, i.ФИО, i.Должность);
            }
            BindingSource t = new BindingSource();//для связывания таблицы с элементом dataGridView
            t.DataSource = tb;
            dataGridView2.DataSource = t;//добавляем в качестве данных для dataGridView только что заполненую таблицу
            //автоматически выведется информация о всех клиентах
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";//обнуляем поле ввода
            var tb = new DataTable();//создаем новую таблицу как в бд
            tb.Columns.Add("ID_Лекарства");//добавляем в таблицу столбцы с названиями, аналогичными в таблице в БД
            tb.Columns.Add("Наименование");
            tb.Columns.Add("Рецепт");
            tb.Columns.Add("Количество");
            tb.Columns.Add("Цена");

            //проходим по таблицы Клиенты из БД
            foreach (var i in this.pharmacyDataSet.Лекарство)
            {
                //добавляем информацию в созданную таблицу
                tb.Rows.Add(i.ID_Лекарства, i.Наименование, i.Рецепт, i.Количество, i.Цена);
            }
            BindingSource t = new BindingSource();//для связывания таблицы с элементом dataGridView
            t.DataSource = tb;
            dataGridView3.DataSource = t;//добавляем в качестве данных для dataGridView только что заполненую таблицу
            //автоматически выведется информация о всех клиентах
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            var query2 = from medecine in this.pharmacyDataSet.Tables["Лекарство"].AsEnumerable()
                         where (string)medecine["Наименование"] == comboBox3.SelectedItem.ToString()
                         select new { Medtcine = medecine["ID_Лекарства"], Count = medecine["Количество"], Price = medecine["Цена"] };
            if (Convert.ToInt32(textBox7.Text) > (int)query2.ElementAt(0).Count)
            {
                MessageBox.Show("Такого количества нет на складе");
            }
            else
            {
                var query = from client in this.pharmacyDataSet.Tables["Клиенты"].AsEnumerable()
                            where (string)client["ФИО"] == comboBox1.SelectedItem.ToString()
                            select client["ID_Клиента"];
                var query1 = from emploee in this.pharmacyDataSet.Tables["Сотрудник"].AsEnumerable()
                             where (string)emploee["ФИО"] == comboBox2.SelectedItem.ToString()
                             select emploee["ID_Сотрудника"];
                int i = (int)query.ElementAt(0);
                int ii = (int)query1.ElementAt(0);

                DataRow workRow = pharmacyDataSet.Tables["Заказ"].NewRow();
                workRow["ID_Сотрудника"] = (int)query1.ElementAt(0);
                workRow["ID_Клиента"] = (int)query.ElementAt(0);
                workRow["ID_Лекарства"] = (int)query2.ElementAt(0).Medtcine;
                workRow["Количество"] = textBox7.Text;
                workRow["Цена"] = Convert.ToInt32(textBox7.Text)* (int)query2.ElementAt(0).Price;
                workRow["Дата"] = DateTime.Now.ToString();
                pharmacyDataSet.Tables["Заказ"].Rows.Add(workRow);
                this.заказTableAdapter.Update(this.pharmacyDataSet.Заказ);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            var query = from client in this.pharmacyDataSet.Tables["Клиенты"].AsEnumerable()
                        select client["ФИО"];
            foreach (var i in query)
            {
                comboBox1.Items.Add(i);
            }
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            var query = from emploee in this.pharmacyDataSet.Tables["Сотрудник"].AsEnumerable()
                         select emploee["ФИО"];
            foreach (var i in query)
            {
                comboBox2.Items.Add(i);
            }
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            var query = from medecine in this.pharmacyDataSet.Tables["Лекарство"].AsEnumerable()
                        select medecine["Наименование"];
            foreach (var i in query)
            {
                comboBox3.Items.Add(i);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView4.SelectedRows)
            {
                dataGridView4.Rows.Remove(row);
            }
            this.заказTableAdapter.Update(this.pharmacyDataSet.Заказ);
        }
    }
}
