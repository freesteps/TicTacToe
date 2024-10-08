namespace TicTacToe
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnReset;
        private Label lblStatus;

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
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 300);
            for (int i = 0; i < 3; i++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
                this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            }

            // Добавление кнопок
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Fill;
                    btn.Font = new Font(FontFamily.GenericSansSerif, 24F, FontStyle.Bold, GraphicsUnit.Point);
                    btn.Name = $"button{row}{col}";
                    this.tableLayoutPanel1.Controls.Add(btn, col, row);
                }
            }

            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(100, 320);
            this.btnReset.Size = new System.Drawing.Size(100, 30);
            this.btnReset.Text = "Сброс";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(0, 360);
            this.lblStatus.Size = new System.Drawing.Size(300, 30);
            this.lblStatus.Text = "Ход: X";
            this.lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(300, 400);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Крестики-нолики";
            this.ResumeLayout(false);
        }
    }
}
