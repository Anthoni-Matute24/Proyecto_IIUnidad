namespace Vista
{
    partial class LogIn
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
            this.components = new System.ComponentModel.Container();
            this.UsuarioLabel = new System.Windows.Forms.Label();
            this.UsuarioTextBox = new System.Windows.Forms.TextBox();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.ClaveTextBox = new System.Windows.Forms.TextBox();
            this.ClaveLabel = new System.Windows.Forms.Label();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UsuarioLabel
            // 
            this.UsuarioLabel.AutoSize = true;
            this.UsuarioLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UsuarioLabel.Location = new System.Drawing.Point(20, 29);
            this.UsuarioLabel.Name = "UsuarioLabel";
            this.UsuarioLabel.Size = new System.Drawing.Size(57, 17);
            this.UsuarioLabel.TabIndex = 0;
            this.UsuarioLabel.Text = "Usuario:";
            // 
            // UsuarioTextBox
            // 
            this.UsuarioTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UsuarioTextBox.Location = new System.Drawing.Point(20, 49);
            this.UsuarioTextBox.Name = "UsuarioTextBox";
            this.UsuarioTextBox.Size = new System.Drawing.Size(210, 25);
            this.UsuarioTextBox.TabIndex = 1;
            // 
            // AceptarButton
            // 
            this.AceptarButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AceptarButton.Image = global::Vista.Properties.Resources.AceptarButton;
            this.AceptarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AceptarButton.Location = new System.Drawing.Point(20, 154);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(97, 36);
            this.AceptarButton.TabIndex = 2;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // ClaveTextBox
            // 
            this.ClaveTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClaveTextBox.Location = new System.Drawing.Point(20, 109);
            this.ClaveTextBox.Name = "ClaveTextBox";
            this.ClaveTextBox.PasswordChar = '*';
            this.ClaveTextBox.Size = new System.Drawing.Size(210, 25);
            this.ClaveTextBox.TabIndex = 4;
            // 
            // ClaveLabel
            // 
            this.ClaveLabel.AutoSize = true;
            this.ClaveLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClaveLabel.Location = new System.Drawing.Point(20, 89);
            this.ClaveLabel.Name = "ClaveLabel";
            this.ClaveLabel.Size = new System.Drawing.Size(43, 17);
            this.ClaveLabel.TabIndex = 3;
            this.ClaveLabel.Text = "Clave:";
            // 
            // CancelarButton
            // 
            this.CancelarButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CancelarButton.Image = global::Vista.Properties.Resources.CancelarButton;
            this.CancelarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CancelarButton.Location = new System.Drawing.Point(133, 154);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(97, 36);
            this.CancelarButton.TabIndex = 5;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Vista.Properties.Resources.Login;
            this.pictureBox1.Location = new System.Drawing.Point(244, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // LogIn
            // 
            this.AcceptButton = this.AceptarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(391, 225);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.ClaveTextBox);
            this.Controls.Add(this.ClaveLabel);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.UsuarioTextBox);
            this.Controls.Add(this.UsuarioLabel);
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label UsuarioLabel;
        private TextBox UsuarioTextBox;
        private Button AceptarButton;
        private TextBox ClaveTextBox;
        private Label ClaveLabel;
        private Button CancelarButton;
        private ErrorProvider errorProvider1;
        private PictureBox pictureBox1;
    }
}