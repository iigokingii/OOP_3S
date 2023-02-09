namespace lab04
{
    class state : continent
    {
        public state() { }
        public state(string _continent, int _square, string _typeOfLand, string _stateName)
        {
            Square = _square;
            StateName = _stateName;
            name = _continent;
            TypeOfLand = _typeOfLand;
        }
        public string StateName;
        public override string ToString()
        {
            return $"Type: state, name: {StateName}, type of land:{TypeOfLand}, square:{Square}, name of continent:{name}";
        }
    }
}
