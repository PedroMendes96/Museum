using System;

namespace Museum
{
    public class Approved : IState
    {
        public Process Process { get; set; }

        public Approved(Process process)
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
            Process.Actual = Process.Confirmed;
            var exhibitionFactory = FactoryCreator.Instance.CreateFactory(FactoryCreator.ExhibitionFactory);
            var events = (Temporary) exhibitionFactory.Create(ExhibitionFactory.Temporary);
            events.Process = Process;
            events.Save();
            Process.Active = 0;
            Process.Update(Process.ActiveProperty, false.ToString());

            foreach (var item in Process.Room)
            {
                var table = "rooms_has_events";
                var properties = new[] {"rooms_id", "events_id"};
                var values = new[] {item.Id.ToString(), events.Id.ToString()};
                var sql = SqlOperations.Instance.Insert(table, properties, values);
                DbConnection.Instance.Execute(sql);
                //                var sql = "INSERT INTO rooms_has_events (rooms_id,events_id) VALUES (" + item.Id + "," + events.Id +
                //                          ")";
            }

            Console.WriteLine(@"Falta preencher coisas!!!!");
        }

        public void Cancel()
        {
            Process.Actual = Process.Denied;
            Process.Active = 0;
            Process.Update(Process.ActiveProperty, "0");
            Console.WriteLine(@"Falta preencher coisas!!!!");
        }
    }
}