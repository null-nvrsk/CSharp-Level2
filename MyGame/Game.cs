using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace MyGame
{
    static class Game
    {
        public static BaseObject[] _objs;
        private static List<Bullet> _bullets = new List<Bullet>();
        private static List<Asteroid> _asteroids = new List<Asteroid>();
        private static int asteroidsCountOnStart = 3; 
        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));

        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        private static Timer _timer = new Timer();
        public static Random rnd = new Random();

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

            _timer.Interval = 10;
            _timer.Start();
            _timer.Tick += Timer_Tick;

            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
        }


        //---------------------------------------------------------------------
        public static void Load()
        {
            _objs = new BaseObject[10];
                    
            //_asteroids = new Asteroid[asteroidsCountOnStart];            

            // Закружем звезды
            for (int i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)), new Point(-r/5, r/5), new Size(3, 3));

            }

            // // Закружем астероиды
            for (int i = 1; i <= asteroidsCountOnStart; i++)
            {
                int r = rnd.Next(20, 100);
                Asteroid asteroid = new Asteroid(new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r));
                _asteroids.Add(asteroid);
                    
            }
        }

        //---------------------------------------------------------------------
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid a in _asteroids)
            {
                a?.Draw();
            }
            foreach (Bullet b in _bullets) b.Draw();

            _ship?.Draw();
            if (_ship != null)
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            Buffer.Render();
        }

        //---------------------------------------------------------------------
        public static void Update()
        {
            foreach (BaseObject obj in _objs) obj.Update();
            foreach (Bullet b in _bullets) b.Update();

            // Если астероиды все сбиты, то создаем новый набор
            if (_asteroids.Count == 0)
            {
                asteroidsCountOnStart++;
                Load();
                return;
            }

            //for (var i = 0; i < _asteroids.Length; i++)
            foreach (Asteroid currentAsteroid in _asteroids)
            {                
                currentAsteroid.Update();

                // проверяем попадания пуль в астероиды
                for (int j = 0; j < _bullets.Count; j++)
                    if (_bullets[j].Collision(currentAsteroid))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        _asteroids.Remove(currentAsteroid);
                        //currentAsteroid = null;
                        _bullets.RemoveAt(j);
                        return;
                        // j--;
                    }

                // проверка столкновения корабля с астероидом
                if (_ship.Collision(currentAsteroid))
                {
                    _ship.EnergyLow(rnd.Next(1, 10));
                    System.Media.SystemSounds.Asterisk.Play();
                    if (_ship.Energy <= 0) _ship.Die();
                }              
            }
        }

        //---------------------------------------------------------------------
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        //---------------------------------------------------------------------
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullets.Add(new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1)));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }

        //---------------------------------------------------------------------
        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }

    }
}
