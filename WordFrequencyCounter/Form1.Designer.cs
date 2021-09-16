
namespace WordFrequencyCounter
{
    partial class frmWordFrequencyCounter
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.frmLoadBook = new System.Windows.Forms.Button();
            this.frmClearText = new System.Windows.Forms.Button();
            this.txtBookText = new System.Windows.Forms.TextBox();
            this.btnLoadTopFifty = new System.Windows.Forms.Button();
            this.dgvWordFrequency = new System.Windows.Forms.DataGridView();
            this.btnLoadWords = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWordFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // frmLoadBook
            // 
            this.frmLoadBook.Location = new System.Drawing.Point(25, 51);
            this.frmLoadBook.Name = "frmLoadBook";
            this.frmLoadBook.Size = new System.Drawing.Size(129, 48);
            this.frmLoadBook.TabIndex = 0;
            this.frmLoadBook.Text = "Load Book";
            this.frmLoadBook.UseVisualStyleBackColor = true;
            this.frmLoadBook.Click += new System.EventHandler(this.frmLoadBook_Click);
            // 
            // frmClearText
            // 
            this.frmClearText.Location = new System.Drawing.Point(171, 51);
            this.frmClearText.Name = "frmClearText";
            this.frmClearText.Size = new System.Drawing.Size(135, 48);
            this.frmClearText.TabIndex = 1;
            this.frmClearText.Text = "Clear";
            this.frmClearText.UseVisualStyleBackColor = true;
            this.frmClearText.Click += new System.EventHandler(this.frmClearText_Click);
            // 
            // txtBookText
            // 
            this.txtBookText.Location = new System.Drawing.Point(27, 111);
            this.txtBookText.Multiline = true;
            this.txtBookText.Name = "txtBookText";
            this.txtBookText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBookText.Size = new System.Drawing.Size(695, 615);
            this.txtBookText.TabIndex = 2;
            // 
            // btnLoadTopFifty
            // 
            this.btnLoadTopFifty.Location = new System.Drawing.Point(762, 54);
            this.btnLoadTopFifty.Name = "btnLoadTopFifty";
            this.btnLoadTopFifty.Size = new System.Drawing.Size(195, 44);
            this.btnLoadTopFifty.TabIndex = 3;
            this.btnLoadTopFifty.Text = "Load Top 50 Words";
            this.btnLoadTopFifty.UseVisualStyleBackColor = true;
            this.btnLoadTopFifty.Click += new System.EventHandler(this.btnLoadTopFifty_Click);
            // 
            // dgvWordFrequency
            // 
            this.dgvWordFrequency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWordFrequency.Location = new System.Drawing.Point(760, 111);
            this.dgvWordFrequency.Name = "dgvWordFrequency";
            this.dgvWordFrequency.RowHeadersWidth = 51;
            this.dgvWordFrequency.RowTemplate.Height = 29;
            this.dgvWordFrequency.Size = new System.Drawing.Size(388, 616);
            this.dgvWordFrequency.TabIndex = 4;
            // 
            // btnLoadWords
            // 
            this.btnLoadWords.Location = new System.Drawing.Point(972, 55);
            this.btnLoadWords.Name = "btnLoadWords";
            this.btnLoadWords.Size = new System.Drawing.Size(176, 44);
            this.btnLoadWords.TabIndex = 5;
            this.btnLoadWords.Text = "Load Long Words";
            this.btnLoadWords.UseVisualStyleBackColor = true;
            this.btnLoadWords.Click += new System.EventHandler(this.btnLoadWords_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(340, 28);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(13, 20);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = " ";
            // 
            // frmWordFrequencyCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 797);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnLoadWords);
            this.Controls.Add(this.dgvWordFrequency);
            this.Controls.Add(this.btnLoadTopFifty);
            this.Controls.Add(this.txtBookText);
            this.Controls.Add(this.frmClearText);
            this.Controls.Add(this.frmLoadBook);
            this.Name = "frmWordFrequencyCounter";
            this.Text = "Word Frequency Counter";
            ((System.ComponentModel.ISupportInitialize)(this.dgvWordFrequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button frmLoadBook;
        private System.Windows.Forms.Button frmClearText;
        private System.Windows.Forms.TextBox txtBookText;
        private System.Windows.Forms.Button btnLoadTopFifty;
        private System.Windows.Forms.DataGridView dgvWordFrequency;
        private System.Windows.Forms.Button btnLoadWords;
        private System.Windows.Forms.Label lblMessage;
    }
}

