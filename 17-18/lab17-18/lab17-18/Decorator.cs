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
