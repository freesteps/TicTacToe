namespace TicTacToe
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnReset;
        private Label lblStatus;
        private Button button00;
        private Button button01;
        private Button button02;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button20;
        private Button button21;
        private Button button22;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.button00 = new System.Windows.Forms.Button();
            this.button01 = new System.Windows.Forms.Button();
            this.button02 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel1.Controls.Add(this.button22, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button21, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button20, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button12, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button11, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button02, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button01, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button00, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 300);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(100, 320);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 30);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(0, 360);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(300, 30);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Ход: X";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button00
            // 
            this.button00.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button00.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button00.Location = new System.Drawing.Point(3, 3);
            this.button00.Name = "button00";
            this.button00.Size = new System.Drawing.Size(93, 93);
            this.button00.TabIndex = 0;
            this.button00.UseVisualStyleBackColor = true;
            this.button00.Click += new System.EventHandler(this.Button_Click);
            // 
            // button01
            // 
            this.button01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button01.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button01.Location = new System.Drawing.Point(102, 3);
            this.button01.Name = "button01";
            this.button01.Size = new System.Drawing.Size(93, 93);
            this.button01.TabIndex = 1;
            this.button01.UseVisualStyleBackColor = true;
            this.button01.Click += new System.EventHandler(this.Button_Click);
            // 
            // button02
            // 
            this.button02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button02.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button02.Location = new System.Drawing.Point(201, 3);
            this.button02.Name = "button02";
            this.button02.Size = new System.Drawing.Size(96, 93);
            this.button02.TabIndex = 2;
            this.button02.UseVisualStyleBackColor = true;
            this.button02.Click += new System.EventHandler(this.Button_Click);
            // 
            // button10
            // 
            this.button10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button10.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button10.Location = new System.Drawing.Point(3, 102);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(93, 93);
            this.button10.TabIndex = 3;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Button_Click);
            // 
            // button11
            // 
            this.button11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button11.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button11.Location = new System.Drawing.Point(102, 102);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(93, 93);
            this.button11.TabIndex = 4;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Button_Click);
            // 
            // button12
            // 
            this.button12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button12.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button12.Location = new System.Drawing.Point(201, 102);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(96, 93);
            this.button12.TabIndex = 5;
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.Button_Click);
            // 
            // button20
            // 
            this.button20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button20.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button20.Location = new System.Drawing.Point(3, 201);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(93, 96);
            this.button20.TabIndex = 6;
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.Button_Click);
            // 
            // button21
            // 
            this.button21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button21.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button21.Location = new System.Drawing.Point(102, 201);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(93, 96);
            this.button21.TabIndex = 7;
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.Button_Click);
            // 
            // button22
            // 
            this.button22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button22.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button22.Location = new System.Drawing.Point(201, 201);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(96, 96);
            this.button22.TabIndex = 8;
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.Button_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(300, 400);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Крестики-нолики";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
