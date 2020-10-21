using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using Microsoft.VisualBasic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _4
{
    public partial class Form1 : Form
    {
        struct books
        {
            public int id;
            public string name;
            public string author;
            public string genre;
            public int price;
            public int readers;
            public int year;
            public int l_date;
            };

        List <books> spisok = new List<books> ();
        StreamReader readfl;
        StreamWriter writefl;

        void Otbor()
        {
            string tx = textBox1.Text;
            var otbor = from x in spisok where x.author == tx select x;
            dataGridView1.Rows.Clear();
            foreach (var t in otbor)
                dataGridView1.Rows.Add(t.id, t.name, t.author, t.genre, t.price, t.readers, t.year, t.l_date);
        }
        void Sort()
        {
            var sort = from x in spisok orderby x.author select x;
            dataGridView1.Rows.Clear();
            foreach ( var t in sort)
                dataGridView1.Rows.Add(t.id, t.name, t.author, t.genre, t.price, t.readers, t.year, t.l_date);
        }
        void Vivod()
        {
            string fl, result;
                fl = Microsoft.VisualBasic.Interaction.InputBox("Введите имя файла");
            writefl = File.CreateText(fl + ".txt");
            result = string.Format("{0,12}{1,5}{2,8}{3,19}{4,7}", "1", "2", "3", "4", "5");
            writefl.WriteLine(result);
            for (int k = 0; k < dataGridView1.Rows.Count - 1; k++)
            {
                result = string.Format("{0,12}{1,5}{2,8}{3,19}{4,7}",
                    dataGridView1.Rows[k].Cells[0].Value,
                    dataGridView1.Rows[k].Cells[1].Value,
                    dataGridView1.Rows[k].Cells[2].Value,
                    dataGridView1.Rows[k].Cells[3].Value);
                writefl.WriteLine(result);
            }
            writefl.Close();
        }

        public Form1()
        {

            InitializeComponent();
            string str;
            if (File.Exists("books.txt"))
            {
                readfl = new StreamReader("books.txt");
            }
            else
            {
                MessageBox.Show("Файл не найден");
                return;
            }
            while (readfl.EndOfStream == false)
            {
                books book;
                str = readfl.ReadLine();
                string[] s = str.Split(';');
                book.id = Convert.ToInt32(s[0]);
                book.name = s[1];
                book.author = s[2];
                book.genre = s[3];
                book.price = Convert.ToInt32(s[4]);
                book.readers = Convert.ToInt32(s[5]);
                book.year = Convert.ToInt32(s[6]);
                book.l_date = Convert.ToInt32(s[7]);
                spisok.Add(book);
            }
            readfl.Close();
            dataGridView1.Rows.Clear();
            foreach (var t in spisok)
                dataGridView1.Rows.Add(t.id, t.name, t.author, t.genre, t.price, t.readers, t.year, t.l_date);
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
