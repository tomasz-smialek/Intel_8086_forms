namespace Intel_8086_forms
{
    internal class Processor
    {
        Register AH = new Register() { Name = "AH" };
        Register AL = new Register() { Name = "AL" };
        Register BH = new Register() { Name = "BH" };
        Register BL = new Register() { Name = "BL" };
        Register CH = new Register() { Name = "CH" };
        Register CL = new Register() { Name = "CL" };
        Register DH = new Register() { Name = "DH" };
        Register DL = new Register() { Name = "DL" };

        public Memory Memory { get; private set; } = new();

        public void Execute(int opcode, IDataAccess firstOperand, IDataAccess secondOperand)
        {
            switch (opcode)
            {
                case 0: // mov
                    firstOperand.SetValue(secondOperand.GetValue());
                    break; 
                case 1: //xchg
                    var tmp = firstOperand.GetValue();
                    firstOperand.SetValue(secondOperand.GetValue());
                    secondOperand.SetValue(tmp);
                    break;
                case 2: //and
                    firstOperand.SetValue(firstOperand.GetValue() & secondOperand.GetValue());
                    break;
                case 3: //or
                     firstOperand.SetValue(firstOperand.GetValue() | secondOperand.GetValue());
                    break;
                case 4: //xor
                     firstOperand.SetValue(firstOperand.GetValue() ^ secondOperand.GetValue());
                    break;
                case 5: //add
                    firstOperand.SetValue(firstOperand.GetValue() + secondOperand.GetValue());
                    if (firstOperand.GetValue() > 255)
                        firstOperand.SetValue(0);
                    break;
                case 6: //sub
                    firstOperand.SetValue(firstOperand.GetValue() - secondOperand.GetValue());
                    if (firstOperand.GetValue() < 0)
                        firstOperand.SetValue(0);
                    break;
                case 7: // not
                    firstOperand.SetValue(255 - firstOperand.GetValue()); 
                    break;
                case 8: // inc
                    firstOperand.SetValue(firstOperand.GetValue() + 1); 
                    if (firstOperand.GetValue() > 255)
                        firstOperand.SetValue(0);
                    break;
                case 9: // dec
                    firstOperand.SetValue(firstOperand.GetValue() - 1); 
                    if (firstOperand.GetValue() < 0)
                        firstOperand.SetValue(0);
                    break;
                default:
                    MessageBox.Show("Something went wrong");
                    break;
            }
        }

        public Register[] GetAllRegisters() => new Register[] { AH, AL, BH, BL, CH, CL, DH, DL };
    }
}
