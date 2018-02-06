using System;

namespace Museum
{
    public class Pendent : IState
    {
        public Pendent(Process process)
        {
            Process = process;
        }

        private Process Process { get; }

        public void Accept()
        {
            Process.Actual = Process.Approved;
            Process.Result = 1;
            Process.Update(DbQuery.ResultProperty, "1");
            Console.WriteLine(@"Falta preencher coisas!!!!");
        }

        public void Refuse()
        {
            Process.Result = 0;
            Process.Active = 0;
            Process.Actual = Process.Denied;
            Process.Update(DbQuery.ResultProperty, "0");
            Process.Update(DbQuery.ActiveProperty, "0");
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