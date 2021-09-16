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
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WordFrequencyCounter
{
    public partial class frmWordFrequencyCounter : Form
    {
        public frmWordFrequencyCounter()
        {
            InitializeComponent();
        }

        SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-IRHGM1T\\SQLEXPRESS;Initial Catalog=WordCounterDB;Integrated Security=True");

        List<WordCounter> wordCounts = new List<WordCounter>();

        private void frmLoadBook_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                txtBookText.Clear();

                string filePath = openFileDialog.FileName;

                txtBookText.Text = File.ReadAllText(filePath);

            }

        }

        private void frmClearText_Click(object sender, EventArgs e)
        {
            txtBookText.Clear();
        }

        private void btnLoadTopFifty_Click(object sender, EventArgs e)
        {
            dgvWordFrequency.DataSource = null;
            dgvWordFrequency.Rows.Clear();

            LoadBook();

            sqlConn.Open();

            ClearTable();
            LoadWordsToDB();

            string strCommand = "SELECT TOP 50 * FROM WordFrequency WHERE Word <> '' ORDER BY Frequency DESC";
            GetWordList(strCommand);

            sqlConn.Close();

        }

        void GetWordList(string strCommand)
        {
            SqlCommand commGet = new SqlCommand(strCommand, sqlConn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(commGet);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dgvWordFrequency.DataSource = dataTable;
            
        }

        void LoadBook()
        {
            string allWords = txtBookText.Text;
            string[] wordsArray = allWords.Split(' ', '.', ',', '!', '-', '"');

             foreach (string w in wordsArray)
            {
                WordCounter foundWord = wordCounts.Find(x => x.word == w);
                if (foundWord == null)
                {
                    wordCounts.Add(new WordCounter(w, 1));
                }
                else
                {
                    foundWord.frequency++;

                }

            }

        }

        void ClearTable()
        {
            SqlCommand commClear = new SqlCommand("DELETE FROM WordFrequency", sqlConn);
            commClear.ExecuteNonQuery();
        }

        void LoadWordsToDB()
        {
            SqlCommand commClear = new SqlCommand("DELETE FROM WordFrequency", sqlConn);
            commClear.ExecuteNonQuery();

            foreach (WordCounter word in wordCounts)
            {
                string theWord = word.word.Replace("'", string.Empty);
                theWord.Trim();
                int theFrequency = word.frequency;

                SqlCommand command = new SqlCommand("INSERT INTO WordFrequency VALUES ( '" + theWord + "', " + theFrequency + ")", sqlConn);
                command.ExecuteNonQuery();

            }


        }

        private void btnLoadWords_Click(object sender, EventArgs e)
        {
            dgvWordFrequency.DataSource = null;
            dgvWordFrequency.Rows.Clear();

            LoadBook();
           
            sqlConn.Open();
  
            ClearTable();
            LoadWordsToDB();
 
            string strCommand = "SELECT * FROM WordFrequency WHERE LEN(Word) > 6 ORDER BY Frequency DESC";
            GetWordList(strCommand);

            sqlConn.Close();

        }
    }
}
