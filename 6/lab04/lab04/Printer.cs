namespace lab04
{
    class Printer
    {
        public string IAmPrinting(continent someobj)
        {
            return someobj.ToString();
        }
        public string IAmPrinting(island someobj)
        {
            return someobj.ToString();
        }
        public string IAmPrinting(land someobj)
        {
            return someobj.ToString();
        }
        public string IAmPrinting(sea someobj)
        {
            return someobj.ToString();
        }
        public string IAmPrinting(surface someobj)
        {
            return someobj.ToString();
        }
        public string IAmPrinting(water someobj)
        {
            return someobj.ToString();
        }
    }
}
