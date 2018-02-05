using System;

namespace Museum
{
    public class Confirmed : IState
    {
        public Process Process { get; set; }

        public Confirmed(Process process)
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
            Process.Actual = Process.Denied;
            Process.Active = 0;
            Process.Result = 0;
            Process.Update(Process.ActiveProperty, "0");
            Console.WriteLine(@"Falta preencher coisas!!!!");
        }
    }
}