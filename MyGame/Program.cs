// [Скоморохов Максим]

// 2) Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
// 3) Сделать так, чтобы при столкновении пули с астероидом они регенерировались в разных концах экрана.
// 4) Сделать проверку на задание размера экрана в классе Game. Если высота или ширина (Width, Height) больше 1000 или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException().


using System;
using System.Windows.Forms;


namespace MyGame
{
    static class Program
    {
        static void Main()
        {
            Form form = new Form
            {
                Width = Screen.PrimaryScreen.Bounds.Width,
                Height = Screen.PrimaryScreen.Bounds.Height
            };
            Game.Init(form);
            form.Show();
            Game.Load();
            Game.Draw();
            Application.Run(form);

        }
    }
}
