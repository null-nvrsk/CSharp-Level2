using System;
using System.Collections.Generic;
using System.Drawing;

namespace MyGame
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X + 3;


            if (Pos.X > Game.Width) RegenerateObject();
        }

        public override void RegenerateObject()
        {
            Random rnd = new Random();
            // создаем в случайном место c левого края
            Pos = new Point(0, rnd.Next(0, Game.Height));

            // в направлении вправо
            Dir = new Point(rnd.Next(5, 15), rnd.Next(-2, 2));
        }

    }
}
