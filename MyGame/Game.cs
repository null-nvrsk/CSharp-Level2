using System;
using System.Windows.Forms;
using System.Drawing;


namespace MyGame
{
    static class Game
    {
        public static BaseObject[] _objs;

        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }

        //---------------------------------------------------------------------
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        //---------------------------------------------------------------------
        public static void Load()
        {
            Random rnd = new Random();
            _objs = new BaseObject[30];
            for (int i = 0; i < _objs.Length / 2; i++)
            {
                // Случайный размер астероида
                int sizeInt = rnd.Next(5, 20);
                Size rndSize = new Size(sizeInt, sizeInt);

                _objs[i] = new BaseObject(new Point(Height, i * 20), new Point(-i, -i), rndSize);
            }

            // Закружем звезды
            for (int i = _objs.Length / 2; i < _objs.Length; i++)
            {
                // Случайная положение звезды
                int posX = rnd.Next(0, Width);
                int posY = rnd.Next(0, Height);
                Point rndPoint = new Point(posX, posY);

                // Движение в левую сторону со случайной скоростью и отклонением по вертикали
                int rndSpeed = rnd.Next(1, 10);
                int rndY = rnd.Next(-1, 1);
                Point rndDirecion = new Point(-rndSpeed, rndY);

                // Случайный размер звезды
                int sizeInt = rnd.Next(5, 20);
                Size rndSize = new Size(sizeInt, sizeInt);

                _objs[i] = new Star(rndPoint, rndDirecion, rndSize);
            }
        }

        //---------------------------------------------------------------------
        public static void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        //---------------------------------------------------------------------
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }

        //---------------------------------------------------------------------
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

    }
}
