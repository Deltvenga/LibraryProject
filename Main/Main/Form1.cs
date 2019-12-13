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
        private Service1Client service;
        private int currentBookId = -1;
        private string currentBookStatus;
        private string currentBookName;
        List<ComboboxValues> comboboxSrc;


        private void Form1_Load(object sender, EventArgs e)
        {
            service = new Service1Client();
            var readers = service.GetAllReaders();
            comboboxSrc = new List<ComboboxValues>();
            foreach (var reader in readers)
            {
                comboboxSrc.Add(new ComboboxValues(reader));
            }
            comboBox1.DisplayMember = "fio";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = comboboxSrc;

            var genres = service.GetGenre();
            for (int i = 0; i < genres.Length; i++)
                comboBox3.Items.Add(genres[i]);
            UpdateDG2();
            UpdateDG5();
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

        private void button1_Click(object sender, EventArgs e)
        {
            string[] queryArr = new string[8];
            queryArr[0] = textBox1.Text;
            queryArr[1] = textBox2.Text;
            queryArr[2] = textBox3.Text;
            queryArr[3] = textBox4.Text;
            queryArr[4] = textBox8.Text;
            queryArr[5] = textBox9.Text;
            queryArr[6] = textBox10.Text;
            queryArr[7] = textBox5.Text;

            if (checkBox1.Checked && checkBox2.Checked)
            {
                string result = service.AddNewReader(queryArr);
                if (result == "success")
                {
                    MessageBox.Show("Пользователь успешно создан");
                }
                else
                {
                    MessageBox.Show("Ошибка добавления читателя");
                }
            } else
            {
                MessageBox.Show("Вы должны подтвердить соглашения");
            }    
        }

        private void ExpiresTabOpen()
        {
            var data = service.HasExpires();

            var DGVDataTable = new DataTable();

            foreach (var col in data.Item1)
            {
                DGVDataTable.Columns.Add(col);
            }
            foreach (var row in data.Item2)
            {
                DGVDataTable.Rows.Add(row);
            }
            dataGridView1.DataSource = DGVDataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var data = service.HasExpires();

            var DGVDataTable = new DataTable();
            
            foreach(var col in data.Item1)
            {
                DGVDataTable.Columns.Add(col);
            }
            foreach(var row in data.Item2)
            {
                DGVDataTable.Rows.Add(row);
            }
            dataGridView1.DataSource = DGVDataTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateDG2();       
        }

        private void UpdateDG2()
        {
            var DGV2Arr = service.GetBooks(textBox7.Text, !checkBox3.Checked);

            dataGridView2.Rows.Clear();

            for (int i = 0; i < DGV2Arr.Length; i++)
            {
                dataGridView2.Rows.Add(DGV2Arr[i].IdBook, DGV2Arr[i].NameBook, DGV2Arr[i].Year, DGV2Arr[i].Publish, DGV2Arr[i].PublishCountry, DGV2Arr[i].PageCount, DGV2Arr[i].Language, DGV2Arr[i].Captures, DGV2Arr[i].Disrepair, DGV2Arr[i].Status);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if(currentBookId == -1)
            {
                MessageBox.Show("Книга не выбрана!");
            } else if(currentBookStatus == "Выдана")
            {
                MessageBox.Show("Книга уже выдана!");
            } else
            {
                var date = service.AddNewAbonement(currentReaderId, currentBookId);
                MessageBox.Show("Книга " + currentBookName + " выдана, дата возврата: " + date);
                UpdateDG2();
                UpdateDG5();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDG2();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var currentRow = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex];
            currentBookId = int.Parse(currentRow.Cells[0].Value.ToString());
            currentBookStatus = currentRow.Cells[9].Value.ToString();
            currentBookName = currentRow.Cells[1].Value.ToString();
            label13.Text = currentBookName;
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDG5();
        }
        
        private void UpdateDG5()
        {
            dataGridView5.Rows.Clear();
            currentReaderId = int.Parse(comboBox1.SelectedValue.ToString());
           
            var abonement = service.GetAbonement(currentReaderId);

            for (int i = 0; i < abonement.Length; i++)
            {
                dataGridView5.Rows.Add(abonement[i]);
            }
            var genre = service.GetGenre();

            for (int i = 0; i < dataGridView5.RowCount; i++)
            {
                var cb = dataGridView5.Columns[7] as DataGridViewComboBoxColumn;
                cb.DataSource = genre;
            }
            textBox6.Text = comboBox1.SelectedValue.ToString();
        }

        private void WriteOffBooksTabOpen()
        {
            var data = service.GetWriteOffBooks();

            dataGridView3.Rows.Clear();

            for (int i = 0; i < data.Length; i++)
            {
                dataGridView3.Rows.Add(false, data[i].IdBook, data[i].NameBook, data[i].Year, data[i].Publish, data[i].PublishCountry, data[i].PageCount, data[i].Language, data[i].Captures, data[i].Disrepair, data[i].Status);
            }
        }

        private void ReplenishBooksOpen()
        {
            var data = service.GetReplenishBooks();

            dataGridView4.Rows.Clear();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].CountPhonetic < 4)
                    dataGridView4.Rows.Add(data[i].NameBook, data[i].CountPhonetic);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
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
            service.DeleteWriteOffBooks(booksToDelete.ToArray(), nameBook.ToArray());
            WriteOffBooksTabOpen();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
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
            service.AddNewBook(newBook);
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

        private void button9_Click(object sender, EventArgs e)
        {
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
            service.ReturnBooks(abonId.ToArray(), booksId.ToArray(), genre.ToArray(), disrepair.ToArray());
            UpdateDG5();
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            var txt = textBox6.Text;
            if(txt.Length > 0)
            {
                foreach (var item in comboboxSrc)
                {
                    if (int.TryParse(txt, out int tempId))
                    {
                        if (item.id == tempId)
                        {
                            comboBox1.SelectedValue = item.id;
                        }
                    }

                }
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            //TODO переделать на конструкцию switch
            if (tabControl1.TabIndex == 5)
            {
                ExpiresTabOpen();
            } else if(tabControl1.TabIndex == 4)
            {
                ReplenishBooksOpen();
            } else if(tabControl1.TabIndex == 3)
            {
                WriteOffBooksTabOpen();
            }
        }
    }
}
