namespace m28_28_task_1
{
    public class Currency
    {
        private string _name;
        private CurrencyType _type;
        private int _value;

        public Currency(string currencyName, int value, CurrencyType currencyType)
        {
            _name = currencyName;
            _value = value;
            _type = currencyType;
        }
        public int Value => _value;

        public CurrencyType Type => _type;

        public string Name => _name;

        public void SetValue(int value)
        {
            _value = value;
        }
    }
}