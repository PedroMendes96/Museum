using System;

namespace Museum
{
    public class Denied : IState
    {
        public Denied(Process process)
        {
            this.process = process;
        }

        private Process process { get; set; }

        public Process Process
        {
            get => process;
            set => process = value;
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