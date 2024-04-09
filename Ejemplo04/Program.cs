using Ejemplo04;

IFileRepository fileRepository
    = new ThreadSafeFileRepository("files");

// Crear hilos pra realizar operaciones concurrentes
// de lectura y escritura de archivos
Thread writeThread = new Thread(()=>
{
    for (int i = 0; i < 10; i++)
    {
        string fileName = $"file_{i}.txt";
        string content = $"Contenido del archivo {i}";
        fileRepository.SaveFile(new FileData
        {
            FileName = fileName,
            Content = content
        });
        Console.WriteLine(
            $"Archivo guardado: {fileName}");
        Thread.Sleep(100);
    }
});

Thread readThread = new Thread(() =>
{
    for (int i = 0; i < 10; i++)
    {
        string fileName = $"file_{i}.txt";
        FileData fileData = 
        fileRepository.ReadFile(fileName);
        if(fileData != null)
        {
            Console.WriteLine($"Archivo leído - " +
                $"Nombre: {fileData.FileName}, " +
                $"Contenido: {fileData.Content}");
        }
        else
        {
            Console.WriteLine($"El archivo {fileName} " +
                $"no existe");
        }
        Thread.Sleep(100);
    }
});

// Iniciar los hilos
writeThread.Start();
readThread.Start();

// Esperar a que los hilos terminen
writeThread.Join();
readThread.Join();