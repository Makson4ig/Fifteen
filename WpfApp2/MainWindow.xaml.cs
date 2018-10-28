using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        Fifteen Fifteen;
        public MainWindow()
        {
            InitializeComponent();
            Fifteen = new Fifteen(4);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            int Position = Convert.ToInt16(((Button)sender).Tag); // Переменная позиции, позицию получаем с помощью tag на кнопке 
            Fifteen.Shift(Position); // Вызов метода смещения кнопки 
            Refresh(); // Вызов метода визуальное обновления кнопок 
            if (Fifteen.CheckWin()) // Проверка вызовом метода CheckWin
            {
                MessageBox.Show("Победа!!!");
                Fifteen.Start();
            }
        }

        private Button Button(int position) // Метод кнопок 
        {
            switch (position)
            {
                case 0: return Button0;
                case 1: return Button1;
                case 2: return Button2;
                case 3: return Button3;
                case 4: return Button4;
                case 5: return Button5;
                case 6: return Button6;
                case 7: return Button7;
                case 8: return Button8;
                case 9: return Button9;
                case 10: return Button10;
                case 11: return Button11;
                case 12: return Button12;
                case 13: return Button13;
                case 14: return Button14;
                case 15: return Button15;
                default: return null;
            }
        }

        private void Game_start() // Запуск игры 
        {
            Fifteen.Start(); // Заупскаем заполнение массива
            for (int j = 0; j < 100; j++) 
                Fifteen.RandomShift(); // Выполняем перемешивание 
            Refresh(); // Обновляем кнопки
        }

        private void Refresh() // Обновление всех 
        {
            for (int position = 0; position < 16; position++) // Для каждой позиции вызываем функцию Button
            {
                Button(position).Content = Fifteen.Number(position).ToString(); // Простовляем номер 
                if (Button(position).Content.ToString() == "0") // Если "0", то присваем пусто 
                {
                    Button(position).Content = ""; 
                }
            }
                
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Game_start();
        }

    }
}
