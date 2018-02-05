using System;

namespace Museum
{
    public class Denied : IState
    {
        public Process Process { get; set; }

        public Denied(Process process)
        {
            Process = process;
        }

        public void Accept()
        {
            Console.WriteLine(@"Falta preencher coisas!!!!");
        }

        public void Refuse()
        {
            Console.WriteLine(@"Falta preencher coisas!!!!");
        }

        public void Confirm()
        {
            Console.WriteLine(@"Falta preencher coisas!!!!");
        }

        public void Cancel()
        {
            Console.WriteLine(@"Falta preencher coisas!!!!");
        }
    }
}