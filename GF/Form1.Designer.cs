namespace WF
{
	partial class Form1
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
			splitContainer1 = new SplitContainer();
			fPanel3 = new FPanel();
			fPanel4 = new FPanel();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(fPanel3);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(fPanel4);
			splitContainer1.Size = new Size(959, 454);
			splitContainer1.SplitterDistance = 467;
			splitContainer1.TabIndex = 0;
			// 
			// fPanel3
			// 
			fPanel3.Dock = DockStyle.Fill;
			fPanel3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			fPanel3.Location = new Point(0, 0);
			fPanel3.Name = "fPanel3";
			fPanel3.Size = new Size(467, 454);
			fPanel3.TabIndex = 0;
			fPanel3.Text = "fPanel3";
			// 
			// fPanel4
			// 
			fPanel4.Dock = DockStyle.Fill;
			fPanel4.Location = new Point(0, 0);
			fPanel4.Name = "fPanel4";
			fPanel4.Size = new Size(488, 454);
			fPanel4.TabIndex = 0;
			fPanel4.Text = "fPanel4";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(959, 454);
			Controls.Add(splitContainer1);
			Name = "Form1";
			Text = "Form1";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private FPanel fPanel1;
		private FPanel fPanel2;
		private FPanel fPanel3;
		private FPanel fPanel4;
	}
}