namespace PerlinTester
{
	partial class MainForm
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
			this.OutputPictureBox = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.PersistenceTrackBar = new System.Windows.Forms.TrackBar();
			this.FrequencyTrackBar = new System.Windows.Forms.TrackBar();
			this.AmplitudeTrackBar = new System.Windows.Forms.TrackBar();
			this.OctaveUpDown = new System.Windows.Forms.DomainUpDown();
			this.GenerateButton = new System.Windows.Forms.Button();
			this.SeedTextBox = new System.Windows.Forms.TextBox();
			this.SaveButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.OutputPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PersistenceTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.FrequencyTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AmplitudeTrackBar)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// OutputPictureBox
			// 
			this.OutputPictureBox.Location = new System.Drawing.Point(0, 0);
			this.OutputPictureBox.Name = "OutputPictureBox";
			this.OutputPictureBox.Size = new System.Drawing.Size(600, 600);
			this.OutputPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.OutputPictureBox.TabIndex = 0;
			this.OutputPictureBox.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Persistence";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Frequency";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 138);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Amplitude";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 203);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Octaves";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 270);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Seed";
			// 
			// PersistenceTrackBar
			// 
			this.PersistenceTrackBar.LargeChange = 100;
			this.PersistenceTrackBar.Location = new System.Drawing.Point(15, 25);
			this.PersistenceTrackBar.Maximum = 100;
			this.PersistenceTrackBar.Name = "PersistenceTrackBar";
			this.PersistenceTrackBar.Size = new System.Drawing.Size(271, 45);
			this.PersistenceTrackBar.TabIndex = 6;
			// 
			// FrequencyTrackBar
			// 
			this.FrequencyTrackBar.Location = new System.Drawing.Point(15, 90);
			this.FrequencyTrackBar.Maximum = 100;
			this.FrequencyTrackBar.Name = "FrequencyTrackBar";
			this.FrequencyTrackBar.Size = new System.Drawing.Size(271, 45);
			this.FrequencyTrackBar.TabIndex = 7;
			// 
			// AmplitudeTrackBar
			// 
			this.AmplitudeTrackBar.Location = new System.Drawing.Point(15, 155);
			this.AmplitudeTrackBar.Maximum = 100;
			this.AmplitudeTrackBar.Name = "AmplitudeTrackBar";
			this.AmplitudeTrackBar.Size = new System.Drawing.Size(271, 45);
			this.AmplitudeTrackBar.TabIndex = 8;
			// 
			// OctaveUpDown
			// 
			this.OctaveUpDown.Items.Add("8");
			this.OctaveUpDown.Items.Add("7");
			this.OctaveUpDown.Items.Add("6");
			this.OctaveUpDown.Items.Add("5");
			this.OctaveUpDown.Items.Add("4");
			this.OctaveUpDown.Items.Add("3");
			this.OctaveUpDown.Items.Add("2");
			this.OctaveUpDown.Items.Add("1");
			this.OctaveUpDown.Location = new System.Drawing.Point(15, 220);
			this.OctaveUpDown.Name = "OctaveUpDown";
			this.OctaveUpDown.ReadOnly = true;
			this.OctaveUpDown.Size = new System.Drawing.Size(120, 20);
			this.OctaveUpDown.TabIndex = 9;
			// 
			// GenerateButton
			// 
			this.GenerateButton.Location = new System.Drawing.Point(146, 546);
			this.GenerateButton.Name = "GenerateButton";
			this.GenerateButton.Size = new System.Drawing.Size(139, 43);
			this.GenerateButton.TabIndex = 11;
			this.GenerateButton.Text = "Generate";
			this.GenerateButton.UseVisualStyleBackColor = true;
			this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
			// 
			// SeedTextBox
			// 
			this.SeedTextBox.Location = new System.Drawing.Point(15, 287);
			this.SeedTextBox.MaxLength = 15;
			this.SeedTextBox.Name = "SeedTextBox";
			this.SeedTextBox.Size = new System.Drawing.Size(190, 20);
			this.SeedTextBox.TabIndex = 12;
			this.SeedTextBox.Text = "0";
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(12, 546);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(118, 44);
			this.SaveButton.TabIndex = 13;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.OutputPictureBox);
			this.panel1.Location = new System.Drawing.Point(302, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(600, 600);
			this.panel1.TabIndex = 14;
			// 
			// MainForm
			// 
			this.ClientSize = new System.Drawing.Size(903, 601);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.SeedTextBox);
			this.Controls.Add(this.GenerateButton);
			this.Controls.Add(this.OctaveUpDown);
			this.Controls.Add(this.AmplitudeTrackBar);
			this.Controls.Add(this.FrequencyTrackBar);
			this.Controls.Add(this.PersistenceTrackBar);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			((System.ComponentModel.ISupportInitialize)(this.OutputPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PersistenceTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.FrequencyTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AmplitudeTrackBar)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox OutputPictureBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TrackBar PersistenceTrackBar;
		private System.Windows.Forms.TrackBar FrequencyTrackBar;
		private System.Windows.Forms.TrackBar AmplitudeTrackBar;
		private System.Windows.Forms.DomainUpDown OctaveUpDown;
		private System.Windows.Forms.Button GenerateButton;
		private System.Windows.Forms.TextBox SeedTextBox;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Panel panel1;
	}
}

