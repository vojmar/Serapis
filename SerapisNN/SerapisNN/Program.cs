using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerapisNN
{
    class Program
    {
        static void Main(string[] args)
        {
            string arg = "";
            if (args.Length < 1)
            {
                Console.WriteLine("No input");
                Environment.Exit(1);
            }
            else if (args.Length > 1)
            {
                arg = string.Join(" ", args);
            }
            else { arg = args[0]; }
            ConsoleManager cm = new ConsoleManager(arg);
            cm.Init();
        }

        private static void Cancel(object sender, ConsoleCancelEventArgs e)
        {
            
        }
    }
    partial class ConsoleManager
    {
        Network network;
        private string arg;
        public enum CurrentState { working, idle, other }
        private CurrentState currentstate = CurrentState.idle;
        public ConsoleManager(string arg)
        {
            this.arg = arg;
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Cancel);
        }

        private void Cancel(object sender, ConsoleCancelEventArgs e)
        {

            e.Cancel = true;
            userInteraction:
            Console.WriteLine("U wanna exit? fkin morron Y/N");
            switch (Console.ReadKey().KeyChar.ToString().ToUpper())
            {
                case "Y":
                    Environment.Exit(0);
                    break;
                case "N":
                    Init();
                    break;
                default:goto userInteraction;
            }
        }

        public void Init()
        {
            while (true)
            {
                WriteMainMenu();
                switch (Console.ReadKey().KeyChar.ToString().ToUpper())
                {
                    case "4":
                        Environment.Exit(0);
                        break;
                    case "3":
                        UISolve();
                        break;
                    case "2":
                        SolveFile();
                        break;
                    case "1":
                        LearnFromFile();
                        break;
                }
            }
        }

        private void LearnFromFile()
        {
            if (network == null)
            {
                Console.WriteLine("Define neuron count:");
                string nc= Console.ReadLine();
                List<int> ncl = new List<int>();
                for (int i = 0; i < nc.Length; i++)
                {
                    ncl.Add(Convert.ToInt32(nc[0]));
                }
                network = new Network(ncl.ToArray(),new Funkce(null,null),null);
            }
                
        }

        private void SolveFile()
        {

        }

        private void UISolve()
        {
            throw new NotImplementedException();
        }
    }
}
