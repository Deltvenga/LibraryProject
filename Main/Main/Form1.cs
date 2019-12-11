using System;
using System.Windows.Forms;
using System.Data;
using Main.ServiceReference1;
using System.Collections.Generic;
using LibraryService;

namespace Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int currentReaderId;
        private void button1_Click(object sender, EventArgs e)
        {
            string[] arr = new string[8];
            arr[0] = textBox1.Text;
            arr[1] = textBox2.Text;
            arr[2] = textBox3.Text;
            arr[3] = textBox4.Text;
            arr[4] = textBox8.Text;
            arr[5] = textBox9.Text;
            arr[6] = textBox10.Text;
            arr[7] = textBox5.Text;

            if (checkBox1.Checked && checkBox2.Checked)
            {
                var d = new ServiceReference1.Service1Client();
                d.AddNewReader(arr);
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var d = new ServiceReference1.Service1Client();
            var data = d.HasExpires();

            var dt = new DataTable();
            
            foreach(var col in data.Item1)
            {
                dt.Columns.Add(col);
            }
            foreach(var row in data.Item2)
            {
                dt.Rows.Add(row);
            }
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var d = new ServiceReference1.Service1Client();
            var data = d.GetBooks(textBox7.Text);

            dataGridView2.Rows.Clear();
              
            for (int i = 0; i < data.Length; i++)
            {            
                dataGridView2.Rows.Add(data[i].IdBook, data[i].NameBook, data[i].Year, data[i].Publish, data[i].PublishCountry, data[i].PageCount, data[i].Language, data[i].Captures, data[i].Disrepair, data[i].Status); 
            }            
        }

        private int currentBookId = -1;
        private string currentBookName;

        private void button4_Click(object sender, EventArgs e)
        {
            if(currentBookId == -1)
            {
                MessageBox.Show("Книга не выбрана!");
            } else
            {
                var d = new ServiceReference1.Service1Client();
                var date = d.AddNewAbonement(int.Parse(textBox6.Text), currentBookId);
                MessageBox.Show("Книга " + currentBookName + " выдана, дата возврата: " + date);
            }
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var currentRow = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex];
            currentBookId = int.Parse(currentRow.Cells[0].Value.ToString());
            currentBookName = currentRow.Cells[1].Value.ToString();
            label13.Text = currentBookName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var sv = new Service1Client();
            var readers = sv.GetAllReaders();
            List<ComboboxValues> comboboxSrc = new List<ComboboxValues>();
            foreach (var reader in readers)
            {
                comboboxSrc.Add(new ComboboxValues(reader));
            }
            comboBox1.DisplayMember = "fio";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = comboboxSrc;
            
        }

        class ComboboxValues
        {

            public ComboboxValues(Reader reader)
            {
                fio = reader.LastName + " " + reader.FirstName + " " + reader.MiddleName;
                id = reader.IdReader;
            }
            public string fio { get; set; }
            public int id { get; set; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentReaderId = int.Parse(comboBox1.SelectedValue.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var d = new ServiceReference1.Service1Client();
            var data = d.GetWriteOffBooks();
            //var newdata = d.GetReplenishBooks();

            dataGridView3.Rows.Clear();
            //dataGridView4.Rows.Clear();

            for (int i = 0; i < data.Length; i++)
            {
                dataGridView3.Rows.Add(false, data[i].IdBook, data[i].NameBook, data[i].Year, data[i].Publish, data[i].PublishCountry, data[i].PageCount, data[i].Language, data[i].Captures, data[i].Disrepair, data[i].Status);             
            }         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var d = new ServiceReference1.Service1Client();          
            var data = d.GetReplenishBooks();

            dataGridView4.Rows.Clear();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].CountPhonetic < 4)
                    dataGridView4.Rows.Add(data[i].NameBook, data[i].CountPhonetic);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var d = new ServiceReference1.Service1Client();
            List<int> booksToDelete = new List<int>();

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if ((bool)row.Cells[0].Value)
                {
                    booksToDelete.Add(int.Parse(row.Cells[1].Value.ToString()));
                }
                
            }
            d.DeleteWriteOffBooks(booksToDelete.ToArray());
            button5_Click(null, null);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("sw");
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            var sv = new Service1Client();
            Book newBook = new Book()
            {
                NameBook = richTextBox1.Text,
                Year = Convert.ToInt32(numericUpDown1.Value),
                Publish = textBox14.Text,
                PageCount = Convert.ToInt32(numericUpDown2.Value),
                PublishCountry = comboBox2.Text,
                Language = textBox15.Text,
                Captures=0,
                Disrepair = Convert.ToInt32(numericUpDown3.Value),
                Status = null
            };
            sv.AddNewBook(newBook);
        }

        private void fillBookName()
        {
            var nameBook = dataGridView4.Rows[dataGridView4.CurrentCell.RowIndex].Cells[0].Value.ToString();
            richTextBox1.Text = nameBook;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fillBookName();
        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            fillBookName();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

        }
    }
}
