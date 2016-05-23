using System;
using System.Windows.Forms;
using dCaptcha.Core.Extensions;

namespace dCaptcha.UI.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        // Dont ever convert to string besides for testing
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblCode.Text = "Code: " + dcMain.CaptchaCode.ToStringEx();
            cbDifficulty.SelectedIndex = 0;
        }

        private void btnGenerateNewCode_Click(object sender, EventArgs e)
        {
            dcMain.GenerateNewCode();
            lblCode.Text = "Code: " + dcMain.CaptchaCode.ToStringEx();
        }

        private void cbDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            dcMain.Difficulty = (Controls.dCaptcha.Mode) cbDifficulty.SelectedIndex;
        } 
    }
}   