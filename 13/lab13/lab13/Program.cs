using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
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
    public class Lands
    {
        public List<Land> lands { get; set; }
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
            using (FileStream fs = new FileStream("land.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fs, landSOAP);
            }
            using (FileStream fs = new FileStream("land.soap", FileMode.OpenOrCreate))
            {
                Land newLandSOAP = (Land)soapFormatter.Deserialize(fs);
                Console.WriteLine(newLandSOAP);
            }
            List<Land> lList = new List<Land>();
            lList.Add(landbin);
            lList.Add(landSOAP);
            lList.Add(landXML);
            lList.Add(landJson);
            Lands lands1=new Lands();
            lands1.lands = lList;
            Console.WriteLine("\nСериализация в xml формат");
            XmlSerializer serializer = new XmlSerializer(typeof(Lands));
            using (FileStream fs = new FileStream("lands.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs,lands1);
            }
            Console.WriteLine("Десериализация: ");
            Lands newLands = new Lands();
            using (FileStream fs = new FileStream("lands.xml", FileMode.OpenOrCreate))
            {
                newLands=(Lands)serializer.Deserialize(fs);
            }
            foreach(Land obj in newLands.lands)
            Console.WriteLine(obj.ToString());

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("lands.xml");
            XmlNode? xroot =xdoc.SelectSingleNode("Lands/lands");
            XmlNodeList? nodes = xroot.SelectNodes("*"); //*-выбор всех дочерних ущлов текущего
            Console.WriteLine("XPath: ");
            if (nodes != null)
            {
                foreach (XmlNode node in nodes)
                {
                    Console.WriteLine($"name: {node.Name} inner text: {node.InnerText}");
                }
            }
            XDocument xDoc = new XDocument(new XElement("formulas",
                new XElement("parallelelipiped",
                    new XElement("volume", "abc")),
                new XElement("rectangle",
                    new XElement("square","a*b"),
                    new XElement("perimeter", "2*(a+b)"))
                ));
            xDoc.Save("formulas.xml");
            var tmp = xDoc.Element("formulas")?
                .Elements("parallelelipiped")
                .Where(p => p.Element("volume").Value == "abc")
                .Select(p => p);
            Console.WriteLine("Formula of parallelelipiped's volume:");
            foreach(var ob in tmp)
            Console.WriteLine(ob.Value);
        }
    }
}
