using System;
using System.Drawing;

namespace MyGame
{
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();

        public abstract void Update();

        // создаем новый объект вместо старого
        public virtual void RegenerateObject()
        {
            Random rnd = new Random();
            // создаем в случайном место
            Pos = new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height));
            
            // в случаном направлении
            Dir = new Point(rnd.Next(-5, 5), rnd.Next(-5, 5));

            // случайного размера
            int sizeInt = rnd.Next(5, 50);
            Size = new Size(sizeInt, sizeInt);
        }

        // Так как переданный объект тоже должен будет реализовывать интерфейс ICollision, мы 
        // можем использовать его свойство Rect и метод IntersectsWith для обнаружения пересечения с
        // нашим объектом (а можно наоборот)
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);

        public Rectangle Rect => new Rectangle(Pos, Size);

        public delegate void Message();
    }
}
