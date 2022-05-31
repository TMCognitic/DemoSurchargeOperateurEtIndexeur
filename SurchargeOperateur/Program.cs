namespace SurchargeOperateur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Opérateur arithmétique et logiques
            Distributeur distributeur = new Distributeur();
            distributeur.Inserer(new Monnaie() { UnEuro = 1, CinquanteCent = 1 });
            distributeur.Inserer(new Monnaie() { DeuxEuros = 1, DixCent = 1 });

            Console.WriteLine($"Transaction : {distributeur.CurrentTransaction?.Total ?? 0.0}");
            distributeur.Acheter();

            Console.WriteLine($"Transaction : {distributeur.CurrentTransaction?.Total ?? 0.0}");
            Console.WriteLine($"Content : {distributeur.Content.Total}");

            Monnaie monnaie1 = new Monnaie() { VingtCent = 1 };
            Monnaie monnaie2 = new Monnaie() { VingtCent = 1 };

            Console.WriteLine(monnaie1 == monnaie2);
            Console.WriteLine(monnaie1.Equals(monnaie2));
            Console.WriteLine(ReferenceEquals(monnaie1, monnaie2));

            List<Monnaie> monnaies = new List<Monnaie>();
            monnaies.Add(monnaie1);

            if(monnaies.Contains(monnaie2))
            {
                Console.WriteLine("Présent"); //<-- utilise la méthode Equals
            }

            Dictionary<Monnaie, object?> dictionnary = new Dictionary<Monnaie, object?>();
            dictionnary.Add(monnaie1, null);
            //dictionnary.Add(monnaie2, null); //<-- lève une erreur, le même HashCode est déjà présent (Méthode GetHashCode)


            //Opérateur de Cast
            Celsius celsius = new Celsius { Temperature = 40 };
            Fahrenheit fahrenheit = celsius; //utilise l'opérateur de cast implicite
            celsius = (Celsius)fahrenheit; //utilise l'opérateur de cast explicite
        }
    }
}