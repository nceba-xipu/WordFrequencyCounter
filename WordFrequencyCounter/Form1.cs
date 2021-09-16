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
using System.Diagnostics;

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
            lblMessage.Text = "";
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
            lblMessage.Text = "";
            txtBookText.Clear();
        }

        private void btnLoadTopFifty_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.Text = "Processing...";
            if (txtBookText.TextLength > 0)
            {
                lblMessage.Text = "Processing...";
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();


                dgvWordFrequency.DataSource = null;
                dgvWordFrequency.Rows.Clear();

                LoadBook();

                sqlConn.Open();

                ClearTable();
                LoadWordsToDB();

                string strCommand = "SELECT TOP 50 * FROM WordFrequency WHERE Word <> '' ORDER BY Frequency DESC";
                GetWordList(strCommand);

                sqlConn.Close();

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                lblMessage.Text = String.Format("Process RunTime: {0} ", elapsedTime);

            }
            else
                lblMessage.Text = "Please load book before processing";
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
            string[] cleanWords = new string[wordsArray.Length];
            int i = 0;

            foreach (string w in wordsArray)
            {
                if (w.Length > 0)
                {
                    cleanWords[i] = Regex.Replace(w, @"(\s+|@|&|'|\(|\)|<|>|“|”|‘|’|\*|\$|\?|#)", "");
                    i++;
                }
            }

            foreach (string w in cleanWords)
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
            foreach (WordCounter word in wordCounts)
            {
                string theWord = word.word;
                int theFrequency = word.frequency;

                SqlCommand command = new SqlCommand("INSERT INTO WordFrequency VALUES ( '" + theWord + "', " + theFrequency + ")", sqlConn);
                command.ExecuteNonQuery();

            }


        }

        private void btnLoadWords_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.Text = "Processing...";
            if (txtBookText.TextLength > 0)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                dgvWordFrequency.DataSource = null;
                dgvWordFrequency.Rows.Clear();

                LoadBook();

                sqlConn.Open();

                ClearTable();
                LoadWordsToDB();

                string strCommand = "SELECT * FROM WordFrequency WHERE LEN(Word) > 6 ORDER BY Frequency DESC";
                GetWordList(strCommand);

                sqlConn.Close();

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                lblMessage.Text = String.Format("Process RunTime: {0} ", elapsedTime);

            }
            lblMessage.Text = "Please load book before processing";
        }
    }
}
