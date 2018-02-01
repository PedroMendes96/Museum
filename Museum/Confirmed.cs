using System;

namespace Museum
{
    public class Confirmed : IState
    {
        public Confirmed(Process process)
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
            process.Actual = process.Denied;
            process.Active = 0;
            process.Result = 0;
            Process.Update(Process.ActiveProperty, "0");
            Console.WriteLine(@"Falta preencher coisas!!!!");
        }
    }
}