//===============================================
// Tyler Sriver                                 *
// OOP Space Invaders - Bomb Class              *
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
    class Bomb
    {
        
        public Rectangle _pos;                              //Rectangle for position
        public static Texture2D Texture { get; set; }       //Texture for the picture
        public int MOVE_SPEED = 2;                          //Integer for the move speed
        public bool alive = true;                           //Boolean for if the bomb is alive

        //Constructor for bomb that takes a rectangle
        public Bomb(Rectangle pos)
        {
            _pos = new Rectangle(pos.Center.X - (Texture.Width / 2), Convert.ToInt32(pos.Y), Texture.Width, Texture.Height);
        }

        //Method to draw the bomb
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, _pos, Color.White);
        }

        //Method to move the bomb
        public void Move()
        {
            _pos.Y += MOVE_SPEED;
        }
    }
}
