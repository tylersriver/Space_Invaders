//===============================================
// Tyler Sriver                                 *
// OOP Space Invaders - Ship Arsenal            *
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
    class ShipArsenal
    {
        public List<Missile> missiles;  //List of Missiles
        public int numAliensKilled;     //Integer for the number of aliens killed

        //Constructor for the Ship Arsenal
        public ShipArsenal()
        {
            missiles = new List<Missile>();
            numAliensKilled = 0;
        }

        //Method to draw all of the missiles
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Missile m in missiles)
            {
                    m.Draw(spriteBatch);
            }
        }

        //Method to update the status of the missiles and call check collision
        public void updateStatus(List<Alien> aliens, Rectangle viewPort)
        {
            foreach (Missile m in missiles)
            {
                    m.Move();
            }

            checkCollisions(aliens, viewPort);
        }

        //Method to check collisions betweeen the missiles and the aliens
        private void checkCollisions(List<Alien> aliens, Rectangle viewPort)
        {
            foreach (Missile m in missiles)
            {
                foreach(Alien a in aliens)
                {
                    if(m._pos.Intersects(a._pos))
                    {
                        m.hit = true;
                        a.hit = true;
                        numAliensKilled++;
                    }
                }
            }
            missiles.RemoveAll(s => s.hit == true);
            aliens.RemoveAll(s => s.hit == true);
        }       
    }
}
