//===============================================
// Tyler Sriver                                 *
// OOP Space Invaders - Alien Arsenal           *
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
    class AlienArsenal
    {
        public List<Bomb> bombs;    //List of bombs

        //Constructor for the Alien Arsenal
        public AlienArsenal()       
        {
            bombs = new List<Bomb>();
        }

        //Method to draw all of the bombs
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bomb b in bombs)
            {
                if (b.alive)
                {
                    b.Draw(spriteBatch);
                }
            }
        }

        //Method to update the status of the bombs and call check collision
        public void updateStatus(Ship myShip, Rectangle viewPort, int level, SettingsBox.SkillLevel LevelSelected)
        {
            foreach(Bomb b in bombs)
            {
                if(b.alive)
                {
                    CheckLevel(LevelSelected, level);
                    b.Move();
                }
                
            }
            checkCollisions(myShip, viewPort);
        }

        //Method to check collisions between the bombs and the ship
        private void checkCollisions(Ship myShip, Rectangle viewport)
        {
            foreach(Bomb b in bombs)
            {
                if(b._pos.Intersects(myShip._pos))
                {
                    b.alive = false;                    
                    myShip.Lives--;
                }
                if(b._pos.Y > viewport.Height)
                {
                    b.alive = false;
                }
            }
            bombs.RemoveAll(s => s.alive == false);
        }

        //Method to check which level you are on and set the bomb speed
        private void CheckLevel(SettingsBox.SkillLevel skillLevel, int level)
        {
            foreach(Bomb b in bombs)
            {
                if(level == 1)
                {
                    if(skillLevel.Equals(SettingsBox.SkillLevel.Intermediate))
                    {
                        b.MOVE_SPEED = 4;
                    }
                    else if(skillLevel.Equals(SettingsBox.SkillLevel.Advanced))
                    {
                        b.MOVE_SPEED = 6;
                    }
                    else
                    {
                        b.MOVE_SPEED = 2;
                   }
                }

                else if(level == 2)
                {
                    if (skillLevel.Equals(SettingsBox.SkillLevel.Intermediate))
                    {
                        b.MOVE_SPEED = 6;
                    }
                    else if (skillLevel.Equals(SettingsBox.SkillLevel.Advanced))
                    {
                        b.MOVE_SPEED = 8;
                    }
                    else
                    {
                        b.MOVE_SPEED = 4;
                   }
                }
            }
        }
    }
}
    

