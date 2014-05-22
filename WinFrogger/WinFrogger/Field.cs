using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WinFrogger
{
    enum FieldStyle
    {
        Street_Line_Double,
        Street_Line_Up,
        Street_Line_Down,
        Water,
        Sidewalk_Up_1,
        Sidewalk_Up_2,
        Sidewalk_Down_1,
        Sidewalk_Down_2,
        Grass_Left_Down,
        Grass,
        Grass_Down_Right,
        Grass_Left_Right_Top,
        Grass_Up_Right,
        Grass_Left_Right_Bottom,
        Grass_Left_Up,
        Stone
    };

    enum FieldType
    {
        Walkable,
        Deathzone,
        Savezone,
        Goal
    };

    class Field : Drawable
    {
        // Variabeln
        const int tileSize = 32;
        const int FHeight = 13;
        const int FWidth = 19;

        Image texture;
        FieldStyle[,] fieldStyle = new FieldStyle[FHeight, FWidth];
        FieldType[,] fieldType = new FieldType[FHeight, FWidth];

        // Properties
        public int FieldHeight
        {
            get { return FHeight; }
        }

        public int FieldWidth
        {
            get { return FWidth; }
        }

        // Konstruktor
        public Field()
        {
            // Create Map
            Random rnd = new Random();

            for (int y = 0; y < FHeight; y++)
            {
                for (int x = 0; x < FWidth; x++)
                {
                    // Grass
                    if (y == 0)
                    {
                        fieldType[y, x] = FieldType.Deathzone;

                        if (x % 4 == 0) fieldStyle[y, x] = FieldStyle.Grass_Down_Right;
                        else if (x % 4 == 1) fieldStyle[y, x] = FieldStyle.Grass_Left_Right_Top;
                        else if (x % 4 == 2) fieldStyle[y, x] = FieldStyle.Grass_Left_Down;
                        else fieldStyle[y, x] = FieldStyle.Grass;
                    }
                    // Grass und Ziel
                    else if (y == 1)
                    {
                        fieldType[y, x] = FieldType.Deathzone;

                        if (x % 4 == 0) fieldStyle[y, x] = FieldStyle.Grass_Left_Up;
                        else if (x % 4 == 1)
                        {
                            fieldStyle[y, x] = FieldStyle.Stone;
                            fieldType[y, x] = FieldType.Goal;
                        }
                        else if (x % 4 == 2) fieldStyle[y, x] = FieldStyle.Grass_Up_Right;
                        else fieldStyle[y, x] = FieldStyle.Grass_Left_Right_Bottom;
                    }
                    // Wasser
                    else if (y >= 2 && y <= 5)
                    {
                        fieldStyle[y, x] = FieldStyle.Water;
                        fieldType[y, x] = FieldType.Deathzone;
                    }
                    // Gehweg oben
                    else if (y == 6)
                    {
                        fieldType[y, x] = FieldType.Savezone;

                        if (rnd.Next() % 2 == 0) fieldStyle[y, x] = FieldStyle.Sidewalk_Up_1;
                        else fieldStyle[y, x] = FieldStyle.Sidewalk_Up_2;
                    }
                    // Straße oben
                    else if (y == 7)
                    {
                        fieldStyle[y, x] = FieldStyle.Street_Line_Down;
                        fieldType[y, x] = FieldType.Walkable;
                    }
                    // Straße mitte
                    else if (y >= 8 && y <= 10)
                    {
                        fieldStyle[y, x] = FieldStyle.Street_Line_Double;
                        fieldType[y, x] = FieldType.Walkable;
                    }
                    // Straße unten
                    else if (y == 11)
                    {
                        fieldStyle[y, x] = FieldStyle.Street_Line_Up;
                        fieldType[y, x] = FieldType.Walkable;
                    }
                    // Gehweg unten
                    else if (y == 12)
                    {
                        fieldType[y, x] = FieldType.Walkable;

                        if (rnd.Next() % 2 == 0) fieldStyle[y, x] = FieldStyle.Sidewalk_Down_1;
                        else fieldStyle[y, x] = FieldStyle.Sidewalk_Down_2;
                    }
                }
            }

            // Image laden
            texture = Image.FromFile("data/textures/Tilemap.png");
        }

        public FieldType GetFieldTypeAt(int posX, int posY)
        {
            return fieldType[posY % 32, posY % 32];
        }

        public override void Draw(Graphics gfx)
        {
            for (int y = 0; y < FHeight; y++)
            {
                for (int x = 0; x < FWidth; x++)
                {
                    Rectangle textureSrc = new Rectangle();

                    // FieldStyle herausfinden und passendes Bild aus der Tilemap auswählen
                    switch(fieldStyle[y, x])
                    {
                        case FieldStyle.Street_Line_Double:
                            textureSrc = new Rectangle(0, 0, tileSize, tileSize);
                            break;
                        case FieldStyle.Street_Line_Up:
                            textureSrc = new Rectangle(32, 0, tileSize, tileSize);
                            break;
                        case FieldStyle.Street_Line_Down:
                            textureSrc = new Rectangle(64, 0, tileSize, tileSize);
                            break;
                        case FieldStyle.Water:
                            textureSrc = new Rectangle(96, 0, tileSize, tileSize);
                            break;
                        case FieldStyle.Sidewalk_Up_1:
                            textureSrc = new Rectangle(0, 32, tileSize, tileSize);
                            break;
                        case FieldStyle.Sidewalk_Up_2:
                            textureSrc = new Rectangle(32, 32, tileSize, tileSize);
                            break;
                        case FieldStyle.Sidewalk_Down_1:
                            textureSrc = new Rectangle(64, 32, tileSize, tileSize);
                            break;
                        case FieldStyle.Sidewalk_Down_2:
                            textureSrc = new Rectangle(96, 32, tileSize, tileSize);
                            break;
                        case FieldStyle.Grass_Left_Down:
                            textureSrc = new Rectangle(0, 64, tileSize, tileSize);
                            break;
                        case FieldStyle.Grass:
                            textureSrc = new Rectangle(32, 64, tileSize, tileSize);
                            break;
                        case FieldStyle.Grass_Down_Right:
                            textureSrc = new Rectangle(64, 64, tileSize, tileSize);
                            break;
                        case FieldStyle.Grass_Left_Right_Top:
                            textureSrc = new Rectangle(96, 64, tileSize, tileSize);
                            break;
                        case FieldStyle.Grass_Up_Right:
                            textureSrc = new Rectangle(0, 96, tileSize, tileSize);
                            break;
                        case FieldStyle.Grass_Left_Right_Bottom:
                            textureSrc = new Rectangle(32, 96, tileSize, tileSize);
                            break;
                        case FieldStyle.Grass_Left_Up:
                            textureSrc = new Rectangle(64, 96, tileSize, tileSize);
                            break;
                        case FieldStyle.Stone:
                            textureSrc = new Rectangle(96, 96, tileSize, tileSize);
                            break;
                    }

                    // Bild zeichnen
                    gfx.DrawImage(texture, new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize), textureSrc, GraphicsUnit.Pixel);
                }
            }
        }
    }
}
