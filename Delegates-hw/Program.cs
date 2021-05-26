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
            bool checkerForFirstSwitch = true;
            bool player1 = true;
            bool player2 = true;
            bool player3 = true;
            bool player4 = true;
            do
            {
                Console.WriteLine("\nChoose the player (1-2-3-4)");
                byte mainNumber = ForNumberCheck();
                switch (mainNumber)
                {
                    case 1:
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            if (player1 == false || player2 == false)
                            {
                                Console.WriteLine("This player is in the same team with 2nd one. Pls choose 3rd or 4th one");
                                checkerForFirstSwitch = true;
                                break;
                            }
                            Ping ping = new Ping();
                            ping.Notify += TextPrinter;
                            ping.PingPrint();
                            player1 = false;
                            player3 = true;
                            player4 = true;
                            
                            break;
                        }
                    case 2:
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            if (player1 == false || player2 == false)
                            {
                                Console.WriteLine("This player is in the same team with 1st one. Pls choose 3rd or 4th one");
                                checkerForFirstSwitch = true;
                                break;
                            }
                            Ping ping2 = new Ping();
                            ping2.Notify += TextPrinter;
                            ping2.PingPrint();
                            player2 = false;
                            player3 = true;
                            player4 = true;
                            
                            break;
                        }
                    case 3:
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            if (player3 == false || player4 == false)
                            {
                                Console.WriteLine("This player is in the same team with 4th one. Pls choose 1st or 2nd one");
                                checkerForFirstSwitch = true;
                                break;
                            }
                            Pong pong = new Pong();
                            pong.Notify += TextPrinter;
                            pong.PongPrint();
                            player3 = false;
                            player1 = true;
                            player2 = true;
                            
                            break;
                        }
                    case 4:
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            if (player4 == false || player3 == false)
                            {
                                Console.WriteLine("This player is in the same team with 3rd one. Pls choose 1st or 2nd one");
                                checkerForFirstSwitch = true;
                                break;
                            }
                            
                            Pong pong2 = new Pong();
                            pong2.Notify += TextPrinter;
                            pong2.PongPrint();
                            player4 = false;
                            player1 = true;
                            player2 = true;

                            break;
                        }
                    case 5:
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("See yaa");
                            checkerForFirstSwitch = false;
                            break;
                        }
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
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
