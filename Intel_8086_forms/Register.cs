using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;

namespace Intel_8086_forms;

public class Register
{
    private string _name = "";
    private int _value = 0;

    public string Name
    {
        get { return _name; }
    }
    
    public int Value
    {
        get { return _value; }
    }

    public int SetValue(string HexString)
    {
        if (!int.TryParse(HexString, System.Globalization.NumberStyles.HexNumber, null, out int HexNumber))
            return _value = HexNumber;
        else
            throw new Exception("Invalid input");
    }


    //Operations
    public static void Mov(Register register1, Register register2)
    {
        register1._value = register2._value;
    }

    public static void Xchg(Register register1, Register register2)
    {
        (register1._value, register2._value) = (register2._value, register1._value);
    }

    
}