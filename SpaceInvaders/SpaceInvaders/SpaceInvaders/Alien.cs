//===============================================
// Tyler Sriver                                 *
// OOP Space Invaders - Alien Class             *
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
    class Alien
    {
        public Rectangle _pos;                              //Rectangle for the position
        public static Texture2D Texture { get; set; }       //Texture for the picture
        public bool hit = false;                            //Boolean for the if it has been hit
        public int MOVE_SPEED = 1;                         //Integer for the move speed (20)
            

        //Constructor that takes a rectangle
        public Alien(Rectangle pos)
        {
            _pos = pos;
        }

        //Method to draw the alien and call bomb.draw()
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, _pos, Color.White);           
        }

        //Method to move the alien
        public void Move(bool down)
        {  
            if(down)
            {
                _pos.Y += 90;
                if(MOVE_SPEED >= 0)
                {
                    _pos.X += Alien.Texture.Width;
                }
                else
                {
                    _pos.X -= Alien.Texture.Width;
                }
                
            }
            else
            {
                _pos.X -= MOVE_SPEED;
            }
        }
    }
}
