﻿using System;
using System.Collections.Generic;
using System.Text;

namespace lab17_18
{
    class Director
    {
        BuilderOfRequest builder;
        public Director(BuilderOfRequest builder)
        {
            this.builder = builder;
        }
        public void Construct()
        {
            builder.BuildAmount();
            builder.BuildType();
            builder.BuildTime();
        }
    }

    abstract class BuilderOfRequest
    {
        public abstract void BuildAmount();
        public abstract void BuildType();
        public abstract void BuildTime();
        public abstract Request GetResult();
    }

    class Request :IFigure  //объект для создания
    {
        public List<object> parts = new List<object>();
        public void Add(string part)
        {
            parts.Add(part);
        }
        public Request() 
        { }
        private Request(List<object> _list)
        {
            parts = _list;
        }
        public void GetInfo()
        {
            Console.WriteLine("Информация , которая находится в клонированном объекте :");
            foreach(var tmp in parts)
                Console.WriteLine(tmp);
        }
        public IFigure Clone()
        {
            return new Request(this.parts);
        }
        
    }

    class ConcreteBuilder : BuilderOfRequest
    {
        Request request = new Request();
        public override void BuildAmount()
        {
            Console.WriteLine("Укажите необходимое количество номеров");
            string tmp = Console.ReadLine();
            request.Add(tmp);
        }
        public override void BuildType()
        {
            Console.WriteLine("Укажите необходимый класс апартаментов");
            string tmp = Console.ReadLine();
            request.Add(tmp);
        }
        public override void BuildTime()
        {
            Console.WriteLine("Укажите время пребывания");
            string tmp=Console.ReadLine();
            request.Add(tmp);
        }
        public override Request GetResult()
        {
            return request;
        }
    }
}
