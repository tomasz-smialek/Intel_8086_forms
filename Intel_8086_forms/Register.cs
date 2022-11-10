namespace Intel_8086_forms;

public class Register
{
    public string? Name { get; set; }
    public int? Value { get; set; }


    public bool ValueCheck(string hexString)
    {
        if (int.TryParse(hexString, System.Globalization.NumberStyles.HexNumber, null, out int hexNumber) && (hexString.Length > 0 && hexString.Length <= 2))
            return true;
        
        return false;
    }

    public static void XCHG(Register first, Register second)
    {
        (first.Value, second.Value) = (second.Value, first.Value);
    }

    public static void MOV(Register first, Register second)
    {
        first.Value = second.Value;
    }

    public static void AND(Register first, Register second)
    {
        first.Value = first.Value & second.Value;
    }
     public static void OR(Register first, Register second)
    {
        first.Value = first.Value | second.Value;
    }
    public static void XOR(Register first, Register second)
    {
        first.Value = first.Value ^ second.Value;
    }
    public static void ADD(Register first, Register second)
    {
        first.Value = first.Value + second.Value;
        if (first.Value > 255)
            first.Value = 255;
    }
    public static void SUB(Register first, Register second)
    {
        first.Value = first.Value - second.Value;
        if (first.Value < 0)
            first.Value = 0;
    }
    public static void INC(Register first)
    {
        first.Value += 1;
        if (first.Value > 255)
            first.Value = 255;
    }
     public static void DEC(Register first)
    {
        first.Value -= 1;
        if (first.Value < 0)
            first.Value = 0;
    }

    public static void NOT(Register first)
    {
        first.Value = 255 - first.Value;
    }
}