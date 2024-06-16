using System;
using System.Runtime.Serialization;

namespace FPSBooster
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ResetColors();
            Random rnd = new Random();
            bool enterPressed = false;
            int lastNum = -1;

            List<string> SpeedModes = new List<string>() { "0.00000000039 BTC/24h", "0.0000060 BTC/24h", "0.0090 BTC/24h", "0.20 BTC/24h", "0.60 BTC/24h", "1 BTC/24h", "4 BTC/24h", "13 BTC/24h", "45 BTC/24h", "765 BTC/24h", "2463 BTC/24h", "Back" };
            List<string> PowerModes = new List<string>() { "86 W", "249 W", "361 W", "596 W", "979 W", "1596 W", "2057 W", "3869 W", "6945 W", "10593 W", "59392 W", "Back" };
            List<string> FreqModes = new List<string>() { "3 MHz", "21 MHz", "61 MHz", "133 MHz", "250 MHz", "390 MHz", "550 MHz", "1120 MHz", "2043 MHz", "4039 MHz", "8493 MHz", "Back" };

            List<int> SpeedInts = new List<int>() { 39, 60, 90, 20, 60, 1, 4, 13, 45, 765, 2463 };
            List<string> SpeedStrings = new List<string>() { "0.000000000", "0.00000", "0.00", "0.", "0.", "", "", "", "", "", "" };
            List<int> PowerInts = new List<int>() { 86, 249, 361, 596, 979, 1596, 2057, 3869, 6945, 10593, 59392 };
            List<int> FreqInts = new List<int>() { 3, 21, 61, 133, 250, 390, 550, 1120, 2043, 4039, 8493 };

            string speedStr = "0.000000000";
            int speedD = 39;

            int powerD = 86;

            int temperature = 45;

            int freqD = 550;
            int tempAddD = 1;

            Console.WriteLine("Enter the name of the video card");
            string? gpuName = Console.ReadLine();
            Console.Clear();
            while (true)
            {
                double speed = 0;
                if (speedStr != "")
                {
                    speed = rnd.Next(speedD - 2 * speedD.ToString().Length, speedD + 2 * speedD.ToString().Length);
                }
                else
                {
                    speed = rnd.Next(speedD * 1000 - 20 * speedD.ToString().Length, speedD * 1000 + 20 * speedD.ToString().Length) / 1000.0;
                }
                double freq = rnd.Next(freqD - 5 * freqD.ToString().Length, freqD + 12 * freqD.ToString().Length);
                double power = rnd.Next((powerD - 1) * 10, (powerD + 2) * 10) / 10.0;

                temperature += rnd.Next(powerD.ToString().Length - 3 * powerD.ToString().Length, powerD.ToString().Length + 3 * powerD.ToString().Length);

                Console.SetCursorPosition(0, 0);
                Console.Write("[Miner GPU]                ");
                Console.SetCursorPosition(0, 1);
                Console.Write("GPU: " + gpuName); // Gigabyte GeForce RTX 3050 2 GB GDDR3
                Console.SetCursorPosition(0, 2);
                Console.Write("Frequency: " + freq + " MHz  ");
                Console.SetCursorPosition(0, 3);
                Console.Write("Power: " + power + " W       ");

                Console.SetCursorPosition(0, 4);
                Console.Write("GPU Temperature: " + temperature + " °C ");

                string speedText = "Speed: " + speedStr + speed + " BTC/24h ";
                Console.SetCursorPosition(0, 5);
                for (int n = 0; speedText.Length > n; n++)
                    Console.Write("=");
                Console.SetCursorPosition(0, 6);
                Console.Write(speedText);
                Console.SetCursorPosition(0, 8);
                Console.Write("Program by dleuiajs (tiktok: @eeglebguy)");

                //Console.SetCursorPosition(0, 7);
                //Console.Write("Program by dleuiajs (tiktok: @eeglebguy)");

                if (Console.KeyAvailable) // если игрок куда-то нажал
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.E)
                    {
                        string fsbDString = speedD.ToString("N1");
                        double fpsDouble = speedD;

                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.Write("[Miner Settings]");
                        Console.SetCursorPosition(0, 1);
                        Console.Write("Speed: " + speedStr + speedD + " BTC/24h  ");
                        Console.SetCursorPosition(0, 2);
                        Console.Write("Frequency: " + freqD + " MHz ");
                        Console.SetCursorPosition(0, 3);
                        Console.Write("Power: " + powerD + " W ");
                        while (true)
                        {
                            Selector("", new List<string>() { "Miner Configuration", "Enter Wallet", "Back" }, 5);
                            if (enterPressed)
                            {
                                enterPressed = false;
                                if (lastNum == 0)
                                {
                                    Selector("[Miner Configuration]", new List<string>() { "Speed", "Frequency", "Power", "Back" }, 1);
                                    if (lastNum == 0)
                                    {
                                        Selector("Select Speed:", SpeedModes, 1);
                                        if (lastNum < 11)
                                        {
                                            speedD = SpeedInts[lastNum];
                                            speedStr = SpeedStrings[lastNum];
                                            Console.Clear();
                                            Console.WriteLine("Applying Settings...");
                                            break;
                                        }
                                        else if (lastNum == 11)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Going Back...");
                                            break;
                                        }
                                    }
                                    else if (lastNum == 1)
                                    {
                                        Selector("Select Frequency:", FreqModes, 1);
                                        if (lastNum < 11)
                                        {
                                            freqD = FreqInts[lastNum];
                                            Console.Clear();
                                            Console.WriteLine("Applying Settings...");
                                            break;
                                        }
                                        else if (lastNum == 11)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Going Back...");
                                            break;
                                        }
                                    }
                                    else if (lastNum == 2)
                                    {
                                        Selector("Select Power:", PowerModes, 1);
                                        if (lastNum < 11)
                                        {
                                            powerD = PowerInts[lastNum];
                                            Console.Clear();
                                            Console.WriteLine("Applying Settings...");
                                            break;
                                        }
                                        else if (lastNum == 11)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Going Back...");
                                            break;
                                        }
                                    }
                                    else if (lastNum >= 3)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                }
                                else if (lastNum == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Биток отправлен!");
                                    break;
                                }
                                else if (lastNum == 2)
                                {
                                    Console.Clear();
                                    break;
                                }
                            }

                        }
                    }
                }
                Thread.Sleep(1000);
            }

            void Selector(string firstText, List<string> texts, int row)
            {
                if (firstText != "")
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, row - 1);
                    Console.Write(firstText);
                }
                int n = row;
                foreach (string text in texts)
                {
                    Console.SetCursorPosition(0, n);
                    Console.Write(text);
                    n++;
                }
                Console.SetCursorPosition(0, row);
                int y = row;
                int yBuffer = row;
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(texts[y - row]);
                ResetColors();
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        lastNum = (y - row);
                        enterPressed = true;
                        break;
                    }
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        yBuffer = y;
                        if (y == row)
                            y = row + texts.Count - 1;
                        else
                            y--;
                        Console.SetCursorPosition(0, y);
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        yBuffer = y;
                        if (y == row + texts.Count - 1)
                            y = row;
                        else
                            y++;
                        Console.SetCursorPosition(0, y);
                    }
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(texts[y - row]);
                    ResetColors();
                    Console.SetCursorPosition(0, yBuffer);
                    Console.Write(texts[yBuffer - row]);
                    Console.SetCursorPosition(0, y);

                }
            }
        }

        static void ResetColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}