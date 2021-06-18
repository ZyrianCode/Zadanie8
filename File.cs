using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie8
{
    public class File
    {
        private static Random _random = new Random(); //рандом
        private int _capacity; //задаём объём файла

        /// <summary>
        /// Получиет объём файла
        /// </summary>
        /// <returns> объём файла </returns>
        public int GetFileCapacity()
        {
            return _capacity;
        }

        /// <summary>
        /// Генерирует файл случайного размера от 5 до 500;
        /// </summary>
        public void GenerateFile()
        {
            _capacity = _random.Next(5, 500); //Каждай раз будем генерировать новый файл, когда вызывается метод
        }
    }
}
