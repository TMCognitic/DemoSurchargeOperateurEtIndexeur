using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurchargeOperateur
{
    public class Distributeur
    {
        //Opérateur de conversion implicite du Type Distributeur => bool
        //utilisé par le if (!this) des méthodes 'Insérer' et 'Acheter'
        public static implicit operator bool(Distributeur? distributeur)
        {
            if (distributeur is null)
                return false;

            return distributeur.Status == Status.Running;
        }

        private Monnaie _content = new Monnaie();
        private Monnaie? _currentTransaction;
        public Status Status { get; set; }

        public Monnaie? CurrentTransaction
        {
            get { return _currentTransaction; }
        }

        public Monnaie Content
        {
            get { return _content; }
        }

        public void Inserer(Monnaie monnaie)
        {
            if (!this)
                return;

            if (_currentTransaction is null)
                    _currentTransaction = new Monnaie();

            _currentTransaction = _currentTransaction + monnaie;
        }

        public void Acheter()
        {
            if (!this)
                return;

            //recoit le produit
            _content += _currentTransaction;
            //Donne le produit
            //rend la monnaie
            _currentTransaction = null;            
        }
    }
}
