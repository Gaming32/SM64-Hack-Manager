using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SM64_Hack_Manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            OpenFileDialog UJ = new OpenFileDialog();

            UJ.Filter = "SM64 ROMS (Z64, N64, or BIN)|*.Z64;*.N64;*.BIN";
            UJ.Multiselect = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!System.IO.File.Exists(Properties.Settings.Default.Sm64Path))
            {
                DialogResult message = MessageBox.Show(@"Please specify the path of your SM64 ROM
            YES = Specify ROM
            NO = Get ROM
            CANCEL = Quit the Application", "ROM Not Found", MessageBoxButtons.YesNoCancel);

                if (message == DialogResult.Cancel | message == DialogResult.None)
                    Application.Exit();
                else if (message == DialogResult.Yes)
                {
                    UJ.ShowDialog();
                    Properties.Settings.Default.Sm64Path = UJ.FileName;
                    UJ.Dispose();
                    Application.Run(new Form1());
                }
                else if (message == DialogResult.No)
                {
                    System.Diagnostics.Process.Start("https://mega.nz/#!XiA1CY4D!z5RQAqWQbs9CwxBCQexgqfXc47J8vNYVObKgpW0vPXE");
                    UJ.ShowDialog();
                    Properties.Settings.Default.Sm64Path = UJ.FileName;
                    UJ.Dispose();
                    Application.Run(new Form1());
                }
            }
        }
    }
}
