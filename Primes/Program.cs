using System;

internal class Program
{
    static object lo = new object();
    static bool isPrime(int n)
    {
        if (n <= 1)
            return false;
        int tmp = n;
        while (--tmp > 1)
        {
            if (n % tmp == 0)
                return false;
        }
        return true;
    }
    static void doWork(List<int> T, int min, int max)
    {
        for (int i = min; i <= max; i++)
        if (!isPrime(i))
        {
                lock (lo)
                {
                    T.Remove(i);
                }
            }
    }
    private static void Main(string[] args)
    {
        int m = 0;
        do
        {
            Console.WriteLine("Enter the maximum number: ");
            m = Convert.ToInt32(Console.ReadLine());
        } while (m < 2);
        List<int> P = new List<int>();
        for (int i = 2; i <= m; i++)
        {
            P.Add(i);
        }
        /*
        for (int i = 2; i <= m; i++)
        {
            if (!isPrime(i))
            {
                P.Remove(i);
            }
        }*/

        List<Thread> Tr = new List<Thread>();
        int size = m/8;
        for (int i = 0; i < 8; i++)
        {
            int x = i * size;
            Thread t=(new Thread(() =>
            {
                doWork(P,x,x+size);
            }));
            t.Start();
            Tr.Add(t);
        }
        foreach (Thread t in Tr) { t.Join(); }
        doWork(P, m - (m % 8 + 1), m);

        /*List<Task> T = new List<Task>();
        for (int i = 2; i <= m; i++)
        {
            int x = i;
            T.Add(Task.Run(() =>
            {
                    if (!isPrime(x))
                    {
                        lock (lo)
                        {
                            P.Remove(x);
                        }
                    }
            }));
        }
        Task.WhenAll(T).Wait();*/


        /*Parallel.For(2, (m+1), i =>
        {
            if (!isPrime(i))
            {
                lock (lo)
                {
                    P.Remove(i);
                }
            }
        });*/
        
        Console.WriteLine("The prime numbers until " + m + ": ");
        for (int i = 0; i < P.Count; i++)
        {
            if (i % 10 == 0)
                Console.WriteLine();
            Console.Write(P[i].ToString().PadLeft(5) + ", ");
        }
    }         
}