using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie8
{
    public class DVDDisk
    {
        private static int _maxCapacity = 1024; //Максимальная ёмкость диска
        private static int _minCapacity = 0; //Минимальная ёмкость диска
        private static int _capacity = _minCapacity; //Объём диска

        private int _space = _capacity; //Место на диске

        private bool _wasDeletion = false; //Проверка было ли удаление
        private int _removableFileCapacity;

        private File _file = new File(); //Файл
        private EmptyCell _emptyCell = new EmptyCell(); //Пустая ячейка

        private List<int> _disk = new List<int>(); //Диск 
        private List<EmptyCell> _emptyCells = new List<EmptyCell>(); //Пустые ячейки на диске

        /// <summary>
        /// Проверяет можно ли добавить файл. Если файл добавить возможно, он будет добавлен.
        /// </summary>
        public void IsAbleToAddFile()
        {
            if (CheckIfDiskCapacityFull())
            {
                return;
            }
            else
            {
                if (CheckIfFileMakingSizeOverflow())
                {
                    return;
                }
                else
                {
                    AddFile();
                }
            }
        }

        /// <summary>
        /// Проверяет можно ли удалить файл. Если файл удалить возможно, он будет удалёлен.
        /// </summary>
        public void IsAbleToRemoveFile()
        {
            if (CheckIfFileMakingOutOfMinDiskCapacity())
            {
                return;
            }
            else
            {
                if (CheckIfDiskIsEmpty())
                {
                    return;
                }
                else
                {
                    DeleteFile();
                }
            }
        }
        /// <summary>
        /// Добавление файла
        /// </summary>
        public void AddFile()
        {
            if (!_wasDeletion)
            {
                Add();
            }
            else
            {
                for (int i = 0; i < _emptyCells.Count; i++)
                {
                    if (_emptyCells[i].GetSize() <= _file.GetFileCapacity())
                    {
                        Add();
                        TakeSpace();
                        ShowOverflowCaution();
                    }
                    else
                    {
                        Add();
                    }
                }
            }
        }
        /// <summary>
        /// Добавление
        /// </summary>
        private void Add()
        {
            _disk.Add(_file.GetFileCapacity());
            _space -= _file.GetFileCapacity();
        }

        /// <summary>
        /// Удаление
        /// </summary>
        private void Remove()
        {
            _disk.Remove(_file.GetFileCapacity());
            _space += _file.GetFileCapacity();
        }

        /// <summary>
        /// Операция удаления файла
        /// </summary>
        public void DeleteFile()
        {
            Remove();
            FreeUpSpace();
            _wasDeletion = true;
        }

        /// <summary>
        /// Операция высвобождения места после удаления файла
        /// </summary>
        private void FreeUpSpace()
        {
            _removableFileCapacity += _file.GetFileCapacity();
            _emptyCell.SetSize(_removableFileCapacity);
            _emptyCells.Add(_emptyCell);
        }

        /// <summary>
        /// Операция занятия места при добавлении нового файла после удаления
        /// </summary>
        private void TakeSpace()
        {
            _emptyCell.SetSize(0);
            if (_emptyCells != null)
            {
                _emptyCells.Remove(_emptyCell);
            }
        }

        /// <summary>
        /// Вывод сообщения об ошибке
        /// </summary>
        private void ShowOverflowCaution()
        {
            Console.Out.WriteLine("Capacity of file is more than free space ");
        }

        /// <summary>
        /// Выводит сообщение об ошибке, если объём диска при удалении становится меньше минимального
        /// </summary>
        private void ShowOutOfMinCapacityCaution()
        {
            Console.Out.WriteLine("Capacity of file is less than capacity of disk ");
        }

        /// <summary>
        /// Проверяет заполнен ли диск на данный момент
        /// </summary>
        /// <returns> true - если заполнен, false - если не заполнен </returns>
        private bool CheckIfDiskCapacityFull()
        {
            if (_capacity >= _maxCapacity)
            {
                ShowOverflowCaution();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Проверяет пуст ли диск на данный момент
        /// </summary>
        /// <returns> true - если пуст, false - если не пуст </returns>
        private bool CheckIfDiskIsEmpty()
        {
            if (_capacity <= _minCapacity)
            {
                ShowOverflowCaution();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Проверяет, делает ли добавление переполнение размера диска
        /// </summary>
        /// <returns>true - если переполняет, false - если не переполняет</returns>
        private bool CheckIfFileMakingSizeOverflow()
        {
            if ((_capacity += _file.GetFileCapacity()) > _maxCapacity)
            {
                ShowOverflowCaution();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Проверяет, делает ли удаление выход за минимальный объём диска
        /// </summary>
        /// <returns> true - если есть выход за нижнюю границу, false - если нет выхода за нижнюю границу</returns>
        private bool CheckIfFileMakingOutOfMinDiskCapacity()
        {
            if ((_capacity -= _file.GetFileCapacity()) < _minCapacity)
            {
                ShowOutOfMinCapacityCaution();
                return true;
            }
            return false;
        }
    }
}
