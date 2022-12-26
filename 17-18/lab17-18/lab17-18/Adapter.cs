using System;
using System.Collections.Generic;
using System.Text;

namespace lab17_18
{
    interface ICurrencyEuro
    {
        void PayInEuro();
    }
    
    class Euro : ICurrencyEuro
    {
        public void PayInEuro()
        {
            Console.WriteLine("Номер был оплачен в Евро ");
        }
    }

    class Payer
    {
        public void Pay(ICurrencyEuro currency)
        {
            currency.PayInEuro();
        }
    } 

    interface ICurrencyBYN
    {
        void PayInBYN();
    }

    class BYN : ICurrencyBYN
    {
        public void PayInBYN()
        {
            Console.WriteLine("Номер был оплачен в Белорусских рублях");
        }
    }

    class BYNToEuro :ICurrencyEuro
    {
        BYN byn;
        public BYNToEuro(BYN _byn)
        {
            byn = _byn;
        }
        public void PayInEuro()
        {
            byn.PayInBYN();
        }
    }
}
