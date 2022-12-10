namespace Intel_8086_forms;

public class Register : IDataAccess
{
    public string? Name { get; set; }
    public int? Value { get; set; }


    //checking if provided value is inside 00 - FF scope
    public bool ValueCheck(string hexString)
    {
        if (int.TryParse(hexString, System.Globalization.NumberStyles.HexNumber, null, out int hexNumber) && (hexString.Length > 0 && hexString.Length <= 2))
            return true;

        return false;
    }

    //interface methods
    public int GetValue()
    {
        return Value ?? 0;
    }

    public void SetValue(int value)
    {
        Value = value;
    }
}