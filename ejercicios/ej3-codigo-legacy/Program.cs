using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

var R = new[] { "Norte", "Sur", "Centro", "Occidente" };

F(args[0]);

void F(string a)
{
    var d = File.ReadAllLines(a);
    var r = new List<string[]>();
    foreach (var x in d.Skip(1))
    {
        if (x == "") continue;
        r.Add(x.Split(','));
    }
    var t = new Dictionary<string, decimal[]>();
    var g = new Dictionary<string, decimal[]>();
    foreach (var k in R) g[k] = new decimal[2];
    for (int i = 0; i < r.Count - 1; i++)
    {
        var k = r[i][1];
        if (!t.ContainsKey(k)) t[k] = new decimal[2];
        var m = decimal.Parse(r[i][5]);
        t[k][0] += m;
        t[k][1] += 1;
        g[r[i][2]][0] += m;
        g[r[i][2]][1] += 1;
    }
    var s = t.OrderByDescending(z => z.Value[0].ToString()).ToList();
    Console.WriteLine("TOP VENDEDORES");
    int n = 1;
    foreach (var par in s.Take(3))
    {
        Console.WriteLine(n + " " + par.Key + " " + par.Value[0] + " " + par.Value[1]);
        n++;
    }
    Console.WriteLine("TICKET PROMEDIO POR SUCURSAL");
    foreach (var k in R)
    {
        Console.WriteLine(k + " " + g[k][0] / g[k][1]);
    }
    Console.WriteLine("TOTAL " + t.Values.Sum(v => v[0]));
}
