namespace Ox.Clr.PublisherPolicyGenerator
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
			this.btnCreate = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblAssName = new System.Windows.Forms.Label();
			this.lblAssKeyToken = new System.Windows.Forms.Label();
			this.txtPublicKeyToken = new System.Windows.Forms.TextBox();
			this.btnLoadAssembly = new System.Windows.Forms.Button();
			this.txtVersionOld = new System.Windows.Forms.TextBox();
			this.txtVersionNew = new System.Windows.Forms.TextBox();
			this.boxAssembly = new System.Windows.Forms.GroupBox();
			this.boxVersion = new System.Windows.Forms.GroupBox();
			this.lblVersionOld = new System.Windows.Forms.Label();
			this.lblVersionNew = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.boxAssembly.SuspendLayout();
			this.boxVersion.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(12, 200);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(75, 23);
			this.btnCreate.TabIndex = 0;
			this.btnCreate.Text = "&Create...";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(104, 19);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(194, 20);
			this.txtName.TabIndex = 1;
			// 
			// lblAssName
			// 
			this.lblAssName.AutoSize = true;
			this.lblAssName.Location = new System.Drawing.Point(6, 22);
			this.lblAssName.Name = "lblAssName";
			this.lblAssName.Size = new System.Drawing.Size(38, 13);
			this.lblAssName.TabIndex = 2;
			this.lblAssName.Text = "Name:";
			// 
			// lblAssKeyToken
			// 
			this.lblAssKeyToken.AutoSize = true;
			this.lblAssKeyToken.Location = new System.Drawing.Point(6, 48);
			this.lblAssKeyToken.Name = "lblAssKeyToken";
			this.lblAssKeyToken.Size = new System.Drawing.Size(94, 13);
			this.lblAssKeyToken.TabIndex = 3;
			this.lblAssKeyToken.Text = "Public Key Token:";
			// 
			// txtPublicKeyToken
			// 
			this.txtPublicKeyToken.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPublicKeyToken.Location = new System.Drawing.Point(104, 45);
			this.txtPublicKeyToken.Name = "txtPublicKeyToken";
			this.txtPublicKeyToken.Size = new System.Drawing.Size(194, 20);
			this.txtPublicKeyToken.TabIndex = 4;
			// 
			// btnLoadAssembly
			// 
			this.btnLoadAssembly.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLoadAssembly.Location = new System.Drawing.Point(160, 71);
			this.btnLoadAssembly.Name = "btnLoadAssembly";
			this.btnLoadAssembly.Size = new System.Drawing.Size(138, 23);
			this.btnLoadAssembly.TabIndex = 5;
			this.btnLoadAssembly.Text = "&Load From Assembly...";
			this.btnLoadAssembly.UseVisualStyleBackColor = true;
			this.btnLoadAssembly.Click += new System.EventHandler(this.btnLoadAssembly_Click);
			// 
			// txtVersionOld
			// 
			this.txtVersionOld.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtVersionOld.Location = new System.Drawing.Point(104, 19);
			this.txtVersionOld.Name = "txtVersionOld";
			this.txtVersionOld.Size = new System.Drawing.Size(194, 20);
			this.txtVersionOld.TabIndex = 6;
			// 
			// txtVersionNew
			// 
			this.txtVersionNew.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtVersionNew.Location = new System.Drawing.Point(104, 45);
			this.txtVersionNew.Name = "txtVersionNew";
			this.txtVersionNew.Size = new System.Drawing.Size(194, 20);
			this.txtVersionNew.TabIndex = 7;
			// 
			// boxAssembly
			// 
			this.boxAssembly.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.boxAssembly.Controls.Add(this.lblAssName);
			this.boxAssembly.Controls.Add(this.txtName);
			this.boxAssembly.Controls.Add(this.lblAssKeyToken);
			this.boxAssembly.Controls.Add(this.btnLoadAssembly);
			this.boxAssembly.Controls.Add(this.txtPublicKeyToken);
			this.boxAssembly.Location = new System.Drawing.Point(12, 12);
			this.boxAssembly.Name = "boxAssembly";
			this.boxAssembly.Size = new System.Drawing.Size(304, 103);
			this.boxAssembly.TabIndex = 8;
			this.boxAssembly.TabStop = false;
			this.boxAssembly.Text = "Assembly Details";
			// 
			// boxVersion
			// 
			this.boxVersion.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.boxVersion.Controls.Add(this.lblVersionNew);
			this.boxVersion.Controls.Add(this.lblVersionOld);
			this.boxVersion.Controls.Add(this.txtVersionOld);
			this.boxVersion.Controls.Add(this.txtVersionNew);
			this.boxVersion.Location = new System.Drawing.Point(12, 121);
			this.boxVersion.Name = "boxVersion";
			this.boxVersion.Size = new System.Drawing.Size(304, 73);
			this.boxVersion.TabIndex = 9;
			this.boxVersion.TabStop = false;
			this.boxVersion.Text = "Version Details";
			// 
			// lblVersionOld
			// 
			this.lblVersionOld.AutoSize = true;
			this.lblVersionOld.Location = new System.Drawing.Point(6, 22);
			this.lblVersionOld.Name = "lblVersionOld";
			this.lblVersionOld.Size = new System.Drawing.Size(63, 13);
			this.lblVersionOld.TabIndex = 8;
			this.lblVersionOld.Text = "Old version:";
			// 
			// lblVersionNew
			// 
			this.lblVersionNew.AutoSize = true;
			this.lblVersionNew.Location = new System.Drawing.Point(6, 48);
			this.lblVersionNew.Name = "lblVersionNew";
			this.lblVersionNew.Size = new System.Drawing.Size(69, 13);
			this.lblVersionNew.TabIndex = 9;
			this.lblVersionNew.Text = "New version:";
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(241, 200);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 10;
			this.btnClose.Text = "E&xit";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(326, 232);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.boxVersion);
			this.Controls.Add(this.boxAssembly);
			this.Controls.Add(this.btnCreate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(332, 259);
			this.MinimumSize = new System.Drawing.Size(332, 259);
			this.Name = "frmMain";
			this.Text = "Publisher Policy Generator";
			this.boxAssembly.ResumeLayout(false);
			this.boxAssembly.PerformLayout();
			this.boxVersion.ResumeLayout(false);
			this.boxVersion.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblAssName;
		private System.Windows.Forms.Label lblAssKeyToken;
		private System.Windows.Forms.TextBox txtPublicKeyToken;
		private System.Windows.Forms.Button btnLoadAssembly;
		private System.Windows.Forms.TextBox txtVersionOld;
		private System.Windows.Forms.TextBox txtVersionNew;
		private System.Windows.Forms.GroupBox boxAssembly;
		private System.Windows.Forms.GroupBox boxVersion;
		private System.Windows.Forms.Label lblVersionNew;
		private System.Windows.Forms.Label lblVersionOld;
		private System.Windows.Forms.Button btnClose;
	}
}

