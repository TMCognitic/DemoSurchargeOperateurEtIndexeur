using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexeur
{
    public class Gare
    {
        private readonly Dictionary<string, Train> _trains = new Dictionary<string, Train>();

        public Train? this[string immatriculation]
        {
            get { return (_trains.ContainsKey(immatriculation) ? _trains[immatriculation] : null); }
        }

        public Train? Get(string immatriculation)
        {
            return (_trains.ContainsKey(immatriculation) ? _trains[immatriculation] : null);
        }

        public void Incoming(Train train)
        {
            Console.WriteLine($"Train {train.Immatriculation} arrive en gare");
            _trains.Add(train.Immatriculation!, train);
        }

        public void Departure(string immatriculation)
        {
            if (!_trains.ContainsKey(immatriculation))
                return;

            _trains.Remove(immatriculation);
            Console.WriteLine($"Train {immatriculation} est parti");
        }
    }
}
