string? entrada = "";
bool bucle = true;
Console.Clear();
Console.WriteLine("Programa para resolver preguntas acerca de dados!");

while (bucle)
{
    Console.WriteLine("1: Probabilidad de obtener todas las opciones.");
    Console.WriteLine("2: Probabilidad de obtener una opción.");
    Console.WriteLine("3: Probabilidad de obtener una opción antes del lanzamiento dado.");
    Console.Write("Seleccione una opción: ");
    entrada = Console.ReadLine();
    if (entrada == "1" || entrada == "2" || entrada == "3")
    {
        bucle = false;
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Seleccione una opción correcta.");
    }
}
bucle = true;
Console.Clear();
Console.WriteLine($"Haz seleccionado la opción {entrada}.");

string? dado = "0";
int dadoInt = 0;
while (bucle)
{
    Console.Write("Seleccione el tamaño del dado: ");

    dado = Console.ReadLine();
    if (int.TryParse(dado, out dadoInt))
    {
        bucle = false;
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Seleccione un número valido.");
    }
}

Console.Clear();
Console.WriteLine($"Haz elegido un dado de {dadoInt} caras.");
switch (entrada)
{
    case "1":
        ProbTodos(dadoInt);
        break;

    case "2":
        ProbLanza(dadoInt);
        break;
    case "3":
        ProbAnt(dadoInt);
        break;
}

static void ProbTodos(int tamDado)
{
    int X = tamDado; // Puedes cambiar esto al número deseado de lanzamientos

    float probabilidad = 0f;

    int probInt = 0;

    float tamDadod = (float)tamDado;
    for (int tiro = 1; tiro < tamDado * 5 + 1; tiro++)
    {
        probabilidad = (float)CalcularProbabilidad(tiro, tamDado);
        probInt = (int)probabilidad * 100;
        Console.WriteLine($"Lanzamiento:    {tiro}\t\tProbabilidad:    {Math.Abs(probabilidad):P}\t%");
    }

}
static void ProbLanza(int tamDado)
{
    float[] matriz = new float[tamDado];
    float tamDadod = (float)tamDado;
    float probabilidad = 0f;
    int probInt = 0;
    for (int tiro = 1; tiro < tamDado * 3 + 1; tiro++)
    {
        probabilidad = (float)((1.0 / tamDadod) * Math.Pow((tamDadod - 1) / tamDadod, tiro - 1));
        probInt = (int)probabilidad * 100;
        Console.WriteLine($"Lanzamiento:    {tiro}\t\tProbabilidad:    {probabilidad:P}\t%");
    }
}

static void ProbAnt(int tamDado)
{
    float[] matriz = new float[tamDado];
    float tamDadod = (float)tamDado;
    float probabilidad = 0f;
    int probInt = 0;
    for (int tiro = 1; tiro < tamDado * 3 + 1; tiro++)
    {
        probabilidad = (float)(1 - Math.Pow((tamDadod - 1) / tamDadod, tiro));
        probInt = (int)probabilidad * 100;
        Console.WriteLine($"Lanzamiento:    {tiro}\t\tProbabilidad:    {probabilidad:P}\t%");
    }
}

static double CalcularProbabilidad(int X, int tamDadox)
{
    double resultado = 0;
    for (int i = 0; i <= tamDadox; i++)
    {
        resultado += Math.Pow(-1, i) * Binomial(tamDadox, i) * Math.Pow((tamDadox - i) / Convert.ToDouble(tamDadox), X);
    }

    return resultado;
}

static int Binomial(int n, int k)
{
    if (k == 0 || k == n)
    {
        return 1;
    }

    return Binomial(n - 1, k - 1) + Binomial(n - 1, k);
}
Console.ReadKey();