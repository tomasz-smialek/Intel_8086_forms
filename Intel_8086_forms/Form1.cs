using System.ComponentModel;
using System.Globalization;

namespace Intel_8086_forms
{
    public partial class Intel8086 : Form
    {
        Processor Processor = new Processor();

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
            TextBox[] registerTextBoxArray = new TextBox[]
                {
                    AhRegisterTextBox, AlRegisterTextBox,
                    BhRegisterTextBox, BlRegisterTextBox,
                    ChRegisterTextBox, ClRegisterTextBox,
                    DhRegisterTextBox, DlRegisterTextBox
                };

            return (Processor.GetAllRegisters(), registerTextBoxArray);
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
            try
            {
                IDataAccess firstOperand;
                IDataAccess secondOperand;

                if (Register1MemoryAdressCheckBox.Checked)
                {
                    firstOperand = new MemoryDataAccess(Processor.Memory, HexToNumber(Register1TextBox.Text));
                }
                else
                {
                    firstOperand = (Register)Register1SelectionComboBox.SelectedItem;
                }

                if (Register2MemoryAdressCheckBox.Checked)
                {
                    secondOperand = new MemoryDataAccess(Processor.Memory, HexToNumber(Register2TextBox.Text));
                }
                else
                {
                    secondOperand = (Register)Register2SelectionComboBox.SelectedItem;
                }

                Processor.Execute(InstructionSelectionComboBox.SelectedIndex, firstOperand, secondOperand);

                RefreshValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //Hidind second register text box after selecting single argument functions
        private void InstructionSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InstructionSelectionComboBox.SelectedIndex == 7 || InstructionSelectionComboBox.SelectedIndex == 8 || InstructionSelectionComboBox.SelectedIndex == 9)
            {
                Register2SelectionComboBox.Visible = false;
                Register2MemoryAdressCheckBox.Visible = false;
                Register2Label.Visible = false;
            }
            else
            {
                Register2SelectionComboBox.Visible = true;
                Register2MemoryAdressCheckBox.Visible = true;
                Register2Label.Visible = true;
            }
        }

        //Allow to type in memory adress check box
        private void Register1MemoryAdressCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Register1MemoryAdressCheckBox.Checked)
            {
                Register1TextBox.Visible = true;
                Register2MemoryAdressCheckBox.Visible = false;
            }
            else
            {
                Register1TextBox.Visible = false;
                Register2MemoryAdressCheckBox.Visible = true;
            }
        }

        private void Register2MemoryAdressCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Register2MemoryAdressCheckBox.Checked)
            {
                Register2TextBox.Visible = true;
                Register1MemoryAdressCheckBox.Visible = false;
            }
            else
            {
                Register2TextBox.Visible = false;
                Register1MemoryAdressCheckBox.Visible = true;
            }
        }

        public int HexToNumber(string hexString, int maxCharCount = 2)
        {
            if (hexString.Length < 0 || hexString.Length > maxCharCount)
                throw new FormatException($"Maximum character length is {maxCharCount}! Given: {hexString}");

            return int.Parse(hexString, NumberStyles.HexNumber);
        }
    }
}

