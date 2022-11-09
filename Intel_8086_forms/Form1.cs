namespace Intel_8086_forms
{
    public partial class Intel8086 : Form
    {
        public Intel8086()
        {
            InitializeComponent();
        }

        private void Intel8086_Load(object sender, EventArgs e)
        {
            InstructionSelectionComboBox.SelectedIndex = 0;
            Register1SelectionComboBox.SelectedIndex = 0;
            Register2SelectionComboBox.SelectedIndex = 0;
        }

        private void AhRegisterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                ActiveControl.Text = "";
        }
    }
}