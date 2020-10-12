// [Скоморохов Максим]

// Добавить в программу коллекцию астероидов. Как только она заканчивается (все астероиды сбиты), формируется новая коллекция, в которой на один астероид больше.

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
            Game.Draw();
            Application.Run(form);

        }
    }
}
