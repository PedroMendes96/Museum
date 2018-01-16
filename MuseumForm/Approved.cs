using System;

namespace Museum
{
    public class Approved : IState
    {
        public Approved(Process process)
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
            Console.WriteLine("The process is already accepted!");
        }

        public void Refuse()
        {
            Console.WriteLine("Is not possible to be refuse because already is approved!");
        }

        public void Confirm()
        {
            process.Actual = process.Confirmed;
            Console.WriteLine("You just confirmed the process!");
        }

        public void Cancel()
        {
            process.Actual = process.Denied;
            Console.WriteLine("You just accepted the process!");
        }
    }
}