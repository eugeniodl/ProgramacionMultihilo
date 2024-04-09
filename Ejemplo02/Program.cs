// Crear un hilo con parámetros
Thread t1 = new Thread(new ParameterizedThreadStart(FuncionHilo));

t1.Start(5);

// Esperar a que el hilo termine
t1.Join();

Console.WriteLine("Hilo principal ha terminado.");

void FuncionHilo(object? parametro)
{
    int numero = (int)parametro;
    Console.WriteLine($"Es es un hilo secundario con parámetro: {numero}");
}