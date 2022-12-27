using System;
using System.Collections.Generic;
using System.Text;

namespace lab17_18
{
    interface IMoney
    {
        void Returning(PaymentState payment);
        void Payment(PaymentState payment);
    }
    class PaymentState
    {
        public IMoney State { get; set; }
        public PaymentState(IMoney ms)
        {
            State = ms;
        }
        public void Returning()
        {
            State.Returning(this);
        }
        public void Payment()
        {
            State.Payment(this);
        }
    }
    class WaitingForPayment:IMoney
    {
        public void Returning(PaymentState payment)
        {
            Console.WriteLine("Ожидается оплата");
        }
        public void Payment(PaymentState payment)
        {
            Console.WriteLine("Оплата прошла успешно");
            payment.State = new Paying();
        }
    }

    class Paying:IMoney
    {
        public void Returning(PaymentState payment)
        {
            Console.WriteLine("Начало возврата средств");
        }
        public void Payment(PaymentState payment)
        {
            Console.WriteLine("Возврат средств завершен ");
            payment.State = new WaitingForPayment();
        }
    }
}
