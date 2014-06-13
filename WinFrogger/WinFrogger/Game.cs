using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WinFrogger
{
    enum GameState
    {
        Stopped,
        Running,
        Paused
    };

    class Game
    {
        // Variabeln
        GameState gameState;
        List<Drawable> drawlist = new List<Drawable>();

        // Frog
        Point newFrogPos;
        Frog frog;

        // Field
        Field field;

        // Cars
        List<Car> cars = new List<Car>();

        // Turtles
        List<Turtle> turtles = new List<Turtle>();

        // Trunks
        List<Trunk> trunks = new List<Trunk>();
        

        // Konstruktor
        public Game()
        {
            gameState = GameState.Stopped;

            field = new Field();

            frog = new Frog(Image.FromFile("data/textures/frog.png"), 288, 384, FrogDirection.Up);
        }

        // Properties
        public GameState State
        {
            get { return gameState; }
        }

        // Game Funktionen
        public void Start()
        {
            gameState = GameState.Running;
            this.Reset();
        }

        public void Pause()
        {
            gameState = GameState.Paused;
        }

        public void Resume()
        {
            gameState = GameState.Running;
        }

        public void Stop()
        {
            gameState = GameState.Stopped;
        }

        private void Reset()
        {
            // Zeichenliste leeren
            drawlist.Clear();

            // Feld neu erstellen
            this.GenerateField();
            drawlist.Add(field);

            // Frosch zurücksetzen
            this.ResetFrog();

            // Alle Autos löschen
            cars.Clear();
            // Neue Autos erstellen
            for (int i = 0; i < 12; i++) this.AddRandomCar();
            
            // Alle Schildkröten löschen
            turtles.Clear();
            // Neue Schildkröten erstellen
            for (int i = 0; i < 3; i++) this.addRandomTurtle();

            // Alle Baumstämme löschen
            trunks.Clear();
            // Neue Trunks erstellen
            for (int i = 0; i < 3; i++) this.addRandomTrunk();
        }

        private void ResetFrog()
        {
            frog.Position = new Point(288, 384);
            frog.Direction = FrogDirection.Up;
            frog.Status = FrogStatus.Alive;
        }

        public void HandleInput(System.Windows.Forms.Keys key)
        {
            if (gameState != GameState.Running) return;
            if (frog.Status == FrogStatus.Jump) return;

            switch (key)
            {
                case System.Windows.Forms.Keys.W:
                    frog.Status = FrogStatus.Jump;
                    frog.TurnFrog(FrogDirection.Up);
                    newFrogPos = frog.Position;
                    newFrogPos.Y -= 32;
                    break;
                case System.Windows.Forms.Keys.S:
                    frog.Status = FrogStatus.Jump;
                    frog.TurnFrog(FrogDirection.Down);
                    newFrogPos = frog.Position;
                    newFrogPos.Y += 32;
                    break;
                case System.Windows.Forms.Keys.D:
                    frog.Status = FrogStatus.Jump;
                    frog.TurnFrog(FrogDirection.Right);
                    newFrogPos = frog.Position;
                    newFrogPos.X += 32;
                    break;
                case System.Windows.Forms.Keys.A:
                    frog.Status = FrogStatus.Jump;
                    frog.TurnFrog(FrogDirection.Left);
                    newFrogPos = frog.Position;
                    newFrogPos.X -= 32;
                    break;
            }
        }

        public void Update()
        {
            // Frosch aktualisieren
            this.CheckFrogCollision();
            this.MoveFrog();
            if (frog.Status == FrogStatus.Death) this.ResetFrog();

            // Alle Autos aktualisieren
            for (int i = 0; i < cars.Count; i++)
            {
                cars[i].Update();
                this.CheckCars(cars[i]);
            }

            // Alle Schildkröten aktualisieren
            for (int i = 0; i < turtles.Count; i++)
            {
                turtles[i].Update();
                this.CheckTurtles(turtles[i]);
            }

            // Alle Baumstämme aktualisieren
            for (int i = 0; i < trunks.Count; i++)
            {
                trunks[i].Update();
                this.CheckTrunks(trunks[i]);
            }
        }

        private void MoveFrog()
        {
            if(frog.Status == FrogStatus.Jump)
            {
                if (!frog.Position.Equals(newFrogPos))
                {
                    frog.Move(frog.Direction, 8);
                    frog.Status = FrogStatus.Jump;
                }
                else
                {
                    frog.Status = FrogStatus.Alive;
                }
            }
        }

        private void CheckFrogCollision()
        {
            // Springt der Frosch soll keine weiter Kollission-Überprüfung vorgenommen werden.
            if (frog.Status == FrogStatus.Jump) return;

            // Überprüfe Kollission mit Auto
            for (int i = 0; i < cars.Count; i++)
            {
                if (frog.Position.X + 16 >= cars[i].Position.X &&
                    frog.Position.X < cars[i].Position.X + cars[i].Width &&
                    frog.Position.Y >= cars[i].Position.Y &&
                    frog.Position.Y < cars[i].Position.Y + cars[i].Height)
                {
                    if (!cars[i].Walkable) frog.Die();
                    return;
                }
            }

            // Überprüfe Kollission mit Baumstamm
            for (int i = 0; i < trunks.Count; i++)
            {
                if (frog.Position.X + 16 >= trunks[i].Position.X &&
                    frog.Position.X < trunks[i].Position.X + trunks[i].Width &&
                    frog.Position.Y >= trunks[i].Position.Y &&
                    frog.Position.Y < trunks[i].Position.Y + trunks[i].Height)
                {
                    if (trunks[i].ObjDirection == Direction.Left) frog.Position = new Point(frog.Position.X - trunks[i].Speed, frog.Position.Y);
                    else frog.Position = new Point(frog.Position.X + trunks[i].Speed, frog.Position.Y);
                    return;
                }
            }

            // Überprüfe Kollission mit Schildkröte
            for (int i = 0; i < turtles.Count; i++)
            {
                if (frog.Position.X + 16 >= turtles[i].Position.X &&
                    frog.Position.X < turtles[i].Position.X + turtles[i].Width &&
                    frog.Position.Y >= turtles[i].Position.Y &&
                    frog.Position.Y < turtles[i].Position.Y + turtles[i].Height)
                {
                    if (!turtles[i].Walkable) break;
                    if (turtles[i].ObjDirection == Direction.Left) frog.Position = new Point(frog.Position.X - turtles[i].Speed, frog.Position.Y);
                    else frog.Position = new Point(frog.Position.X + turtles[i].Speed, frog.Position.Y);
                    return;
                }
            }

            // Überprüfen ob Frosch im Wasser ist
            if (field.GetFieldTypeAt(frog.Position.X, frog.Position.Y) == FieldType.Deathzone) frog.Die();
        }

        private void CheckCars(Car car)
        {
            if (car.Position.X <= -32 || car.Position.X >= 32 * field.FieldWidth)
            {
                cars.Remove(car);
                this.AddRandomCar();
            }
        }

        private void CheckTurtles(Turtle turtle)
        {
            if (turtle.Position.X <= -32 || turtle.Position.X >= 32 * field.FieldWidth)
            {
                turtles.Remove(turtle);
                this.addRandomTurtle();
            }
        }

        private void CheckTrunks(Trunk trunk)
        {
            if (trunk.Position.X <= -64 || trunk.Position.X >= 32 * field.FieldWidth)
            {
                trunks.Remove(trunk);
                this.addRandomTrunk();
            }
        }

        private void GenerateField()
        {
            // Create Map
            Random rnd = new Random(DateTime.Now.Millisecond);

            for (int y = 0; y < field.FieldHeight; y++)
            {
                for (int x = 0; x < field.FieldWidth; x++)
                {
                    // Grass
                    if (y == 0)
                    {
                        field.FType[y, x] = FieldType.Deathzone;

                        if (x % 4 == 0) field.FStyle[y, x] = FieldStyle.Grass_Down_Right;
                        else if (x % 4 == 1) field.FStyle[y, x] = FieldStyle.Grass_Left_Right_Top;
                        else if (x % 4 == 2) field.FStyle[y, x] = FieldStyle.Grass_Left_Down;
                        else field.FStyle[y, x] = FieldStyle.Grass;
                    }
                    // Grass und Ziel
                    else if (y == 1)
                    {
                        field.FType[y, x] = FieldType.Deathzone;

                        if (x % 4 == 0) field.FStyle[y, x] = FieldStyle.Grass_Left_Up;
                        else if (x % 4 == 1)
                        {
                            field.FStyle[y, x] = FieldStyle.Stone;
                            field.FType[y, x] = FieldType.Goal;
                        }
                        else if (x % 4 == 2) field.FStyle[y, x] = FieldStyle.Grass_Up_Right;
                        else field.FStyle[y, x] = FieldStyle.Grass_Left_Right_Bottom;
                    }
                    // Wasser
                    else if (y >= 2 && y <= 5)
                    {
                        field.FStyle[y, x] = FieldStyle.Water;
                        field.FType[y, x] = FieldType.Deathzone;
                    }
                    // Gehweg oben
                    else if (y == 6)
                    {
                        field.FType[y, x] = FieldType.Savezone;

                        if (rnd.Next() % 2 == 0) field.FStyle[y, x] = FieldStyle.Sidewalk_Up_1;
                        else field.FStyle[y, x] = FieldStyle.Sidewalk_Up_2;
                    }
                    // Straße oben
                    else if (y == 7)
                    {
                        field.FStyle[y, x] = FieldStyle.Street_Line_Down;
                        field.FType[y, x] = FieldType.Walkable;
                    }
                    // Straße mitte
                    else if (y >= 8 && y <= 10)
                    {
                        field.FStyle[y, x] = FieldStyle.Street_Line_Double;
                        field.FType[y, x] = FieldType.Walkable;
                    }
                    // Straße unten
                    else if (y == 11)
                    {
                        field.FStyle[y, x] = FieldStyle.Street_Line_Up;
                        field.FType[y, x] = FieldType.Walkable;
                    }
                    // Gehweg unten
                    else if (y == 12)
                    {
                        field.FType[y, x] = FieldType.Walkable;

                        if (rnd.Next() % 2 == 0) field.FStyle[y, x] = FieldStyle.Sidewalk_Down_1;
                        else field.FStyle[y, x] = FieldStyle.Sidewalk_Down_2;
                    }
                }
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

        private void addRandomTurtle()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            switch (rnd.Next(0, 2))
            {
                case 0:
                    turtles.Add(new Turtle(Image.FromFile("data/textures/turtle.png"), Direction.Right, -32, 64, rnd.Next(2, 8), true, rnd.Next(60, 180), true));
                    break;
                case 1:
                    turtles.Add(new Turtle(Image.FromFile("data/textures/turtle.png"), Direction.Left, 608, 128, rnd.Next(2, 8), true, rnd.Next(60, 180)));
                    break;
            }

            drawlist.Add(turtles[turtles.Count - 1]);
        }

        private void addRandomTrunk()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            switch (rnd.Next(0, 2))
            {
                case 0:
                    trunks.Add(new Trunk(Image.FromFile("data/textures/trunk.png"), Direction.Right, -64, 96, rnd.Next(2, 8), true, true));
                    break;
                case 1:
                    trunks.Add(new Trunk(Image.FromFile("data/textures/trunk.png"), Direction.Left, 608, 160, rnd.Next(2, 8), true));
                    break;
            }

            drawlist.Add(trunks[trunks.Count - 1]);
        }

        // Grafik Funktionen
        public void Draw(Graphics gfx)
        {
            gfx.Clear(Color.Black);

            for (int i = 0; i < drawlist.Count; i++) drawlist[i].Draw(gfx);

            frog.Draw(gfx);
        }
    }
}
