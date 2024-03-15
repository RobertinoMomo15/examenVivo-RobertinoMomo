
Random rnd = new Random();

//
// Ejercicio 1
//

List<int> arreglo = new List<int>();
for (int i = 0; i < 10000000; i++)
{
    arreglo.Add(rnd.Next(-100000, 100001));
}

Console.WriteLine(arreglo.Count);
Console.WriteLine(arreglo.OrderByDescending(x => x).FirstOrDefault());
Console.WriteLine(arreglo.OrderBy(x => x).FirstOrDefault());
Console.WriteLine(arreglo.Average());


Console.WriteLine(arreglo.Where(x => x == 0).Count());
//----------------------------------------------------------

var aux = arreglo.GroupBy(x => x).Select(x => new { elemento = x.Key, cantidad = x.Count() }).OrderByDescending(x => x.cantidad).Take(5).ToList();

foreach (var item in aux)
{
    Console.WriteLine(item.elemento + " " + item.cantidad);
}

//-----------------------------------------------------

int valorAnterior;
int valorActual;
//Con 10000000 elementos tarda demasiado
for (int i = 0; i < arreglo.Count; i++)
{
    for (int j = i; j < arreglo.Count; j++)
    {
        if (arreglo[j] > arreglo[i])
        {
            valorAnterior = arreglo[i];
            valorActual = arreglo[j];

            arreglo[i] = valorActual;
            arreglo[j] = valorAnterior;
        }
    }
}

foreach (var item in arreglo)
{
    Console.WriteLine(item);
}


//-----------------------------------------------------

for (int i = 0; i < arreglo.Count; i++)
{
    int numActual = arreglo[i];
    while ((numActual > 0 && numActual % 2 == 1) || (numActual < 0 && numActual % 2 == -1))
    {
        numActual = rnd.Next(-100000, 100001);
    }
    arreglo[i] = numActual;
}

foreach (int i in arreglo)
{
    Console.WriteLine(i);
}

//----------------------------------------------------------------

//
// Ejercicio 2
//

List<string> arregloString = new List<string>();
for (int i = 0; i < 10000000; i++)
{
    string word = ((char)(97 + rnd.Next(26))).ToString() + ((char)(97 + rnd.Next(26))).ToString() + ((char)(97 + rnd.Next(26))).ToString() + ((char)(97 + rnd.Next(26))).ToString();
    arregloString.Add(word);
}

Console.WriteLine(arregloString.Where(x => x == "hola").Count());


//
// Ejercicio 3
//

int cantCorrectos = 0;

Random gen = new Random();

for (int i = 0; i < 1000000; i++)
{
    List<DateTime> list = new List<DateTime>();

    for (int j = 0; j < 23; j++)
    {
        list.Add(RandomDay());
    }

    //----------------------
    bool encontre = false;
    int z = 0;
    while (!encontre && z < list.Count)
    {
        DateTime dtAcutal = list[z];

        for (int r = 0; r < list.Count; r++)
        {
            if (list[r].Day == dtAcutal.Day && list[r].Month == dtAcutal.Month && r != z)
            {
                encontre = true;
                cantCorrectos++;
            }
        }

        z++;
    }
}

Console.WriteLine(cantCorrectos);

DateTime RandomDay()
{
    DateTime start = new DateTime(1995, 1, 1);
    int range = (DateTime.Today - start).Days;
    return start.AddDays(gen.Next(range));
}


