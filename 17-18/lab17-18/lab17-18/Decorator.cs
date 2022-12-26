using System;
using System.Collections.Generic;
using System.Text;

namespace lab17_18
{
    abstract class Room
    {
        public string Location { get; protected set; }
        public Room(string _location)
        {
            Location = _location;
        }
        public abstract int GetFinalCoast();
    }

    class CentralLocation : Room
    {
        public CentralLocation() : base("В центре")
        { }
        public override int GetFinalCoast()
        {
            return 400;
        }
    }
    class NearSea : Room
    {
        public NearSea() : base("Возле моря")
        { }
        public override int GetFinalCoast()
        {
            return 600;
        }
    }

    abstract class RoomDecorator : Room
    {
        protected Room room;
        public RoomDecorator(string name, Room room) : base(name)
        {
            this.room = room;
        }
    }

    class WithDustRoom : RoomDecorator
    {
        public WithDustRoom(Room room) : base(room.Location + "c комнатой для грязи", room)
        { }
        public override int GetFinalCoast()
        {
            return room.GetFinalCoast() + 999;
        }
    }
}



    /*
     class Program
{
    static void Main(string[] args)
    {
        Pizza pizza1 = new ItalianPizza();
        pizza1 = new TomatoPizza(pizza1); // итальянская пицца с томатами
        Console.WriteLine("Название: {0}", pizza1.Name);
        Console.WriteLine("Цена: {0}", pizza1.GetCost());
 
        Pizza pizza2 = new ItalianPizza();
        pizza2 = new CheesePizza(pizza2);// итальянская пиццы с сыром
        Console.WriteLine("Название: {0}", pizza2.Name);
        Console.WriteLine("Цена: {0}", pizza2.GetCost());
 
        Pizza pizza3 = new BulgerianPizza();
        pizza3 = new TomatoPizza(pizza3);
        pizza3 = new CheesePizza(pizza3);// болгарская пиццы с томатами и сыром
        Console.WriteLine("Название: {0}", pizza3.Name);
        Console.WriteLine("Цена: {0}", pizza3.GetCost());
 
        Console.ReadLine();
    }
}
 





}
    */
