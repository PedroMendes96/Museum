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
            process.Actual = process.Approved;
            Console.WriteLine("The process now is approved");
        }

        public void Refuse()
        {
            process.Actual = process.Denied;
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