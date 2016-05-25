//===============================================
// Tyler Sriver                                 *
// OOP Space Invaders - Game Class              *
// 12/4/2014                                    *
//===============================================
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Windows.Forms; 

namespace SpaceInvaders
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;     // this represents the graphics device 
        private SpriteBatch spriteBatch;            // all drawing takes place via this object
        private Texture2D backGroundTexture;        // will point to a picture to use for backgrounnd
        private Texture2D startScreenTexture;       // will point to a picture to use for the start screen
        private int Refresh = 60;                   // integer for the refresh rate of update
        private int delay = 0;                      // integer for the delay of dropping the aliens
        private int Level = 1;                      // integer for what level you are on
        private Rectangle viewPort;                 // tells us the size of the drawable area in the window
        private Ship myShip;                        // reference to the ship controlled by the user
        private KeyboardState oldState;             // keeps previous state of keys pressed, so we can                  
        private Rectangle StartScreen;              // rectangle for the start screen
        private bool start = false;                 // boolean for if we have started the game
        SettingsBox.SkillLevel LevelSelected;       // SkillLevel for the selected level in settings
        SettingsBox.rdButtons ButtonSelected;       // Radio Button for cheat or not
        public bool down = false;                   // boolean to tell if the aliens need to move down
        
        //Add list for aliens 
        private List<Alien> aliens;

        //Add the Arsenal and shipWeapons
        private AlienArsenal Arsenal;
        private ShipArsenal shipWeapons;

        const int PANEL_WIDTH = 100;    // width of a panel we'll add for adding buttons, etc.

        // Controls we'll add to form
        Panel gameControlPanel; // control panel
        Label lblKills;         //Label for Kills
        Label lblLives;         //Label for Lives
        Label lblLevel;         //Label for the level

        //Cnstructor for the game
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            
            InitializeControlPanel();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            LoadContent();
            viewPort = GraphicsDevice.Viewport.Bounds;
            oldState = Keyboard.GetState();

            //Instatiate the Arsenal
            Arsenal = new AlienArsenal();
            //Instatiate the shipWeapons
            shipWeapons = new ShipArsenal();
            //Instatiate the ship
            myShip = new Ship(new Rectangle((viewPort.Width - PANEL_WIDTH) / 2,
                                          viewPort.Height - 20, Ship.Texture.Height, Ship.Texture.Width));
            //Instatiate the list of aliens
            aliens = new List<Alien>();

            //Set the Aliens Killed back to 0 
            if(Level == 1)
            {
                shipWeapons.numAliensKilled = 0;
            }            

            //Add aliens
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 2; j++ )
                {
                    aliens.Add(new Alien(new Rectangle(viewPort.Width - 135 - (i * 35), 10 + j*45, Alien.Texture.Width, Alien.Texture.Height)));                   
                }        
            }
            
            base.Initialize();
        }
        
        private void InitializeControlPanel()
        {
            // instantiate a panel and a labels
            gameControlPanel = new Panel();
            lblKills = new Label();
            lblLives = new Label();
            lblLevel = new Label();

            // setup the panel control. Note: this panel will overlay the viewport
            // for 100 pixels
            this.gameControlPanel.Dock = DockStyle.Right;
            this.gameControlPanel.Width = PANEL_WIDTH;

            // create a button for start          
            Button btn = new Button();
            btn.Location = new System.Drawing.Point(10, 10);
            btn.Text = "Start";
            btn.Click += new EventHandler(btn_Click);

            // create a button for settings
            Button btn2 = new Button();
            btn2.Location = new System.Drawing.Point(10, 50);
            btn2.Text = "Settings";
            btn2.Click += new EventHandler(btn2_Click);

            // add the buttons to the panel 
            this.gameControlPanel.Controls.Add(btn);
            this.gameControlPanel.Controls.Add(btn2);
           
            // Label to display the word kills
            this.lblKills.Text = "Kills:  ";
            this.lblKills.Location = new System.Drawing.Point(10, btn.Top + btn.Height + 50);
            this.lblKills.AutoSize = true;
            this.gameControlPanel.Controls.Add(this.lblKills);

            // Label to display the word lives
            this.lblLives.Text = "Lives:  ";
            this.lblLives.Location = new System.Drawing.Point(10, btn.Top + btn.Height + 75);
            this.lblLives.AutoSize = true;
            this.gameControlPanel.Controls.Add(this.lblLives);

            // Label that says the word level
            this.lblLevel.Text = "Level:  " + Level;
            this.lblLevel.Location = new System.Drawing.Point(10, btn.Top + btn.Height + 100);
            this.lblLevel.AutoSize = true;
            this.gameControlPanel.Controls.Add(this.lblLevel);

            // get a reference to game window  
            Form form = Control.FromHandle(this.Window.Handle) as Form;

            // add the panel to the game window form
            form.Controls.Add(gameControlPanel);
        }

        // event handler for start button
        void btn_Click(object sender, EventArgs e)
        {
            start = true;
        }

        // event handler for settings button
        void btn2_Click(object sender, EventArgs e)
        {             
             SettingsBox SettingsBox = new SettingsBox(ButtonSelected, LevelSelected);
             DialogResult result = SettingsBox.ShowDialog();
             if(result == DialogResult.Cancel)
             {
                 SettingsBox.Close();
             }
             else if(result== DialogResult.OK)
             {
                 start = false;
                 Level = 1;
                 Initialize();
                 ButtonSelected = SettingsBox.buttonChecked;
                 LevelSelected = SettingsBox.LevelSelected;
                 setAlienSpeed();
             }            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // load textures into memory once during LoadContent()
            startScreenTexture = Content.Load<Texture2D>("StartScreen");
            StartScreen = new Rectangle(0, 0, GraphicsDevice.Viewport.Width - PANEL_WIDTH, GraphicsDevice.Viewport.Height);
            backGroundTexture = Content.Load<Texture2D>("stars");
            Ship.Texture = Content.Load<Texture2D>("ship2");
            Missile.Texture = Content.Load<Texture2D>("missile");

            //Load the correct Alien for the level
            if(Level == 1)
            {
                Alien.Texture = Content.Load<Texture2D>("alien");
            }
            else if(Level == 2)
            {
                Alien.Texture = Content.Load<Texture2D>("alien2");
            }
            Bomb.Texture = Content.Load<Texture2D>("bomb3");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// This gets called ~60 times per second
        protected override void Update(GameTime gameTime)
        {
            // if the game has started
            if(start)
            {
                moveShip();      // if a arrow key is held down, move the ship

                fireMissile();   // create a missle if the space bar was hit

                //Delay for droppping bombs              
                if (delay / Refresh == 1)
                {                   
                    chooseRandAlien();
                    delay = 0;
                }
                delay++;

                //Move Aliens
                moveAliens();

                //Update the position of the bombs
                Arsenal.updateStatus(myShip, viewPort, Level, LevelSelected);

                //Update the position of the missiles
                shipWeapons.updateStatus(aliens, viewPort);

                //Check the collision of the Aliens and the Ship
                collision();

                //Check if the player has won or lost
                checkWinorLose();

                //Set game to invinvible if invincible button is checked
                if(ButtonSelected == SettingsBox.rdButtons.Invincible)
                {
                    myShip.Lives = 3;
                }
            }

            // text for the labels
            lblKills.Text = "Kills:  " + shipWeapons.numAliensKilled;
            lblLevel.Text = "Level:  " + Level;
            lblLives.Text = "Lives:  " + myShip.Lives;
            base.Update(gameTime);
        }


        // method for moving the ship
        private void moveShip()
        {
            KeyboardState state = Keyboard.GetState();

            //Move left
            if (state.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left) && myShip._pos.X > 0)
            {
                myShip.move(Ship.Direction.Left);
            }
            // Move Right
            else if (state.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right) && myShip._pos.X < viewPort.Width-120)
            {
                myShip.move(Ship.Direction.Right);
            }       
        }

        //Method to fire missile if space key is down
        private void fireMissile()
        {
            KeyboardState newState = Keyboard.GetState();

            // Is the space key down?
            if (newState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
            {               
                if (!oldState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
                {      
                    shipWeapons.missiles.Add(new Missile(myShip._pos));                       
                }
            }
            // Update saved state.
            oldState = newState;
        }

        // method to move the aliens
        public void moveAliens()
        {
            foreach(Alien a in aliens)
            {
                if(a._pos.X <= 0 || a._pos.X >= viewPort.Right - 125)
                {
                    down = true;
                    a.Move(down);
                    a.MOVE_SPEED = -a.MOVE_SPEED;
                    down = false;
                }
                else
                {
                    a.Move(down);
                }              
            }
        }     
        
        // Method to set the speed of the aliens 
        private void setAlienSpeed()
        {
            foreach (Alien a in aliens)
            {
                if (Level == 2)
                {
                    if (LevelSelected.Equals(SettingsBox.SkillLevel.Beginner))
                    {
                        a.MOVE_SPEED = 3;
                    }
                    else if (LevelSelected.Equals(SettingsBox.SkillLevel.Intermediate))
                    {
                        a.MOVE_SPEED = 5;
                        Refresh = 45;
                    }
                    else if (LevelSelected.Equals(SettingsBox.SkillLevel.Advanced))
                    {
                        a.MOVE_SPEED = 6;
                        Refresh = 30;
                    }
                }
                else if (Level == 1)
                {
                    if (LevelSelected.Equals(SettingsBox.SkillLevel.Beginner))
                    {
                        a.MOVE_SPEED = 1;
                    }
                    else if (LevelSelected.Equals(SettingsBox.SkillLevel.Intermediate))
                    {
                        a.MOVE_SPEED = 3;
                        Refresh = 45;
                    }
                    else if (LevelSelected.Equals(SettingsBox.SkillLevel.Advanced))
                    {
                        a.MOVE_SPEED = 4;
                        Refresh = 30;
                    }
                }
            }
        }
        
        // method to check for collisions
        public void collision()
        {            
            //Check collision with aliens and ship
            foreach(Alien a in aliens)
            {
                if(a._pos.Y >= myShip._pos.Y-20)
                {
                    myShip.hit = true;
                }
            }
            if(myShip.hit)
            {
                myShip.Lives--;
                restartLevel();
            }
            myShip.hit = false;
        }

        // Method to restart the current level
        public void restartLevel()
        {
            int kills = shipWeapons.numAliensKilled;
            int lives = myShip.Lives;
            Initialize();
            myShip.Lives = lives;
            shipWeapons.numAliensKilled = kills;
            setAlienSpeed();
        }

        //Check if the player has Won or lost 
        private void checkWinorLose()
        {
            //if the player lost
            if(myShip.Lives == 0)
            {
                MessageBox.Show("You Lose!");
                start = false;
                Level = 1;
                Initialize();
                setAlienSpeed();
            }
            // if the player won level 1
            else if (Level == 1 && aliens.Count == 0)
            {
                Level = 2;
                Initialize();
                shipWeapons.numAliensKilled = 20;
                setAlienSpeed();
            }
            // if the player won the game
            else if (Level == 2 && aliens.Count == 0)
            {
                MessageBox.Show("You Win");
                start = false;
                Level = 1;
                Initialize();
            }
        }

        //Choose random alien to drop bomb
        private void chooseRandAlien()
        {
            Random rand = new Random();
            int chosenAlien = rand.Next(0, aliens.Count);
            Arsenal.bombs.Add(new Bomb(aliens[chosenAlien]._pos));      
        }
      
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// This is called in the main loop after Update to render the current state of the game 
        /// on the screen. 
        protected override void Draw(GameTime gameTime)
        {
            // spriteBatch is an object that allows us to draw everything
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            // draw the background if we've started
            if (start)
            {
                spriteBatch.Draw(backGroundTexture, viewPort, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);

                //draw the aliens
                foreach (Alien a in aliens)
                {
                    a.Draw(spriteBatch);
                }
            }

            //Draw start screen if start hasnt been pushed
            else if(!start)
            {
                spriteBatch.Draw(startScreenTexture, viewPort, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
            }

            // draw the ship over background
            myShip.Draw(spriteBatch);

            //Draw the bombs
            Arsenal.Draw(spriteBatch);
            //Draw the missiles
            shipWeapons.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
