using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;

namespace Intel_8086_forms;

public class Register
{
    public string Name { get; set; }
    private int? _value = null;

    public bool SetValue(string HexString)
    {
        if (!int.TryParse(HexString, System.Globalization.NumberStyles.HexNumber, null, out int HexNumber))
        {
            _value = HexNumber;
            return true;
        }
        else
            return false;
    }
        
    //public Register(string Name, string ValueString = "")
    //{
    //    if (!int.TryParse(ValueString, System.Globalization.NumberStyles.HexNumber, null, out int HexNumber))
    //        _value = HexNumber;
    //    else
    //        _value = null;

    //    _name = Name;
    //}
}