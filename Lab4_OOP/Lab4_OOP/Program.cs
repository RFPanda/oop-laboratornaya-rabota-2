using System;

namespace Lab4_OOP
{
    class NewEventArgs
    {
        int firstRes;
        public int fResource
        {
            get
            {
                return firstRes;
            }
            set
            {
                firstRes = value;
            }
        }

        int secondRes;
        public int sResource
        {
            get
            {
                return secondRes;
            }
            set
            {
                secondRes = value;
            }
        }

        int thirdRes;
        public int tResource
        {
            get
            {
                return thirdRes;
            }
            set
            {
                thirdRes = value;
            }
        }
    } // 3 приемника

    class GenEvent // Вывод приемников
    {
        public delegate void OnResourceHandler(object source, NewEventArgs e);
        public event OnResourceHandler NewEventHandler;

        public void EventGeneration(NewEventArgs e)
        {
            if (NewEventHandler != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                NewEventHandler(this, e);
                Console.WriteLine("Приемник {0} может выделить {1} ед. ресурса", 1, e.fResource);
                Console.WriteLine("Приемник {0} может выделить {1} ед. ресурса", 2, e.sResource);
                Console.WriteLine("Приемник {0} может выделить {1} ед. ресурса", 3, e.tResource);
            }
        }
    }

    class Receiver // Обработчик событий
    {
        int number;
        int res;

        public void OnResHandler(object sender, NewEventArgs e)
        {
            switch (number)
            {
                case 1:
                    e.fResource = res;
                    break;
                case 2:
                    e.sResource = res;
                    break;
                case 3:
                    e.tResource = res;
                    break;
            }
        }

        public Receiver(int recNumber, int res, GenEvent generator)
        {
            number = recNumber;
            this.res = res;
            generator.NewEventHandler += new GenEvent.OnResourceHandler(OnResHandler);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GenEvent gnEvent = new GenEvent();

            NewEventArgs ev = new NewEventArgs();

            Receiver firstRec = new Receiver(1, 521, gnEvent);  // ресурсы 1
            Receiver secondRec = new Receiver(2, 21, gnEvent);  // ресурсы 2
            Receiver thirdRec = new Receiver(3, 7777, gnEvent); // ресурсы 3

            gnEvent.EventGeneration(ev);

          // Console.ReadKey(true);
        }
    }
}
