using System;
using System.Collections.Generic;
using System.Text;

namespace lab17_18
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }
    class ScheduleOfHotel
    {
        public void Working()
        {
            Console.WriteLine("Отель открыт");
        }

        public void Closed()
        {
            Console.WriteLine("Отель закрыт");
        }
    }
    class HotelOnCommand : ICommand
    {
        ScheduleOfHotel hotel;
        public HotelOnCommand(ScheduleOfHotel hotelSet)
        {
            hotel = hotelSet;
        }
        public void Execute()
        {
            hotel.Working();
        }
        public void Undo()
        {
            hotel.Closed();
        }
    }
    class Manager
    {
        ICommand command;

        public Manager() { }

        public void SetCommand(ICommand _comand)
        {
            command = _comand;
        }

        public void PressButton()
        {
            command.Execute();
        }
        public void PressUndo()
        {
            command.Undo();
        }
    }
}
