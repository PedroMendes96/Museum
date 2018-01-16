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
            Console.WriteLine("The Process already was rejected!");
        }

        public void Refuse()
        {
            Console.WriteLine("The Process already was rejected!");
        }

        public void Confirm()
        {
            Console.WriteLine("The Process already was rejected!");
        }

        public void Cancel()
        {
            Console.WriteLine("The Process already was rejected!");
        }
    }
}