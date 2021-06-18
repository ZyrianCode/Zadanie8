using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie8
{
    public class EmptyCell
    {
        private int _size = 0; //Размер пустой ячейки по-умолчаню

        /// <summary>
        /// Устанавливает размер ячейки
        /// </summary>
        /// <param name="Size"> размер ячейки </param>
        public void SetSize(int Size)
        {
            _size = Size;
        }

        /// <summary>
        /// Передаёт размер ячейки
        /// </summary>
        /// <returns> размер ячейки</returns>
        public int GetSize() 
        {
            return _size;
        }
    }
}
