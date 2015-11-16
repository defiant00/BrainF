namespace BrainF
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
			this.textBoxInput = new System.Windows.Forms.TextBox();
			this.buttonInterpret = new System.Windows.Forms.Button();
			this.buttonBuild = new System.Windows.Forms.Button();
			this.labelOutput = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBoxInput
			// 
			this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxInput.Location = new System.Drawing.Point(8, 8);
			this.textBoxInput.Multiline = true;
			this.textBoxInput.Name = "textBoxInput";
			this.textBoxInput.Size = new System.Drawing.Size(608, 392);
			this.textBoxInput.TabIndex = 0;
			// 
			// buttonInterpret
			// 
			this.buttonInterpret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonInterpret.Location = new System.Drawing.Point(448, 408);
			this.buttonInterpret.Name = "buttonInterpret";
			this.buttonInterpret.Size = new System.Drawing.Size(80, 32);
			this.buttonInterpret.TabIndex = 1;
			this.buttonInterpret.Text = "Interpret";
			this.buttonInterpret.UseVisualStyleBackColor = true;
			this.buttonInterpret.Click += new System.EventHandler(this.buttonInterpret_Click);
			// 
			// buttonBuild
			// 
			this.buttonBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBuild.Location = new System.Drawing.Point(536, 408);
			this.buttonBuild.Name = "buttonBuild";
			this.buttonBuild.Size = new System.Drawing.Size(80, 32);
			this.buttonBuild.TabIndex = 2;
			this.buttonBuild.Text = "Build";
			this.buttonBuild.UseVisualStyleBackColor = true;
			this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
			// 
			// labelOutput
			// 
			this.labelOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelOutput.Location = new System.Drawing.Point(8, 408);
			this.labelOutput.Name = "labelOutput";
			this.labelOutput.Size = new System.Drawing.Size(432, 32);
			this.labelOutput.TabIndex = 3;
			this.labelOutput.Text = "test";
			this.labelOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 442);
			this.Controls.Add(this.labelOutput);
			this.Controls.Add(this.buttonBuild);
			this.Controls.Add(this.buttonInterpret);
			this.Controls.Add(this.textBoxInput);
			this.MinimumSize = new System.Drawing.Size(640, 480);
			this.Name = "MainForm";
			this.Text = "BrainF";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxInput;
		private System.Windows.Forms.Button buttonInterpret;
		private System.Windows.Forms.Button buttonBuild;
		private System.Windows.Forms.Label labelOutput;
	}
}

