namespace lab04
{
    class water
    {
        public int volumeOfAllWater;
        public water() { }
        public water(int _volumeOfAllWater)
        {
            volumeOfAllWater = _volumeOfAllWater;
        }
        public override string ToString()
        {
            return $"type: water, volume of all water on the Earth:{volumeOfAllWater}";
        }
    }
}
