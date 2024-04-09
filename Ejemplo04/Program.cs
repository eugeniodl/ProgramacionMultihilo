using Ejemplo04;

IFileRepository fileRepository =
    new ThreadSafeFileRepository("files");

// Crear hilos para realizar operaciones concurrentes
// de lectura y escritura de archivos
Thread writeThread = new Thread(() =>
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
        Console.WriteLine($"Archivo guardado: {fileName}");
        Thread.Sleep(100);
    }
});