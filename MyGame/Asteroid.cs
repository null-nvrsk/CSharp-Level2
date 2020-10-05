
using System;
using System.Drawing;


namespace MyGame 
{
    class Asteroid : BaseObject
    {
        Bitmap image;


        public int Power { get; set; }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = new Bitmap("images/asteroid.png");
            Power = 1;
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }

        public override void RegenerateObject()
        {
            Random rnd = new Random();
            // создаем в случайном место c правого края
            Pos = new Point(Game.Width, rnd.Next(0, Game.Height));

            // в направлении влево
            Dir = new Point(rnd.Next(5, 15), 0);
        }

    }
}
