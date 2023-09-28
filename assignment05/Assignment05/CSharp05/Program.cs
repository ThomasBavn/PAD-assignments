var list = Merge(new[] { 3, 5, 12 }, new[] { 2, 3, 4, 7 });

foreach (var x in list)
{
    Console.Write($"{x} ");
}

return;

static int[] Merge(int[] first, int[] second)
{
    var result = new int[first.Length + second.Length];
    var counter = 0;

    for (int i = 0, j = 0; i < first.Length || j < second.Length;)
    {
        int? x = i != first.Length ? first[i] : null;
        int? y = j != second.Length ? second[j] : null;

        if (x.HasValue && (x < y || !y.HasValue))
        {
            result[counter++] = x.Value;
            i++;
        }
        else if (y.HasValue)
        {
            result[counter++] = y.Value;
            j++;
        }
    }

    return result;
}
