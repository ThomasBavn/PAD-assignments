// See https://aka.ms/new-console-template for more information

using System.Collections.ObjectModel;
using System.Threading.Channels;

Console.WriteLine("Hello, World!");


int[] Merge(int[] xs, int[] ys)
{
    var xsI = 0;
    var ysI = 0;

    var res = new int[xs.Length + ys.Length];
    var resI = 0;

    while (resI < res.Length)
    {
        if (xsI == xs.Length)
        {
            for (int i = ysI; i < ys.Length; i++)
            {
                res[resI] = ys[ysI];
                resI++;
            }
        }
        if (ysI == ys.Length)
        {
            for (int i = xsI; i < xs.Length; i++)
            {
                res[resI] = xs[xsI];
                resI++;
            }
        }
        else if (xs[xsI] < ys[ysI])
        {
            res[resI] = xs[xsI];
            xsI++;
            resI++;
        }
        else if (xs[xsI] > ys[ysI])
        {
            res[resI] = ys[ysI];
            ysI++;
            resI++;
        }
        else
        {
            res[resI] = xs[xsI];
            res[resI + 1] = ys[ysI];
            resI += 2;
            ysI++;
            xsI++;
        }
    }

    return res;
}

var list = Merge(new int[] { 3, 5, 12 }, new int[] { 2, 3, 4, 7 });

foreach (var x in list)
{
    Console.Write($"{x} ");
}
