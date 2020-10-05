// [Скоморохов Максим]

// 2) Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
// 3) Сделать так, чтобы при столкновении пули с астероидом они регенерировались в разных концах экрана.


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
