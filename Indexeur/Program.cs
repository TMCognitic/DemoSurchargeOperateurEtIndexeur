namespace Indexeur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gare gare = new Gare();
            Train train1 = new Train() { Immatriculation = "EZ-123" };
            Train train2 = new Train() { Immatriculation = "AB-456" };

            gare.Incoming(train1);
            gare.Incoming(train2);
            Console.WriteLine(gare["EZ-123"]?.Immatriculation);

            gare.Departure("EZ-123");

            //Les indexeurs n'implique pas nécessairement un tableau dans la classe conteneur
            BinaryVisitor binaryVisitor = new BinaryVisitor() { Value = 0b1011 };
            Console.WriteLine(binaryVisitor[0]); //-> 1
            Console.WriteLine(binaryVisitor[1]); //-> 1
            Console.WriteLine(binaryVisitor[2]); //-> 0
            Console.WriteLine(binaryVisitor[3]); //-> 1
        }
    }
}