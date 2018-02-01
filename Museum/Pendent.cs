using System;

namespace Museum
{
    public class Pendent : IState
    {
        public Pendent(Process process)
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
            Process.Actual = process.Approved;
            Process.Result = true;
            Process.Update(Process.ResultProperty, "1");
            Console.WriteLine(@"Falta preencher coisas!!!!");
        }

        public void Refuse()
        {
            Process.Result = false;
            Process.Active = false;
            process.Actual = process.Denied;
            Process.Update(Process.ResultProperty, "0");
            Process.Update(Process.ActiveProperty, "0");
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