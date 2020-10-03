using System;
using System.Collections.Generic;
using System.Drawing;


namespace MyGame
{
    class Star : BaseObject
    {
        /// <summary>Список картинок для анимации звёзд</summary>
        List<Bitmap> animationList = new List<Bitmap>() {
            new Bitmap("images/stars/star1.png"),
            new Bitmap("images/stars/star2.png"), 
            new Bitmap("images/stars/star3.png"),
            new Bitmap("images/stars/star4.png"),
            new Bitmap("images/stars/star5.png"),
            new Bitmap("images/stars/star6.png"), 
            new Bitmap("images/stars/star7.png") };

        int animationNum = 0;


        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>Метод отрисовки объекта</summary>
        public override void Draw()
        {
            animationNum++;
            if (animationNum == animationList.Count)
                animationNum = 0;
            Game.Buffer.Graphics.DrawImage(animationList[animationNum], Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
          
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;

            if (Pos.Y < 0)
                Pos.Y += Game.Height;
            else if (Pos.Y > Game.Height)
                Pos.Y -= Game.Height;
        }
    }
}
