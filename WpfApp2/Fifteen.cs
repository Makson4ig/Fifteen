using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Fifteen
    {
        int Size;  // Размер 
        int[,] map;  // Массив координат.
        int space_x, space_y; // Координаты пробела.
        static Random Rand = new Random(); // Добавлем класс Random 
        public Fifteen (int size)
        {
            if (size < 2) size = 2; // Проверка размера будущего массива 
            if (size > 5) size = 5; // Проверка размера будущего массива 
            this.Size = size; // Присваиваем размер 
            map = new int[size,size]; // Массив равен размерам size на size 
        }

        public void Start() // Заполнение массива map 
        {
            for (int x = 0; x < Size; x++)
                for (int y = 0; y < Size; y++)
                    map[x, y] = Coords_to_position(x, y) + 1; // Заполнение массива
            space_x = Size - 1;
            space_y = Size - 1;
            map[space_x, space_y] = 0; // Запоминаем место где у нас пробел
        }

        public void Shift (int position) // Перемещение "кнопок" 
        {
            int x, y; // Координаты кнопки
            Position_to_coords(position, out x, out y); // Получаем Координаты  
            if (Math.Abs(space_x - x) + Math.Abs(space_y - y) != 1) // Поверям расположение кнопки по сравнению с пустым местом 
                return;
            map[space_x, space_y] = map[x, y]; // Записываем координаты кнопки которую нажали 
            map[x, y] = 0; // Записваем 0 кнопке которую нажали
            space_x = x; // ЗАпоминаем где теперь пробел 
            space_y = y; // Запоминаем где теперь пробел 
        }

        public void RandomShift() // Перемешивание 
        {
            Shift(Rand.Next(0, Size * Size));
        }

        public int Number(int Position) // Вычисление номера кнопки 
        {
            int x; // Координата X
            int y; // Координата Y
            Position_to_coords(Position, out x, out y); // Получение X,Y
            if (x < 0 || x >= Size) return 0; // Проверяем, чтобы не было переполнения массива 
            if (y < 0 || y >= Size) return 0; // Проверяем, чтобы не было переполнения массива
            return map[x, y]; // Получение X,Y 
        }
        private int Coords_to_position(int x, int y) // Вычисление положения позиции 
        {
            return y * Size + x;
        }

        private void Position_to_coords(int position,out int x, out int y) // Вычисление положения координат 
        {
            x = position % Size;
            y = position / Size;
        }

        public bool CheckWin() // Метод проверки кнопок на своих местах 
        {
            if (!(space_x == Size - 1 && space_y == Size - 1)) // Проверка пустой кнопки в правом нижнем углу 
                return false;

            for (int x = 0; x < Size; x++) // Проходим по всем элементам массива 
                for (int y = 0; y < Size; y++) // Проходим по всем элементам массива 
                    if (!(x == Size - 1 && y == Size - 1)) // Проверка если не последний вызов функции
                    if (map[x, y] != Coords_to_position(x, y) + 1) // Проверка на соответвие позиций как при старте
                        return false;
            return true;
        }
    }
}
