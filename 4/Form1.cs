using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4
{
    public partial class Form1 : Form
    {
        struct Books
        {
            public string id;
            public string name;
            public int author;
            public int genre;
            public string price;
            public int readers;
            public int year;
            public int l_date;
            };

        Books[] massiv;
        public int n;

        void Otbor()
        {
            dataGridView1.Rows.Clear();
            string k = textBox1.Text;
            foreach (var t in massiv)
                if (t.type_plane == k)
                {
                    dataGridView1.Rows.Add(t.n_flight, t.dest, t.b_time, t.time_on_way, t.type_plane, t.ticket_cost, t.number_seats, t.time_dest, t.procceds);
                }
        }
        int Time_dest(int a, int b)
        {
            return a + b;
        }
        int Proceeds(int a, int b)
        {
            return a * b;
        }
        public Form1()
        {
            string[] rows;
            
            InitializeComponent();

            if (File.Exists("planes.txt"))
            {
                
                StreamWriter writefl;
                rows = File.ReadAllLines("planes.txt");
                n = rows.Length;
                massiv = new books[n];
            }
            else
            {
                MessageBox.Show("Файл не найден");
                return;
            }
            for (int i = 0; i < n; i++)
            {
                string[] str = rows[i].Split(';');
                massiv[i].n_flight = str[0];
                massiv[i].dest = str[1];
                massiv[i].b_time = int.Parse(str[2]);
                massiv[i].time_on_way = int.Parse(str[3]);
                massiv[i].type_plane = str[4];
                massiv[i].ticket_cost = int.Parse(str[5]);
                massiv[i].number_seats = int.Parse(str[6]);
                massiv[i].time_dest = Time_dest(massiv[i].b_time, massiv[i].time_on_way);
                massiv[i].procceds = Proceeds(massiv[i].ticket_cost, massiv[i].number_seats);

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sort();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Otbor();
        }
    }
}
