using System;

namespace TestEventHandler
{
    class Program
    {
        static void Main()
        {
            Adder a = new Adder();
            a.OnMultipleOfFiveReached += a_MultipleOfFiveReached;
            int iAnswer = a.Add(4, 3);
            Console.WriteLine("iAnswer = {0}", iAnswer);
            iAnswer = a.Add(4, 6);
            Console.WriteLine("iAnswer = {0}", iAnswer);
            Console.ReadKey();
        }

        static void a_MultipleOfFiveReached(object sender, EventArgs e)
        {
            //Console.WriteLine(sender is Adder); // true
            Console.WriteLine("Multiple of five reached!");
        }
    }
}

public class Adder
{
    public event EventHandler OnMultipleOfFiveReached;

    public int Add(int x, int y)
    {
        int iSum = x + y;
        if ((iSum % 5 == 0) && (OnMultipleOfFiveReached != null))
        { OnMultipleOfFiveReached(this, EventArgs.Empty); }
        return iSum;
    }
}