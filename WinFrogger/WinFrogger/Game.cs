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
        
        // Sound
        System.Media.SoundPlayer bgMusic;

        // Konstruktor
        public Game()
        {
            gameState = GameState.Stopped;

            field = new Field();
            bgMusic = new System.Media.SoundPlayer("data/sounds/background_music.wav");

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
            Random rnd = new Random(DateTime.Now.Millisecond);

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
            for (int i = 0; i < 3; i++) cars.Add(new Car(Image.FromFile("data/textures/cars.png"), Direction.Left, 608 + i * rnd.Next(128, 256), 224, 4, 32, 32, false, true));
            for (int i = 0; i < 3; i++) cars.Add(new Car(Image.FromFile("data/textures/cars.png"), Direction.Right, -32 - i * rnd.Next(128, 256), 256, 4, 32, 32, false));
            for (int i = 0; i < 3; i++) cars.Add(new Car(Image.FromFile("data/textures/cars.png"), Direction.Left, 608 + i * rnd.Next(128, 256), 288, 4, 32, 32, false, true));
            for (int i = 0; i < 3; i++) cars.Add(new Car(Image.FromFile("data/textures/cars.png"), Direction.Right, -32 - i * rnd.Next(128, 256), 320, 4, 32, 32, false));
            for (int i = 0; i < 3; i++) cars.Add(new Car(Image.FromFile("data/textures/cars.png"), Direction.Left, 608 + i * rnd.Next(128, 256), 352, 4, 32, 32, false, true));
            // Autos zur Zeichenliste hinzufügen
            for (int i = 0; i < cars.Count; i++) drawlist.Add(cars[i]);

            // Alle Schildkröten löschen
            turtles.Clear();
            // Neue Schildkröten erstellen
            for (int i = 0; i < 3; i++) turtles.Add(new Turtle(Image.FromFile("data/textures/turtle.png"), Direction.Right, -32 - i * rnd.Next(128, 256), 64, 4, true, rnd.Next(120, 1200), true));
            for (int i = 0; i < 3; i++) turtles.Add(new Turtle(Image.FromFile("data/textures/turtle.png"), Direction.Right, -32 - i * rnd.Next(128, 256), 128, 4, true, rnd.Next(120, 1200), true));
            // Schildkröten zur Zeichenliste hinzufügen
            for (int i = 0; i < turtles.Count; i++) drawlist.Add(turtles[i]);

            // Alle Baumstämme löschen
            trunks.Clear();
            // Neue Baumstämme erstellen
            for (int i = 0; i < 3; i++) trunks.Add(new Trunk(Image.FromFile("data/textures/trunk.png"), Direction.Left, 608 + i * rnd.Next(128, 256), 160, 4, true));
            for (int i = 0; i < 3; i++) trunks.Add(new Trunk(Image.FromFile("data/textures/trunk.png"), Direction.Left, 608 + i * rnd.Next(128, 256), 96, 4, true));
            // Baumstämme zur Zeichenliste hinzufügen
            for (int i = 0; i < trunks.Count; i++) drawlist.Add(trunks[i]);
        }

        private void ResetFrog()
        {
            frog.Position = new Point(288, 384);
            frog.TurnFrog(FrogDirection.Up);
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
            // Spiel nur aktualisieren, wenn es auch läuft
            if (gameState != GameState.Running) return;

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
                if (frog.Position.X + 32 >= cars[i].Position.X &&
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

            // Überprüfen ob Frosch in einer Todeszone ist
            if (field.GetFieldTypeAt(frog.Position.X + 16, frog.Position.Y + 16) == FieldType.Deathzone) frog.Die();
        }

        private void CheckCars(Car car)
        {
            if (car.Position.X <= -32 && car.ObjDirection == Direction.Left) car.Position = new Point(32 * field.FieldWidth, car.Position.Y);
            else if (car.Position.X >= 32 * field.FieldWidth && car.ObjDirection == Direction.Right) car.Position = new Point(-32, car.Position.Y);
        }

        private void CheckTurtles(Turtle turtle)
        {
            if (turtle.Position.X <= -32 && turtle.ObjDirection == Direction.Left) turtle.Position = new Point(32 * field.FieldWidth, turtle.Position.Y);
            else if (turtle.Position.X >= 32 * field.FieldWidth && turtle.ObjDirection == Direction.Right) turtle.Position = new Point(-32, turtle.Position.Y);
        }

        private void CheckTrunks(Trunk trunk)
        {
            if (trunk.Position.X <= -32 && trunk.ObjDirection == Direction.Left) trunk.Position = new Point(32 * field.FieldWidth, trunk.Position.Y);
            else if (trunk.Position.X >= 32 * field.FieldWidth && trunk.ObjDirection == Direction.Right) trunk.Position = new Point(-32, trunk.Position.Y);
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

        public void PlayMusic()
        {
            bgMusic.PlayLooping();
        }

        public void StopMusic()
        {
            bgMusic.Stop();
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
