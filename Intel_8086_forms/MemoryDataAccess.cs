namespace Intel_8086_forms 
{
    internal class MemoryDataAccess : IDataAccess
    {
        private readonly Memory _memory;
        private readonly int _address;

        public MemoryDataAccess(Memory memory, int address)
        {
            _memory = memory;
            _address = address;
        }

        public int GetValue()
        {
            return _memory.GetValue(_address);
        }

        public void SetValue(int value)
        {
            _memory.SetValue(_address, (byte)value);
        }
    }
}
