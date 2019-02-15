namespace ClassificationData
{
	partial class frmMain
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
			this.btnList = new System.Windows.Forms.Button();
			this.rtbOutput = new System.Windows.Forms.RichTextBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.bntJsonDeser = new System.Windows.Forms.Button();
			this.bntBeautify = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnList
			// 
			this.btnList.Location = new System.Drawing.Point(12, 12);
			this.btnList.Name = "btnList";
			this.btnList.Size = new System.Drawing.Size(149, 23);
			this.btnList.TabIndex = 0;
			this.btnList.Text = "List Classifications";
			this.btnList.UseVisualStyleBackColor = false;
			this.btnList.Click += new System.EventHandler(this.btnList_Click);
			// 
			// rtbOutput
			// 
			this.rtbOutput.Location = new System.Drawing.Point(12, 112);
			this.rtbOutput.Name = "rtbOutput";
			this.rtbOutput.Size = new System.Drawing.Size(764, 396);
			this.rtbOutput.TabIndex = 1;
			this.rtbOutput.Text = "";
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(701, 514);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 2;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 41);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(149, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "V2";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 70);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(149, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "V3";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// bntJsonDeser
			// 
			this.bntJsonDeser.Location = new System.Drawing.Point(601, 12);
			this.bntJsonDeser.Name = "bntJsonDeser";
			this.bntJsonDeser.Size = new System.Drawing.Size(156, 23);
			this.bntJsonDeser.TabIndex = 5;
			this.bntJsonDeser.Text = "Deserialise Json";
			this.bntJsonDeser.UseVisualStyleBackColor = true;
			this.bntJsonDeser.Click += new System.EventHandler(this.bntJsonDeser_Click);
			// 
			// bntBeautify
			// 
			this.bntBeautify.Location = new System.Drawing.Point(601, 41);
			this.bntBeautify.Name = "bntBeautify";
			this.bntBeautify.Size = new System.Drawing.Size(156, 23);
			this.bntBeautify.TabIndex = 6;
			this.bntBeautify.Text = "Beautify";
			this.bntBeautify.UseVisualStyleBackColor = true;
			this.bntBeautify.Click += new System.EventHandler(this.button3_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(788, 549);
			this.Controls.Add(this.bntBeautify);
			this.Controls.Add(this.bntJsonDeser);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.rtbOutput);
			this.Controls.Add(this.btnList);
			this.Name = "frmMain";
			this.Text = "Drug Classifications";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnList;
		private System.Windows.Forms.RichTextBox rtbOutput;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button bntJsonDeser;
		private System.Windows.Forms.Button bntBeautify;
	}
}