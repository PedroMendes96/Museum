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
            Console.WriteLine("The process now is approved");
        }

        public void Refuse()
        {
            Process.Result = false;
            Process.Active = false;
            process.Actual = process.Denied;
            Process.Update(Process.ResultProperty, "0");
            Process.Update(Process.ActiveProperty, "0");
            Console.WriteLine("The process now is refused");
        }

        public void Confirm()
        {
            Console.WriteLine("To confirm, you have first to APPROVE the process!");
        }

        public void Cancel()
        {
            Console.WriteLine("The process is pendent, so if you desire to cancel it you must refuse it!");
        }
    }
}