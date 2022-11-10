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
                    break; //xchg
                case 1:
                    var tmp = firstOperand.GetValue();
                    firstOperand.SetValue(secondOperand.GetValue());
                    secondOperand.SetValue(tmp);
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:
                    // not
                    break;
                case 8:
                    // inc
                    break;
                case 9:
                    // dec
                    break;
                default:

                    break;
            }
        }

        public Register[] GetAllRegisters() => new Register[] { AH, AL, BH, BL, CH, CL, DH, DL };
    }
}
