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
}