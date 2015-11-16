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
			this.textBoxCode = new System.Windows.Forms.TextBox();
			this.buttonInterpret = new System.Windows.Forms.Button();
			this.buttonBuild = new System.Windows.Forms.Button();
			this.labelOutput = new System.Windows.Forms.Label();
			this.textBoxInput = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBoxCode
			// 
			this.textBoxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCode.Location = new System.Drawing.Point(8, 8);
			this.textBoxCode.Multiline = true;
			this.textBoxCode.Name = "textBoxCode";
			this.textBoxCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxCode.Size = new System.Drawing.Size(608, 360);
			this.textBoxCode.TabIndex = 0;
			// 
			// buttonInterpret
			// 
			this.buttonInterpret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonInterpret.Location = new System.Drawing.Point(448, 400);
			this.buttonInterpret.Name = "buttonInterpret";
			this.buttonInterpret.Size = new System.Drawing.Size(80, 32);
			this.buttonInterpret.TabIndex = 2;
			this.buttonInterpret.Text = "Interpret";
			this.buttonInterpret.UseVisualStyleBackColor = true;
			this.buttonInterpret.Click += new System.EventHandler(this.buttonInterpret_Click);
			// 
			// buttonBuild
			// 
			this.buttonBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBuild.Location = new System.Drawing.Point(536, 400);
			this.buttonBuild.Name = "buttonBuild";
			this.buttonBuild.Size = new System.Drawing.Size(80, 32);
			this.buttonBuild.TabIndex = 3;
			this.buttonBuild.Text = "Build";
			this.buttonBuild.UseVisualStyleBackColor = true;
			this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
			// 
			// labelOutput
			// 
			this.labelOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelOutput.Location = new System.Drawing.Point(8, 400);
			this.labelOutput.Name = "labelOutput";
			this.labelOutput.Size = new System.Drawing.Size(432, 32);
			this.labelOutput.TabIndex = 4;
			this.labelOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxInput
			// 
			this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxInput.Location = new System.Drawing.Point(48, 376);
			this.textBoxInput.Name = "textBoxInput";
			this.textBoxInput.Size = new System.Drawing.Size(568, 20);
			this.textBoxInput.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 376);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Input:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 442);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxInput);
			this.Controls.Add(this.labelOutput);
			this.Controls.Add(this.buttonBuild);
			this.Controls.Add(this.buttonInterpret);
			this.Controls.Add(this.textBoxCode);
			this.MinimumSize = new System.Drawing.Size(640, 480);
			this.Name = "MainForm";
			this.Text = "BrainF";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxCode;
		private System.Windows.Forms.Button buttonInterpret;
		private System.Windows.Forms.Button buttonBuild;
		private System.Windows.Forms.Label labelOutput;
		private System.Windows.Forms.TextBox textBoxInput;
		private System.Windows.Forms.Label label1;
	}
}

