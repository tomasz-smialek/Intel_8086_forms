namespace Intel_8086_forms
{
    internal class Memory
    {
        private const int Size = 0x10000;
        private readonly byte[] _data = new byte[Size];

        public void SetValue(int address, byte value)
        {
            _data[CheckAddress(address)] = value;
        }

        public byte GetValue(int address)
        {
            return _data[CheckAddress(address)];
        }

        private static int CheckAddress(int address)
        {
            if (address < 0 || address >= Size)
                throw new ArgumentOutOfRangeException("Memory::CheckAddress(address)");
            return address;
        }
    }
}
