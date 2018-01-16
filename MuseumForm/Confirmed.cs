using System;
using Museum;

namespace Museum_Console.Classes
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
            Console.WriteLine("The Process already was confirmed!");
        }

        public void Refuse()
        {
            Console.WriteLine("The Process already was confirmed!");
        }

        public void Confirm()
        {
            Console.WriteLine("The Process already was confirmed!");
        }

        public void Cancel()
        {
            process.Actual = process.Denied;
            Console.WriteLine("The Process already was canceled!");
        }
    }
}