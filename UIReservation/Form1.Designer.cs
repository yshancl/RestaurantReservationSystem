namespace UIReservation
{
    partial class ReservationSystem
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
            lblWelcome = new Label();
            btnBook = new Button();
            btnView = new Button();
            btnUpdate = new Button();
            btnCancel = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Perpetua Titling MT", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(101, 31);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(329, 26);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome to Seoul House!";
            // 
            // btnBook
            // 
            btnBook.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBook.Location = new Point(145, 97);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(230, 55);
            btnBook.TabIndex = 1;
            btnBook.Text = "Book a Reservation";
            btnBook.UseVisualStyleBackColor = true;
            btnBook.Click += btnBook_Click;
            // 
            // btnView
            // 
            btnView.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnView.Location = new Point(145, 167);
            btnView.Name = "btnView";
            btnView.Size = new Size(230, 55);
            btnView.TabIndex = 2;
            btnView.Text = "View Reservations";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(145, 237);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(230, 55);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update Reservation";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(145, 307);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(230, 55);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel Reservation";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(145, 383);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(230, 55);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // ReservationSystem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 456);
            Controls.Add(btnExit);
            Controls.Add(btnCancel);
            Controls.Add(btnUpdate);
            Controls.Add(btnView);
            Controls.Add(btnBook);
            Controls.Add(lblWelcome);
            MaximizeBox = false;
            Name = "ReservationSystem";
            Text = "Restaurant Reservation System";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnBook;
        private Button btnView;
        private Button btnUpdate;
        private Button btnCancel;
        private Button btnExit;
    }
}
