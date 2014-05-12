using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFrogger
{
    enum FieldStyle
    {
        Street,
        Water,
        Dirt,
        // To-Do Name verändern
        Grass1,
        Grass2,
        Grass3,
        Grass4
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
        int tileSize = 0;
        FieldStyle[,] fieldStyle = new FieldStyle[13, 14];
        FieldType[,] fieldType = new FieldType[13, 14];

        
        // Konstruktor
        public Field()
        {
        }

        public override void Draw(System.Drawing.Graphics gfx)
        {
            base.Draw(gfx);
        }
    }
}
