﻿namespace UIReservation
{
    partial class ViewReservationForm
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
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Felix Titling", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(132, 24);
            label1.Name = "label1";
            label1.Size = new Size(221, 23);
            label1.TabIndex = 0;
            label1.Text = "View Reservations";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 68);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(465, 400);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // ViewReservationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 489);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "ViewReservationForm";
            Text = "ViewReservationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RichTextBox richTextBox1;
    }
}