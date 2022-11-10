using System.ComponentModel;
using System.Globalization;

namespace Intel_8086_forms
{
    public partial class Intel8086 : Form
    {
        Register AH = new Register() { Name = "AH" };
        Register AL = new Register() { Name = "AL" };
        Register BH = new Register() { Name = "BH" };
        Register BL = new Register() { Name = "BL" };
        Register CH = new Register() { Name = "CH" };
        Register CL = new Register() { Name = "CL" };
        Register DH = new Register() { Name = "DH" };
        Register DL = new Register() { Name = "DL" };


        public Intel8086()
        {
            InitializeComponent();
        }

        private void Intel8086_Load(object sender, EventArgs e)
        {
            var registerArray1 = InitializeArrays().Item1;
            var registerArray2 = InitializeArrays().Item1;
            Register1SelectionComboBox.DataSource = registerArray1;
            Register1SelectionComboBox.DisplayMember = "Name";

            Register2SelectionComboBox.DataSource = registerArray2;
            Register2SelectionComboBox.DisplayMember = "Name";

            InstructionSelectionComboBox.SelectedIndex = 0;
            Register1SelectionComboBox.SelectedIndex = 0;
            Register2SelectionComboBox.SelectedIndex = 0;
        }
        
        //Initialization of arrays
        private (Register[], TextBox[]) InitializeArrays()
        {
            Register[] registerArray = new Register[] { AH, AL, BH, BL, CH, CL, DH, DL };
            TextBox[] registerTextBoxArray = new TextBox[]
                {
                    AhRegisterTextBox, AlRegisterTextBox,
                    BhRegisterTextBox, BlRegisterTextBox,
                    ChRegisterTextBox, ClRegisterTextBox,
                    DhRegisterTextBox, DlRegisterTextBox
                };

            return (registerArray, registerTextBoxArray);
        }

        //Refreshing register values
        private void RefreshValues()
        {
           for (var i = 0; i < InitializeArrays().Item1.Length; i++)
           {
                InitializeArrays().Item2[i].Text = $"{InitializeArrays().Item1[i].Value:X}";
           }
        }

        //Setting the register values : set button
        private void SetRegistersButton_Click(object sender, EventArgs e)
        {
            var registerArray = InitializeArrays().Item1;
            var registerTextBoxArray = InitializeArrays().Item2;

            for (var i = 0; i < registerArray.Length; i++)
            {
                if (string.IsNullOrEmpty(registerTextBoxArray[i].Text))
                {
                    registerTextBoxArray[i].Text = "";
                    registerArray[i].Value = null;
                }
                else if (registerArray[i].ValueCheck(registerTextBoxArray[i].Text))
                    registerArray[i].Value = int.Parse(registerTextBoxArray[i].Text, NumberStyles.HexNumber);
                else
                {
                    MessageBox.Show($"Invalid {registerArray[i].Name} value. Type in proper hex value");
                    registerTextBoxArray[i].Text = "";
                }
            }

        }

        //clearing all the fields : clear button
        private void ClearRegistersButton_Click(object sender, EventArgs e)
        {
            var registerTextBoxArray = InitializeArrays().Item2;
            var registerArray = InitializeArrays().Item1;
            for (var i = 0; i < registerArray.Length; i++)
            {
                registerTextBoxArray[i].Text = "";
                registerArray[i].Value = null;
            }
        }

        //closing the form : close button
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //adding execution of the instruction : execute button
        private void ExecuteInstructionButton_Click(object sender, EventArgs e)
        {
            Register.XCHG((Register)Register1SelectionComboBox.SelectedItem, (Register)Register2SelectionComboBox.SelectedItem);
            RefreshValues();
        }
    }
}