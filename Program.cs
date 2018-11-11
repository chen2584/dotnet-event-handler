using System;

namespace EventHandler
{
    public delegate int dgPointer(int a, int b);
    class Program
    {
        static void Main()
        {
            Adder a = new Adder();
            a.OnMultipleOfFiveReached += new Adder.dgEventRaiser(a_MultipleOfFiveReached);

            int iAnswer = a.Add(4, 3);
            Console.WriteLine("iAnswer = {0}", iAnswer);
            iAnswer = a.Add(4, 6);
            Console.WriteLine("iAnswer = {0}", iAnswer);
            Console.ReadKey();
        }

        static void a_MultipleOfFiveReached()
        {
            Console.WriteLine("Multiple of five reached!");
        }
    }

    public class Adder
    {
        public delegate void dgEventRaiser();
        public event dgEventRaiser OnMultipleOfFiveReached;

        public int Add(int x, int y)
        {
            int iSum = x + y;
            if ((iSum % 5 == 0) && (OnMultipleOfFiveReached != null))
            { OnMultipleOfFiveReached(); }
            return iSum;
        }
    }
}
