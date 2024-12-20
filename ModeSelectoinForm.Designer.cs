// ModeSelectionForm.Designer.cs
namespace TicTacToe
{
    partial class ModeSelectionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RadioButton rbPlayerVsPlayer;
        private System.Windows.Forms.RadioButton rbPlayerVsComputer;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblTitle;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удалён; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbPlayerVsPlayer = new System.Windows.Forms.RadioButton();
            this.rbPlayerVsComputer = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbPlayerVsPlayer
            // 
            this.rbPlayerVsPlayer.AutoSize = true;
            this.rbPlayerVsPlayer.Location = new System.Drawing.Point(30, 50);
            this.rbPlayerVsPlayer.Name = "rbPlayerVsPlayer";
            this.rbPlayerVsPlayer.Size = new System.Drawing.Size(144, 19);
            this.rbPlayerVsPlayer.TabIndex = 0;
            this.rbPlayerVsPlayer.TabStop = true;
            this.rbPlayerVsPlayer.Text = "Игрок против Игрока";
            this.rbPlayerVsPlayer.UseVisualStyleBackColor = true;
            // 
            // rbPlayerVsComputer
            // 
            this.rbPlayerVsComputer.AutoSize = true;
            this.rbPlayerVsComputer.Location = new System.Drawing.Point(30, 90);
            this.rbPlayerVsComputer.Name = "rbPlayerVsComputer";
            this.rbPlayerVsComputer.Size = new System.Drawing.Size(174, 19);
            this.rbPlayerVsComputer.TabIndex = 1;
            this.rbPlayerVsComputer.TabStop = true;
            this.rbPlayerVsComputer.Text = "Игрок против Компьютера";
            this.rbPlayerVsComputer.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(30, 140);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(150, 35);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Начать игру";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(30, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(195, 21);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Выберите режим игры:";
            // 
            // ModeSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rbPlayerVsComputer);
            this.Controls.Add(this.rbPlayerVsPlayer);
            this.Name = "ModeSelectionForm";
            this.Text = "Выбор режима игры";
            this.Load += new System.EventHandler(this.ModeSelectionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
