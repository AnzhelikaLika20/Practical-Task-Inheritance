using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// Исключение возникающие если файл пустой.
    /// </summary>
    public class EmptyFileException : Exception
    {
        public EmptyFileException() : base($"Файл пуст.\n")
        {
        }

        public EmptyFileException(string? message) : base(message)
        {
        }

        public EmptyFileException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmptyFileException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    /// <summary>
    /// Исключение возникающее если пользователь хочет работать с файлов, не указав его имя.
    /// </summary>
    public class NoFileNameException : Exception
    {
        public NoFileNameException() : base("Путь к файлу не указан. Сначала перейдите в 1 пункт меню.\n")
        {
        }

        public NoFileNameException(string? message) : base(message)
        {
        }

        public NoFileNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoFileNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
