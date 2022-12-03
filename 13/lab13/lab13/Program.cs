using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
//using System.Runtime.Serialization.Formatters.Soap;
namespace lab13
{
    interface IInformation
    {
        void DoClone();
    }
    [Serializable]
    abstract public class surface
    {
        public void Surface()
        {
            Console.WriteLine("Вы находитесь на поверхности Земли");
        }
        public abstract void DoClone();
    }

    [Serializable]
    public class Land : surface, IInformation
    {

        [JsonIgnore]
        int Square
        {
            get
            {
                return square;
            }
            set
            {
                square = value;
            }
        }
        [NonSerialized]
        int square;
        public string TypeOfLand { get; set; }
        public Land() { }
        public Land(int _square, string _typeOfLand)
        {
            Square = _square;
            TypeOfLand = _typeOfLand;
        }
        public override void DoClone()
        {
            Console.WriteLine("вызван переопределенный метод из абстрактного класса");
        }
        void IInformation.DoClone()
        {
            Console.WriteLine("вызван метод интерфейса");
        }
        public virtual string ToString()
        {
            return $"square:{this.Square}, type of land: {this.TypeOfLand}";
        }
    }
    class Program
    {
        async static Task Main(string[] args)
        {
            Land landbin = new Land(50505,"Coal");
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("land.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, landbin);
            }
            using (FileStream fs = new FileStream("land.dat", FileMode.OpenOrCreate))
            {
                Land newLandBin = (Land)formatter.Deserialize(fs);
                Console.WriteLine(newLandBin.ToString());
            }
            Land landXML = new Land(4323, "zxc");
            XmlSerializer xser = new XmlSerializer(typeof(Land));
            using (FileStream fs = new FileStream("land.xml", FileMode.OpenOrCreate))
            {
                xser.Serialize(fs, landXML);
            }
            using (FileStream fs = new FileStream("land.xml", FileMode.OpenOrCreate))
            {
                Land newLandXML = xser.Deserialize(fs) as Land;
                Console.WriteLine(newLandXML.ToString());
            }
            Land landJson = new Land(41241, "czx");
            using (FileStream fs = new FileStream("land.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, landJson);
            }
            using (FileStream fs = new FileStream("land.json", FileMode.OpenOrCreate))
            {
                Land? newLandJson = await JsonSerializer.DeserializeAsync<Land>(fs);
                Console.WriteLine(newLandJson.ToString());
            }
            Land landSOAP = new Land(124124124, "cxzc");
            SoapFormatter soapFormatter = new SoapFormatter();
            /*using (FileStream fs = new FileStream("land.soap",FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, landSOAP);
            }
            using (FileStream fs = new FileStream("land.soap",FileMode.OpenOrCreate))
            {
                Land newLandSOAP = (Land)formatter.Deserialize(fs);
                Console.WriteLine(newLandSOAP.ToString());
            }*/

        }
    }
}
