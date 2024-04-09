// Crear un hilo con parámetros
Thread t1 = 
    new(new ParameterizedThreadStart(FuncionHilo));

t1.Start(5); // Pasar un parámetro al hilo

// Esperar a que el hilo termine
t1.Join();

void FuncionHilo(object? parametro)
{
    int numero = (int)parametro;
    Console.WriteLine("Este es un hilo secundario " +
        "con parámetro {0}", numero);
}