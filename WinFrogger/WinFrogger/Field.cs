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

        public FieldStyle[,] FStyle
        {
            get { return fieldStyle; }
            set { fieldStyle = value; }
        }

        public FieldType[,] FType
        {
            get { return fieldType; }
            set { fieldType = value; }
        }

        // Konstruktor
        public Field()
        {
            // Image laden
            texture = Image.FromFile("data/textures/Tilemap.png");
        }

        public FieldType GetFieldTypeAt(int posX, int posY)
        {
            int fieldPosX = posX / 32;
            int fieldPosY = posY / 32;

            if (fieldPosX < 0 || fieldPosX >= FWidth || fieldPosY < 0 || fieldPosY >= FHeight) return FieldType.Deathzone;
            else return fieldType[fieldPosY, fieldPosX];
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
