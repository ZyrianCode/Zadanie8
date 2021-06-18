using System;

namespace Zadanie8
{
    class Program
    {
        /// <summary>
        /// Опции выбора в меню
        /// </summary>
        public enum Options
        {
            AddFile = 1,
            RemoveFile = 2,
            CloseProgramm = 3
        }

        /// <summary>
        /// Печатает меню
        /// </summary>
        public static void PrintMenu()
        {
            Console.WriteLine("Добавить файл на диск: 1");
            Console.WriteLine("Удалить файл с диска: 2");
            Console.WriteLine("Выйти из приложения: 3");
            Console.WriteLine("Введите номер операции:");
        }

        /// <summary>
        /// Запускает ввод
        /// </summary>
        /// <param name="options"></param>
        public static void TakeUserInput(Options options)
        {
            options = (Options)(Int32.Parse(Console.ReadLine()));
        }

        /// <summary>
        /// Запускает симулятор 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="file"></param>
        /// <param name="disk"></param>
        public static void DiskSimulator(Options options, File file, DVDDisk disk)
        {
            switch (options)
            {
                case Options.AddFile:
                    file.GenerateFile();
                    disk.IsAbleToAddFile();
                    break;

                case Options.RemoveFile:
                    disk.IsAbleToAddFile();
                    break;

                case Options.CloseProgramm:
                    Environment.Exit(0);
                    break;
            }
        }
        static void Main(string[] args)
        {
            File file = new File(); //Файл
            DVDDisk disk = new DVDDisk(); //диск

            Options options = new Options(); //опции

            PrintMenu();
            TakeUserInput(options);
            DiskSimulator(options, file, disk);
        }        
    }
}
