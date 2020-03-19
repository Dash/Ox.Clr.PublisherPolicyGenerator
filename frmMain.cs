using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Ox.Clr.PublisherPolicyGenerator
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private PublisherPolicy policyGen;

		private Version StartVersion()
		{
			Version vOld = new Version(System.Text.RegularExpressions.Regex.Match(txtVersionOld.Text, "^([0-9]+\\.[0-9]+)").Value);
			return vOld;
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			if (this.policyGen == null)
			{
				this.policyGen = new PublisherPolicy();
			}
			AssemblyNameDetails dtls = new AssemblyNameDetails();
			dtls.Name = txtName.Text;
			dtls.PublicKeyToken = txtPublicKeyToken.Text;
			
			dtls.Version = this.StartVersion();
			this.policyGen.Name = dtls;

			FolderBrowserDialog fDiag = new FolderBrowserDialog();
			fDiag.Description = "Select a directory to save your policy files to.";

			bool cancel = false;
			DirectoryInfo dirSave = null;

			do
			{
				if (fDiag.ShowDialog() != DialogResult.OK)
				{
					cancel = true;
					break;
				}
				dirSave = new DirectoryInfo(fDiag.SelectedPath);
			} while (!dirSave.Exists);

			if (!cancel)
			{
				try
				{
					if (this.policyGen.SaveFile(dirSave, txtVersionOld.Text.Trim(), txtVersionNew.Text.Trim()))
					{
						this.ShowMessage("Policy files created.", null, MessageBoxIcon.Information);
					}
				}
				catch (Exception ex)
				{
					this.ShowMessage("Unable to create policy files.", ex, MessageBoxIcon.Error);
				}
				
			}
		}

		private void btnLoadAssembly_Click(object sender, EventArgs e)
		{
			OpenFileDialog assDiag = new OpenFileDialog();
			assDiag.CheckFileExists = true;
			assDiag.DefaultExt = ".dll";
			assDiag.Filter = "Assemblies (*.dll;*.exe)|*.dll;*.exe|All files(*.*)|*.*";
			assDiag.Title = "Load assembly";
			if (assDiag.ShowDialog() == DialogResult.OK)
			{
				this.policyGen = new PublisherPolicy(assDiag.FileName);

				txtName.Text = this.policyGen.Name.Name;
				txtPublicKeyToken.Text = this.policyGen.Name.PublicKeyToken;
				txtVersionNew.Text = this.policyGen.Name.Version.ToString();
				int rev = this.policyGen.Name.Version.Revision - 1;
				if(rev < 0)
					rev = 0;
				txtVersionOld.Text = String.Format("{0}.{1}.0.0-{0}.{1}.{2}.{3}",
					this.policyGen.Name.Version.Major,
					this.policyGen.Name.Version.Minor,
					this.policyGen.Name.Version.Build,
					rev);
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void ShowMessage(string message, Exception e, MessageBoxIcon icon)
		{
			StringBuilder displayMessage = new StringBuilder(message);
			try
			{
				if (e != null)
				{
					displayMessage.AppendFormat("\n\n{0}\n\n{1}\n{2}", e.Message, e.Source, e.StackTrace);
				}
			}
			catch (Exception err)
			{
				// Do nothing
			}

			MessageBox.Show(displayMessage.ToString(), "Publisher Policy Generator", MessageBoxButtons.OK, icon);
		}
	}
}