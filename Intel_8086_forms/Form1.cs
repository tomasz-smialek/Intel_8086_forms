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

        private void InitializeRegisters()
        {
            Register AH = new Register() { Name = "AH" };
            Register AL = new Register() { Name = "AL" };
            Register BH = new Register() { Name = "BH" };
            Register BL = new Register() { Name = "BL" };
            Register CH = new Register() { Name = "CH" };
            Register CL = new Register() { Name = "CL" };
            Register DH = new Register() { Name = "DH" };
            Register DL = new Register() { Name = "AH" };

            var RegisterArray = new Register[] { AH, AL, BH, BL, CH, CL, DH };
            var RegisterTextBoxArray = new TextBox[]
                {
                    AhRegisterTextBox, AlRegisterTextBox,
                    BhRegisterTextBox, BlRegisterTextBox,
                    ChRegisterTextBox, ClRegisterTextBox,
                    DhRegisterTextBox, DlRegisterTextBox
                };
        }

        private void SetRegistersButton_Click(object sender, EventArgs e)
        {

        }
    }
}