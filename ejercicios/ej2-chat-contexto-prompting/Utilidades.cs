using System.Text.RegularExpressions;

namespace Ejercicio2;

public record Prod(string Categoria, decimal Precio, int Stock);

public static class U
{
    public static Dictionary<string, decimal> F1(List<Prod> l)
    {
        var r = new Dictionary<string, decimal>();
        for (int i = 0; i < l.Count; i++)
        {
            var k = l[i].Categoria;
            if (!r.ContainsKey(k)) r[k] = 0;
            r[k] += l[i].Precio * l[i].Stock;
        }
        return r;
    }

    public static string F2(string s)
    {
        s = s.Trim().ToLower();
        s = Regex.Replace(s, @"[^a-z0-9\s-]", "");
        return Regex.Replace(s, @"\s+", "-");
    }

    public static List<double> F3(List<double> l, int n)
    {
        // promedio móvil de ventana n
        var o = new List<double>();
        for (int i = 0; i < l.Count; i++)
        {
            var v = l.Skip(i).Take(n);
            o.Add(v.Sum() / n);
        }
        return o;
    }

    public static decimal F4(decimal precio, decimal pct)
    {
        return precio - precio * pct / 100;
    }
}
