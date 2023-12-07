using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System;
using System.Windows.Forms;
using EPDM.Interop.epdm;

namespace StandaloneApplicationCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(System.Object sender, System.EventArgs e)
        {
            try
            {

                //Create a file vault interface and log into a vault
                IEdmVault5 vault = new EdmVault5();
                //vault.LoginAuto("ME_Design_Vault", this.Handle.ToInt32());
                vault.LoginAuto("Aditya_Test_2", this.Handle.ToInt32());

                //Get the vault's root folder interface
                string message = "";
                IEdmFile5 file = null;
                IEdmFolder5 folder = null;
                folder = vault.RootFolder;

                //Get position of first file in the root folder
                IEdmPos5 pos = null;
                pos = folder.GetFirstFilePosition();
                if (pos.IsNull)
                {
                    message = ("The root folder of your vault does not contain any files.");
                    MessageBox.Show(message);
                    return;
                }
                message = ("The root folder of your vault contains these files: " + "\n");
                while (!pos.IsNull)
                {
                    file = folder.GetNextFile(pos);
                    message = message + file.Name + "\n";
                }

                //Show the names of all files in the root folder
                MessageBox.Show(message);

            }

            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + "\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}