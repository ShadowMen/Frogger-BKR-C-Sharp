using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WinFrogger
{
    enum DifficultyLevel
    {
        Easy,
        Normal,
        Hard
    };

    class Game
    {
        // Variabeln
        DifficultyLevel difficultyLvl;
        bool isGameRunning;
        List<Drawable> drawlist = new List<Drawable>();

            // Frog
        bool frogMoving = false;
        Point newFrogPos;
        Frog frog;

            // Field
        Field field;

            // Car
        List<Car> cars = new List<Car>();
        

        // Konstruktor
        public Game()
        {
            isGameRunning = false;

            field = new Field();
            drawlist.Add(field);

            frog = new Frog(Image.FromFile("data/textures/frog.png"), 288, 384, FrogDirection.Up);
            drawlist.Add(frog);

            for (int i = 0; i < 12; i++) this.AddRandomCar();
        }

        // Properties
        public bool IsGameRunning
        {
            get { return isGameRunning; }
        }

        public DifficultyLevel Difficulty
        {
            get { return difficultyLvl; }
        }

        // Game Funktionen
        public void Start(DifficultyLevel difficulty)
        {
            if (difficultyLvl == difficulty) return;

            this.Reset();
            difficultyLvl = difficulty;
            isGameRunning = true;
        }

        public void Pause()
        {
            isGameRunning = false;
        }

        public void Resume()
        {
            isGameRunning = true;
        }

        public void Reset()
        {
        }

        public void HandleInput(System.Windows.Forms.Keys key)
        {
            if (frogMoving) return;

            switch (key)
            {
                case System.Windows.Forms.Keys.W:
                    frogMoving = true;
                    frog.TurnFrog(FrogDirection.Up);
                    newFrogPos = frog.Position;
                    newFrogPos.Y -= 32;
                    break;
                case System.Windows.Forms.Keys.S:
                    frogMoving = true;
                    frog.TurnFrog(FrogDirection.Down);
                    newFrogPos = frog.Position;
                    newFrogPos.Y += 32;
                    break;
                case System.Windows.Forms.Keys.D:
                    frogMoving = true;
                    frog.TurnFrog(FrogDirection.Right);
                    newFrogPos = frog.Position;
                    newFrogPos.X += 32;
                    break;
                case System.Windows.Forms.Keys.A:
                    frogMoving = true;
                    frog.TurnFrog(FrogDirection.Left);
                    newFrogPos = frog.Position;
                    newFrogPos.X -= 32;
                    break;
            }
        }

        public void Update()
        {
            this.MoveFrog();

            for (int i = 0; i < cars.Count; i++)
            {
                cars[i].Update();
                this.CheckCars(cars[i]);
            }
        }

        private void MoveFrog()
        {
            if(frogMoving)
            {
                if (!frog.Position.Equals(newFrogPos))
                {
                    frog.Move(frog.Direction, 8);
                    frog.Status = FrogStatus.Jump;
                }
                else
                {
                    frogMoving = false;
                    frog.Status = FrogStatus.Alive;
                }
            }
        }

        private void CheckCars(Car car)
        {
            if (car.Position.X <= -32 || car.Position.X >= 32 * field.FieldWidth)
            {
                cars.Remove(car);
                this.AddRandomCar();
            }
        }

        private void AddRandomCar()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            switch (rnd.Next(0, 5))
            {
                case 0:
                    cars.Add(new Car(Image.FromFile("data/textures/cars.png"), Direction.Left, 608, 224, rnd.Next(2, 16), 32, 32, false, true));
                    break;
                case 1:
                    cars.Add(new Car(Image.FromFile("data/textures/cars.png"), Direction.Right, -32, 256, rnd.Next(2, 16), 32, 32, false));
                    break;
                case 2:
                    cars.Add(new Car(Image.FromFile("data/textures/cars.png"), Direction.Left, 608, 288, rnd.Next(2, 16), 32, 32, false, true));
                    break;
                case 3:
                    cars.Add(new Car(Image.FromFile("data/textures/cars.png"), Direction.Right, -32, 320, rnd.Next(2, 16), 32, 32, false));
                    break;
                case 4:
                    cars.Add(new Car(Image.FromFile("data/textures/cars.png"), Direction.Left, 608, 352, rnd.Next(2, 16), 32, 32, false, true));
                    break;
                case 5:
                    cars.Add(new Car(Image.FromFile("data/textures/cars.png"), Direction.Right, -32, 384, rnd.Next(2, 16), 32, 32, false));
                    break;
            }

            drawlist.Add(cars[cars.Count - 1]);
        }

        // Grafik Funktionen
        public void Draw(Graphics gfx)
        {
            gfx.Clear(Color.Black);

            for (int i = 0; i < drawlist.Count; i++)
            {
                drawlist[i].Draw(gfx);
            }
        }
    }
}
