//===============================================
// Tyler Sriver                                 *
// OOP Space Invaders - Missile Class           *
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
    class Missile
    {
        public Rectangle _pos;                              //Rectangle for the position
        public static Texture2D Texture { get; set; }       //Texture for the picture
        public bool hit = false;                            //Boolean for if the missile has hit anything

        //Constructor for missile, takes a rectangle
        public Missile(Rectangle pos)
        {
            _pos = new Rectangle(pos.Center.X - (Texture.Width / 2), Convert.ToInt32(pos.Y), Texture.Width, Texture.Height);
        }

        //Method to draw the missile
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, _pos, Color.White);
        }
        
        //Method to move the missile
        public void Move()
        {
            _pos.Y -= 5;
        }
    }
}
