//===============================================
// Tyler Sriver                                 *
// OOP Space Invaders - Ship Class              *
// 12/4/2014                                    *
//===============================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvaders
{
    class Ship
    {
        public bool hit = false;                            //Boolean for if th ship is hit
        public Rectangle _pos;                              //Rectangle for the position
        public enum Direction { Left, Right };              //Enumeration for the drection of movement
        public static Texture2D Texture { get; set; }       //Texture for the picture
        public int Lives = 3;                               //Int for the lives of the ship

        //Constructor for the ship, it takes a rectangle
        public Ship(Rectangle pos)
        {
            _pos = pos;
        }

        //Method to draw the ship
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, _pos, Color.White);
        }

        //Method to move the ship
        public void move(Direction dir)
        {
            switch (dir)
            {
                case Direction.Left: _pos.X -= 3;
                    break;
                case Direction.Right: _pos.X += 3;
                    break;                
            }
        }       
    }
}
