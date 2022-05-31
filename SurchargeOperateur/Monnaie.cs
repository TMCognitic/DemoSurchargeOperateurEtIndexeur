using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurchargeOperateur
{
    public class Monnaie
    {
        #region Implémentation complète de l'opérateur d'égalité
        //Défini l'opérateur ==
        public static bool operator ==(Monnaie? monnaie1, Monnaie? monnaie2)
        {
            if (monnaie1 is null && monnaie2 is null)
                return true;

            if (monnaie1 is null || monnaie2 is null)
                return false;

            return monnaie1.Equals(monnaie2);
        }
        //Défini l'opérateur != (obligatoirement de paire avec ==)
        public static bool operator !=(Monnaie monnaie1, Monnaie monnaie2)
        {
            return !(monnaie1 == monnaie2);
        }

        //Redéfini la méthode utilisée par les liste par exemple (méthode List<T>.Contains)
        public override bool Equals(object? obj)
        {
            Monnaie? monnaie = obj as Monnaie;

            if (monnaie is null)
                return false;

            return CinqCent == monnaie.CinqCent &&
                DixCent == monnaie.DixCent &&
                VingtCent == monnaie.VingtCent &&
                CinquanteCent == monnaie.CinquanteCent &&
                UnEuro == monnaie.UnEuro &&
                DeuxEuros == monnaie.DeuxEuros;
        }

        //Redéfinission de la méthode GetHashCode
        //Un code de hachage est une valeur numérique utilisée pour insérer et identifier un objet dans une collection
        //basée sur le hachage, telle que la classe Dictionary<TKey,TValue> 
        public override int GetHashCode()
        {
            return HashCode.Combine(CinqCent, DixCent, VingtCent, CinquanteCent, UnEuro, DeuxEuros);
        }
        #endregion

        public static Monnaie operator +(Monnaie? monnaie, int unEuro)
        {
            Monnaie result = new Monnaie();
            if(monnaie is not null)
                result += monnaie;

            result.UnEuro += unEuro;
            return result;
        }

        public static Monnaie operator +(int unEuro, Monnaie? monnaie)
        {
            return monnaie + unEuro;
        }

        public static Monnaie operator +(Monnaie? monnaie1, Monnaie? monnaie2)
        {
            if (monnaie1 is null)
                throw new InvalidOperationException();

            if (monnaie2 is null)
                throw new InvalidOperationException();

            return new Monnaie()
            {
                CinqCent = monnaie1.CinqCent + monnaie2.CinqCent,
                DixCent = monnaie1.DixCent + monnaie2.DixCent,
                VingtCent = monnaie1.VingtCent + monnaie2.VingtCent,
                CinquanteCent = monnaie1.CinquanteCent + monnaie2.CinquanteCent,
                UnEuro = monnaie1.UnEuro + monnaie2.UnEuro,
                DeuxEuros = monnaie1.DeuxEuros + monnaie2.DeuxEuros,
            };
        }
        public int CinqCent { get; set; }
        public int DixCent { get; set; }
        public int VingtCent { get; set; }
        public int CinquanteCent { get; set; }
        public int UnEuro { get; set; }
        public int DeuxEuros { get; set; }

        public double Total
        {
            get
            {
                return CinqCent * .05 +
                    DixCent * .1 +
                    VingtCent * .2 +
                    CinquanteCent * .5 +
                    UnEuro +
                    DeuxEuros * 2;
            }
        }
    }
}
