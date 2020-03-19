using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace Ox.Clr.PublisherPolicyGenerator
{
	/// <summary>
	/// Identification details of an assembly
	/// </summary>
	internal struct AssemblyNameDetails
	{
		public string Name;
		public string PublicKeyToken;
		public Version Version;
	}

	/// <summary>
	/// Publisher Policy Generator Class
	/// </summary>
	internal class PublisherPolicy
	{	
		/// <summary>
		/// Assembly name details
		/// </summary>
		protected AssemblyNameDetails _nameDetails;

		/// <summary>
		/// Assembly name details
		/// </summary>
		public AssemblyNameDetails Name
		{
			get { return this._nameDetails; }
			set { this._nameDetails = value; }
		}

		/// <summary>
		/// Create object based on existing assembly information
		/// </summary>
		/// <param name="assemblyPath">Name of assembly to load</param>
		public PublisherPolicy(string assemblyPath)
		{
			this._nameDetails = this.GetKey(assemblyPath);
		}

		/// <summary>
		/// Inject properties to build a new policy
		/// </summary>
		/// <param name="name">Assembly name</param>
		/// <param name="publicKeyToken">Public key token</param>
		/// <param name="version">Assembly version</param>
		public PublisherPolicy(string name, string publicKeyToken, string version)
		{
			this._nameDetails = new AssemblyNameDetails();
			this._nameDetails.Name = name;
			this._nameDetails.PublicKeyToken = publicKeyToken;
			this._nameDetails.Version = new Version(version);
		}

		public PublisherPolicy()
		{
			this._nameDetails = new AssemblyNameDetails();
		}

		/// <summary>
		/// Creates a policy file and linked assembly DLL
		/// </summary>
		/// <param name="saveDir">Directory to save files into</param>
		/// <param name="oldVersion">Version to replace</param>
		/// <param name="newVersion">New version number</param>
		/// <returns>Success/Failure</returns>
		public bool SaveFile(DirectoryInfo saveDir, string oldVersion, string newVersion)
		{
			if (this.SaveXmlFile(saveDir, oldVersion, newVersion))
			{
				if (this.CreateLinkedAssembly(saveDir))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Loads assembly identification information
		/// </summary>
		/// <param name="ass">Assembly full path name</param>
		/// <returns>Name details and version</returns>
		protected AssemblyNameDetails GetKey(string ass)
		{
			AssemblyNameDetails dtls = new AssemblyNameDetails();

			AssemblyName nm = Assembly.LoadFrom(ass).GetName();
			byte[] keyToken = nm.GetPublicKeyToken();
			dtls.Name = nm.Name;
			dtls.PublicKeyToken = this.KeyToString(keyToken);
			dtls.Version = nm.Version;

			return dtls;
		}

		/// <summary>
		/// Converts a PublicKeyToken into human readable hex string
		/// </summary>
		/// <param name="keyToken">byte array key</param>
		/// <returns>hex string</returns>
		protected string KeyToString(byte[] keyToken)
		{
			StringBuilder sbToken = new StringBuilder();
			foreach (byte k in keyToken)
			{
				sbToken.Append(String.Format("{0:x2}", k).ToLower());
			}
			return sbToken.ToString().ToLower();
		}

		/// <summary>
		/// Save XML Policy file
		/// </summary>
		/// <param name="saveDirectory">Directory to save to</param>
		/// <param name="oldVersion">Old version</param>
		/// <param name="newVersion">New version</param>
		/// <returns>Success or failure</returns>
		protected bool SaveXmlFile(DirectoryInfo saveDirectory, string oldVersion, string newVersion)
		{
			string filename = string.Format(@"{0}\policy.{1}.{2}.{3}.xml",
				saveDirectory.FullName,
				this._nameDetails.Version.Major,
				this._nameDetails.Version.Minor,
				this._nameDetails.Name);

			bool writeFile = true;

			if (File.Exists(filename))
			{
				if (MessageBox.Show("Publiser Policy file already exists, do you want to overwrite?",
					"Publisher Policy Generator",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question,
					MessageBoxDefaultButton.Button1) == DialogResult.No)
				{
					writeFile = false;
				}
			}

			if (writeFile)
			{
				using (XmlTextWriter tw = new XmlTextWriter(filename, null))
				{
					tw.Formatting = Formatting.Indented;
					tw.IndentChar = Convert.ToChar(9);

					tw.WriteStartElement("configuration");
					tw.WriteStartElement("configSections");
					tw.WriteStartElement("section");
					tw.WriteAttributeString("name", "runtime");
					tw.WriteAttributeString("type", "System.Configuration.IgnoreSection, System.Configuration, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
					tw.WriteAttributeString("allowLocation", "false");
					tw.WriteEndElement();
					tw.WriteEndElement();
					tw.WriteStartElement("runtime");
					tw.WriteStartElement("assemblyBinding");
					tw.WriteAttributeString("xmlns", "urn:schemas-microsoft-com:asm.v1");
					tw.WriteStartElement("dependentAssembly");
					tw.WriteStartElement("assemblyIdentity");
					tw.WriteAttributeString("name", this._nameDetails.Name);
					tw.WriteAttributeString("publicKeyToken", this._nameDetails.PublicKeyToken);
					tw.WriteEndElement();
					tw.WriteStartElement("bindingRedirect");
					tw.WriteAttributeString("oldVersion", oldVersion);
					tw.WriteAttributeString("newVersion", newVersion);
					tw.WriteEndElement();
					tw.WriteEndElement();
					tw.WriteEndElement();
					tw.WriteEndElement();
					tw.WriteEndElement();
					tw.Flush();
					tw.Close();
				}
				return true;
			}
			return false;
		}

		/// <summary>
		/// Creates DLL assembly linked to policy file
		/// </summary>
		/// <param name="saveDirectory">Directory to save to</param>
		/// <returns>Success or failure</returns>
		protected bool CreateLinkedAssembly(DirectoryInfo saveDirectory)
		{
			OpenFileDialog keyDiag = new OpenFileDialog();
			keyDiag.AddExtension = true;
			keyDiag.CheckFileExists = true;
			keyDiag.DefaultExt = ".snk";
			keyDiag.Filter = "Key file (*.snk)|*.snk|All files (*.*)|*.*";
			keyDiag.Title = "Load key file";
			if (keyDiag.ShowDialog() == DialogResult.OK)
			{
				StrongNameKeyPair kp = null;

				using (FileStream fs = new FileStream(keyDiag.FileName, FileMode.Open, FileAccess.Read))
				{
					kp = new StrongNameKeyPair(fs);
					fs.Close();
				}

				string filename = string.Format("policy.{0}.{1}.{2}",
					this._nameDetails.Version.Major,
					this._nameDetails.Version.Minor,
					this._nameDetails.Name);
				AssemblyName assName = new AssemblyName(filename);
				assName.KeyPair = kp;
				assName.Version = new Version(this._nameDetails.Version.Major, this._nameDetails.Version.Minor);

				AssemblyBuilder build = System.Threading.Thread.GetDomain().DefineDynamicAssembly(assName, AssemblyBuilderAccess.Save, saveDirectory.FullName);
				if (this.KeyToString(build.GetName().GetPublicKeyToken()) != this._nameDetails.PublicKeyToken)
				{
					throw new System.Security.SecurityException("Provided key token does not match original assembly.");
				}
				build.AddResourceFile(filename + ".xml", filename + ".xml");
				build.Save(filename + ".dll");
				return true;
			}
			return false;
		}
	}
}