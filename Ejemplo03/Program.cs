int contador = 0;
object bloqueo = new object();

// Crear varios hilos que incrementan el contador
Thread[] hilos = new Thread[5];

for (int i = 0; i < 5; i++)
{
    hilos[i] = new(new ThreadStart(IncrementarContador));
    hilos[i].Start();
}

// Esperar a que todos los hilos terminen
foreach (Thread t in hilos)
{
    t.Join();
}

Console.WriteLine($"Valor final del contador: {contador}");

void IncrementarContador()
{
    for (int i = 0; i < 1000; i++)
    {
        lock(bloqueo)
        {
            contador++;
        }
        
    }
}