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

        public Events Events { get; set; }

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
            process.Actual = process.Confirmed;
            var exhibitionFactory = FactoryCreator.Instance.CreateFactory(FactoryCreator.ExhibitionFactory);
            var events = (Temporary) exhibitionFactory.Create(ExhibitionFactory.Temporary);
            events.Process = Process;
            events.Save();
            process.Active = false;
            Process.Update(Process.ActiveProperty, false.ToString());

            foreach (var item in Process.Room)
            {
                var sql = "INSERT INTO rooms_has_events (rooms_id,events_id) VALUES (" + item.Id + "," + events.Id +
                          ")";
                DBConnection.Instance.Execute(sql);
            }

            Console.WriteLine(@"Falta preencher coisas!!!!");
        }

        public void Cancel()
        {
            process.Actual = process.Denied;
            process.Active = false;
            Process.Update(Process.ActiveProperty, "0");
            Console.WriteLine(@"Falta preencher coisas!!!!");
        }
    }
}