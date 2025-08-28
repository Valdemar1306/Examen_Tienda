
using System.Reflection;


namespace itssip_general.Dto.Common
{

    public static class ExceptionLogCommon
    {
        /// <summary>
        /// Guarda un log a partir de una exception general.
        /// </summary>
        /// <param name="ex">Exeption general.</param>
        /// <param name="aditionalInfo">Información adicional.</param>
        public static void SaveLog(this Exception ex, string? aditionalInfo = null)
        {
            using (StreamWriter streamWriter = File.AppendText(Path.Combine(GetPathLog(), "log.txt")))
            {
                Log(ex, aditionalInfo, streamWriter);
            }
        }

        /// <summary>
        /// Obtiene los bytes del archivo del log.
        /// </summary>
        /// <returns>Bytes del archivo del log.</returns>
        public static byte[] GetFileLog()
        {
            if (File.Exists(Path.Combine(GetPathLog(), "log.txt")))
            {
                return File.ReadAllBytes(Path.Combine(GetPathLog(), "log.txt"));
            }

            return null;
        }

        /// <summary>
        /// Guarda un mensaje de log en un StreamWriter.
        /// </summary>
        /// <param name="ex">Exception con el mensaje a guardar.</param>
        /// <param name="aditionalInfo">Información adicional a escribir.</param>
        /// <param name="streamWriter">StreamWriter en donde se escribirá el mensaje.</param>
        private static void Log(Exception ex, string? aditionalInfo, StreamWriter streamWriter)
        {
            streamWriter.Write("\r\nLog Entry: ");
            streamWriter.WriteLine($"{DateTime.Now.ToLongDateString()} - {DateTime.Now.ToLongTimeString()}");
            streamWriter.WriteLine($"Error:\t{ex.Message}");
            streamWriter.WriteLine($"Aditional:\t{aditionalInfo}");
            streamWriter.WriteLine($"Source:\t{ex.Source}");
            streamWriter.WriteLine($"TargetSite:\t{ex.TargetSite?.Name}");
            streamWriter.WriteLine($"StackTrace:\t{ex.StackTrace}");
            streamWriter.WriteLine("---------------------------------------------------------------------------------------------");
        }

        /// <summary>
        /// Obtiene el path donde se almacenará el log.
        /// </summary>
        /// <returns>Path del log.</returns>
        private static string GetPathLog()
        {
            string? directory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            string path = Path.Combine(directory ?? string.Empty, "Logs", year.ToString(), month.ToString());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}