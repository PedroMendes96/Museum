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
            Process.Update(DbQuery.ActiveProperty, false.ToString());

            foreach (var item in Process.Room)
            {
                DbQuery.AssociateRoomEvent(events.Id.ToString(), item.Id.ToString());
            }

            Console.WriteLine(@"Falta preencher coisas!!!!");
        }

        public void Cancel()
        {
            Process.Actual = Process.Denied;
            Process.Active = 0;
            Process.Update(DbQuery.ActiveProperty, "0");
            Process.Update(DbQuery.ResultProperty, "0");
            Console.WriteLine(@"Falta preencher coisas!!!!");
        }
    }
}