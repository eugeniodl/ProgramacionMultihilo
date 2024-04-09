// Crear un nuevo hilo y especificar la función
// que ejecutará
Thread t1 = new(new ThreadStart(FuncionHilo));

// Iniciar la ejecución del hilo
t1.Start();

// Esperar a que el hilo termine antes de continuar
t1.Join();

Console.WriteLine("El hilo principal ha terminado");

void FuncionHilo()
{
    // Código que se ejecutará por el hilo
    Console.WriteLine("Este es un hilo secundario");
}