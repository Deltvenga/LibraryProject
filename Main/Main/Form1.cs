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

            // TODO: добавить обработку else
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
                var d = new Service1Client();
                var date = d.AddNewAbonement(currentReaderId, currentBookId);
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

        List<ComboboxValues> comboboxSrc;


        private void Form1_Load(object sender, EventArgs e)
        {
            var sv = new Service1Client();
            var readers = sv.GetAllReaders();
            comboboxSrc = new List<ComboboxValues>();
            foreach (var reader in readers)
            {
                comboboxSrc.Add(new ComboboxValues(reader));
            }
            comboBox1.DisplayMember = "fio";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = comboboxSrc;

            var genres = sv.GetGenre();
            for (int i = 0; i < genres.Length; i++)
                comboBox3.Items.Add(genres[i]);
        }

        class ComboboxValues
        {

            public ComboboxValues(Reader reader)
            {
                fio = reader.LastName + " " + reader.FirstName + " " + reader.MiddleName + " - " + reader.IdReader;
                id = reader.IdReader;
            }
            public string fio { get; set; }
            public int id { get; set; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDG5();
        }
        
        private void UpdateDG5()
        {
            dataGridView5.Rows.Clear();
            currentReaderId = int.Parse(comboBox1.SelectedValue.ToString());

            var sv = new Service1Client();
            var abonement = sv.GetAbonement(currentReaderId);

            for (int i = 0; i < abonement.Length; i++)
            {
                dataGridView5.Rows.Add(abonement[i]);
            }
            var genre = sv.GetGenre();

            for (int i = 0; i < dataGridView5.RowCount; i++)
            {
                var cb = dataGridView5.Columns[7] as DataGridViewComboBoxColumn;
                cb.DataSource = genre;
            }
            textBox6.Text = comboBox1.SelectedValue.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var d = new Service1Client();
            var data = d.GetWriteOffBooks();

            dataGridView3.Rows.Clear();

            for (int i = 0; i < data.Length; i++)
            {
                dataGridView3.Rows.Add(false, data[i].IdBook, data[i].NameBook, data[i].Year, data[i].Publish, data[i].PublishCountry, data[i].PageCount, data[i].Language, data[i].Captures, data[i].Disrepair, data[i].Status);             
            }         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var d = new Service1Client();          
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
            var d = new Service1Client();
            List<int> booksToDelete = new List<int>();
            List<string> nameBook = new List<string>();

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if ((bool)row.Cells[0].Value)
                {
                    booksToDelete.Add(int.Parse(row.Cells[1].Value.ToString()));
                    nameBook.Add(row.Cells[2].Value.ToString());
                }               
            }
            d.DeleteWriteOffBooks(booksToDelete.ToArray(), nameBook.ToArray());
            button5_Click(null, null);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                Captures = 0,
                Disrepair = Convert.ToInt32(numericUpDown3.Value),
                Status = comboBox3.Text.ToString()
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
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var d = new Service1Client();
            List<int> abonId = new List<int>();
            List<int> booksId = new List<int>();
            List<string> genre = new List<string>();
            List<int> disrepair = new List<int>();

            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                if (row.Cells[6].Value != null && (bool)row.Cells[6].Value)
                {
                    abonId.Add(int.Parse(row.Cells[0].Value.ToString()));
                    booksId.Add(int.Parse(row.Cells[1].Value.ToString()));
                    genre.Add(row.Cells[7].Value.ToString());
                    disrepair.Add(int.Parse(row.Cells[5].Value.ToString()));
                }
            }
            d.ReturnBooks(abonId.ToArray(), booksId.ToArray(), genre.ToArray(), disrepair.ToArray());
            UpdateDG5();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            var txt = textBox6.Text;
            if(txt.Length > 0)
            {
                foreach (var item in comboboxSrc)
                {
                    int tempId;
                    if(int.TryParse(txt, out tempId))
                    {
                        if (item.id == tempId)
                        {
                            comboBox1.SelectedValue = item.id;
                        }
                    }
                    
                }
            }
            
        }
    }
}
