using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo04
{
    // Implementación del repositorio de archivos
    public class ThreadSafeFileRepository : IFileRepository
    {
        private readonly string _directoryPath;
        private readonly object _lockObj = new object();

        public ThreadSafeFileRepository(string directoryPath)
        {
            _directoryPath = directoryPath;
            if(!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
        }

        public FileData ReadFile(string fileName)
        {
            string filePath = Path.Combine(_directoryPath, fileName);

            lock (_lockObj)
            {
                if (File.Exists(filePath))
                {
                    return new FileData
                    {
                        FileName = fileName,
                        Content = File.ReadAllText(filePath)
                    };

                }
                else
                {
                    return null;
                } 
            }
        }

        public void SaveFile(FileData fileData)
        {
            string filePath = Path.Combine(this._directoryPath, 
                fileData.FileName);
            lock (_lockObj)
            {
                File.WriteAllText(filePath, fileData.Content); 
            }
        }
    }
}
