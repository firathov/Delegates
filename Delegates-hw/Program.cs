using System;

namespace Delegates_hw
{
    class Ping
    {
        public delegate void Pinger(string text);
        public event Pinger Notify;

        public void PingPrint()
        {
            Notify?.Invoke("Ping received Pong.");
        }
    }

    class Pong
    {
        public delegate void Ponger(string text);
        public event Ponger Notify;

        public void PongPrint()
        {
            Notify?.Invoke("Pong received Ping.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool checkerForFirstSwitch;
            bool checkerForPing;
            bool checkerForPong;
            do
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("If you want to choose Ping press 1, for choosing Pong press 2");
                byte mainNumber = ForNumberCheck();
                switch (mainNumber)
                {
                    case 1:
                        {
                            Ping ping = new Ping();
                            ping.Notify += TextPrinter;
                            ping.PingPrint();

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Do you want to try one more time (for Yes press 1, for No press 2)?");
                            do
                            {
                                byte numberForPing = ForNumberCheck();
                                switch (numberForPing)
                                {
                                    case 1:
                                        {
                                            checkerForFirstSwitch = true;
                                            checkerForPing = false;
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("See ya");
                                            checkerForFirstSwitch = false;
                                            checkerForPing = false;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Wrong symbol, pls try again");
                                            checkerForFirstSwitch = true;
                                            checkerForPing = true;
                                            break;
                                        }
                                }

                            } while (checkerForPing == true) ;
                            break;
                        }
                    case 2:
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Pong pong = new Pong();
                            pong.Notify += TextPrinter;
                            pong.PongPrint();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Do you want to try one more time (for Yes press 1, for No press 2)?");
                            do
                            {
                                byte numberForPong = ForNumberCheck();
                                switch (numberForPong)
                                {
                                    case 1:
                                        {
                                            checkerForFirstSwitch = true;
                                            checkerForPong = false;
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("See ya");
                                            checkerForFirstSwitch = false;
                                            checkerForPong = false;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Wrong symbol, pls try again");
                                            checkerForFirstSwitch = true;
                                            checkerForPong = true;
                                            break;
                                        }
                                }
                            } while (checkerForPong == true);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong symbol, pls try again");

                            checkerForFirstSwitch = true;
                            break;
                        }
                }
            } while (checkerForFirstSwitch == true);

            Console.ReadKey();
        }

        static byte ForNumberCheck()
        {

            for (; ; )
            {
                string checkingNumber = Console.ReadLine();
                if (Byte.TryParse(checkingNumber, out byte number) && number > 0)
                {
                    return number;
                }
                else
                {
                    Console.Write("You wrote the wrong symbol, pls try again: \n");
                }
            }
        }

        static void TextPrinter(string text)
        {
            Console.WriteLine(text);
        }
    }
}
