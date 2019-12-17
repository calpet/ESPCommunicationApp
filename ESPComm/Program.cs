using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Xml;

namespace ESPComm
{
    class Program
    {
        static void Main(string[] args)
        {
            var con = new ConnectToMaster {BaudRate = 9600, PortName = "COM5"};
            con.OpenConnection(con.BaudRate, con.PortName);

            //Testscript vanaf hier.
            bool inf = true;

            Console.WriteLine("\nMaster aangesloten op " + con.PortName);

            while (inf)
            {


                Console.WriteLine("\nMaak een keuze:\n1. Licht aansturen.\n2. Deur sluiten.\n");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("\nWat wilt u met het licht doen?\n1. Licht aanzetten\n2.Licht uitzetten\n");
                    string incoming = Console.ReadLine();
                    switch (incoming)
                    {
                        case "1":
                            con.Write("1");
                            Console.WriteLine("Lamp aan.\n");
                            break;

                        case "2":
                            con.Write("0");
                            Console.WriteLine("Lamp uit.\n");
                            break;
                        default:
                            Console.WriteLine("Maak een keuze.\n");
                            break;
                    }



                }
                else if (input == "2")
                {
                    Console.WriteLine("\nWat wilt u met het slot doen?\n1. Openen\n2.Sluiten\n");
                    string incoming = Console.ReadLine();
                    switch (incoming)
                    {
                        case "1":
                            con.Write("1");
                            Console.WriteLine("Slot geopend.\n");
                            break;

                        case "2":
                            con.Write("0");
                            Console.WriteLine("Slot gesloten.\n");
                            break;
                        default:
                            Console.WriteLine("Maak een keuze.\n");
                            break;
                    }
                }

            }
        }
    }
}
