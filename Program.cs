namespace observer_pattern
{
    //A demonstration of the Observer pattern in C#
    internal class Program
    {
        static void Main(string[] args)
        {
            Alarm alarm = new Alarm();

            alarm.AddWatcher(new FireStation());
            alarm.AddWatcher(new PoliceStation());

            alarm.Notify();

            /* OUTPUT:
             
                FireStation is responding!
                PoliceStation is responding!
             
             */
        }
    }

    public class Alarm
    {
        List<IWatcher<Alarm>> watchers = new List<IWatcher<Alarm>> ();

        public void AddWatcher(IWatcher<Alarm> watcher)
        {
            watchers.Add(watcher);
        }

        public void Notify()
        {
            foreach (var watcher in watchers)
            {
                watcher.Alert(this);
            }
        }
    }

    public interface IWatcher<T>
    {
        public void Alert(T value);
    }

    public class FireStation : IWatcher<Alarm>
    {
        public void Alert(Alarm alarm)
        {
            Console.WriteLine(nameof(FireStation) + " is responding!");
        }
    }

    public class PoliceStation : IWatcher<Alarm>
    {
        public void Alert(Alarm alarm)
        {
            Console.WriteLine(nameof(PoliceStation) + " is responding!");
        }
    }
}
