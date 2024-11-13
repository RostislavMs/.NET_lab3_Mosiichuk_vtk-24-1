namespace ProcessManagerApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProcessGridView = new System.Windows.Forms.DataGridView();
            this.KillProcessButton = new System.Windows.Forms.Button();
            this.SetPriorityButton = new System.Windows.Forms.Button();
            this.StartCalculatorButton = new System.Windows.Forms.Button();
            this.PriorityComboBox = new System.Windows.Forms.ComboBox();
            this.startWordBtn = new System.Windows.Forms.Button();
            this.startExelBtn = new System.Windows.Forms.Button();
            this.startChromeBtn = new System.Windows.Forms.Button();
            this.startPaintBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ProcessGridView
            // 
            this.ProcessGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcessGridView.Location = new System.Drawing.Point(12, 12);
            this.ProcessGridView.MinimumSize = new System.Drawing.Size(900, 300);
            this.ProcessGridView.Name = "ProcessGridView";
            this.ProcessGridView.RowHeadersWidth = 51;
            this.ProcessGridView.RowTemplate.Height = 24;
            this.ProcessGridView.Size = new System.Drawing.Size(936, 300);
            this.ProcessGridView.TabIndex = 0;
            this.ProcessGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProcessGridView_SelectionChanged);
            // 
            // KillProcessButton
            // 
            this.KillProcessButton.Location = new System.Drawing.Point(786, 342);
            this.KillProcessButton.Name = "KillProcessButton";
            this.KillProcessButton.Size = new System.Drawing.Size(162, 35);
            this.KillProcessButton.TabIndex = 1;
            this.KillProcessButton.Text = "Зупинити процес";
            this.KillProcessButton.UseVisualStyleBackColor = true;
            this.KillProcessButton.Click += new System.EventHandler(this.KillProcessButton_Click);
            // 
            // SetPriorityButton
            // 
            this.SetPriorityButton.Location = new System.Drawing.Point(12, 342);
            this.SetPriorityButton.Name = "SetPriorityButton";
            this.SetPriorityButton.Size = new System.Drawing.Size(227, 34);
            this.SetPriorityButton.TabIndex = 2;
            this.SetPriorityButton.Text = "Змінити пріоритет";
            this.SetPriorityButton.UseVisualStyleBackColor = true;
            this.SetPriorityButton.Click += new System.EventHandler(this.SetPriorityButton_Click);
            // 
            // StartCalculatorButton
            // 
            this.StartCalculatorButton.Location = new System.Drawing.Point(386, 477);
            this.StartCalculatorButton.Name = "StartCalculatorButton";
            this.StartCalculatorButton.Size = new System.Drawing.Size(196, 37);
            this.StartCalculatorButton.TabIndex = 3;
            this.StartCalculatorButton.Text = "Запустити Калькулятор";
            this.StartCalculatorButton.UseVisualStyleBackColor = true;
            this.StartCalculatorButton.Click += new System.EventHandler(this.StartCalculatorButton_Click);
            // 
            // PriorityComboBox
            // 
            this.PriorityComboBox.FormattingEnabled = true;
            this.PriorityComboBox.Location = new System.Drawing.Point(262, 343);
            this.PriorityComboBox.Name = "PriorityComboBox";
            this.PriorityComboBox.Size = new System.Drawing.Size(188, 24);
            this.PriorityComboBox.TabIndex = 4;
            // 
            // startWordBtn
            // 
            this.startWordBtn.Location = new System.Drawing.Point(588, 477);
            this.startWordBtn.Name = "startWordBtn";
            this.startWordBtn.Size = new System.Drawing.Size(177, 37);
            this.startWordBtn.TabIndex = 7;
            this.startWordBtn.Text = "Запустити Word";
            this.startWordBtn.UseVisualStyleBackColor = true;
            this.startWordBtn.Click += new System.EventHandler(this.startWordBtn_Click);
            // 
            // startExelBtn
            // 
            this.startExelBtn.Location = new System.Drawing.Point(203, 477);
            this.startExelBtn.Name = "startExelBtn";
            this.startExelBtn.Size = new System.Drawing.Size(177, 37);
            this.startExelBtn.TabIndex = 8;
            this.startExelBtn.Text = "Запустити Exel";
            this.startExelBtn.UseVisualStyleBackColor = true;
            this.startExelBtn.Click += new System.EventHandler(this.startExelBtn_Click);
            // 
            // startChromeBtn
            // 
            this.startChromeBtn.Location = new System.Drawing.Point(12, 477);
            this.startChromeBtn.Name = "startChromeBtn";
            this.startChromeBtn.Size = new System.Drawing.Size(185, 37);
            this.startChromeBtn.TabIndex = 9;
            this.startChromeBtn.Text = "Запустити Chrom";
            this.startChromeBtn.UseVisualStyleBackColor = true;
            this.startChromeBtn.Click += new System.EventHandler(this.startChromeBtn_Click);
            // 
            // startPaintBtn
            // 
            this.startPaintBtn.Location = new System.Drawing.Point(771, 477);
            this.startPaintBtn.Name = "startPaintBtn";
            this.startPaintBtn.Size = new System.Drawing.Size(177, 37);
            this.startPaintBtn.TabIndex = 10;
            this.startPaintBtn.Text = "Запустити Paint";
            this.startPaintBtn.UseVisualStyleBackColor = true;
            this.startPaintBtn.Click += new System.EventHandler(this.startPaintBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 526);
            this.Controls.Add(this.startPaintBtn);
            this.Controls.Add(this.startChromeBtn);
            this.Controls.Add(this.startExelBtn);
            this.Controls.Add(this.startWordBtn);
            this.Controls.Add(this.PriorityComboBox);
            this.Controls.Add(this.StartCalculatorButton);
            this.Controls.Add(this.SetPriorityButton);
            this.Controls.Add(this.KillProcessButton);
            this.Controls.Add(this.ProcessGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProcessGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ProcessGridView;
        private System.Windows.Forms.Button KillProcessButton;
        private System.Windows.Forms.Button SetPriorityButton;
        private System.Windows.Forms.Button StartCalculatorButton;
        private System.Windows.Forms.ComboBox PriorityComboBox;
        private System.Windows.Forms.Button startWordBtn;
        private System.Windows.Forms.Button startExelBtn;
        private System.Windows.Forms.Button startChromeBtn;
        private System.Windows.Forms.Button startPaintBtn;
    }
}

