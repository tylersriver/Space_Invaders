//===============================================
// Tyler Sriver                                 *
// OOP Space Invaders - SettingsBox Class       *
// 12/4/2014                                    *
//===============================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class SettingsBox : Form
    {
        //Enumeration for the radio buttons
        public enum rdButtons { Invincible, NoCheat };

        //Variable for the radio buttons
        public rdButtons buttonChecked { get; set; }

        //Enumeration for the skill level
        public enum SkillLevel { Beginner, Intermediate, Advanced };

        //Variable for the selected level
        public SkillLevel LevelSelected { get; set; }

        //Default constructor for the settings box
        public SettingsBox()
        {
            InitializeComponent();
        }

        //Constructor for settings box that takes an rdButtons and SkillLevel
        public SettingsBox(rdButtons button, SkillLevel level)
        {
            InitializeComponent();

            //Set the rsButtons from button
            if(button == rdButtons.Invincible)
            {
                rdInvincible.Checked = true;
            }
            else
            {
                rdNoCheat.Checked = true;
            }

            //Set the skill level from level
            if(level == SkillLevel.Beginner)
            {
                skillLevel.SelectedIndex = 0; 
            }
            else if(level == SkillLevel.Intermediate)
            {
                skillLevel.SelectedIndex = 1;
            }
            else
            {
                skillLevel.SelectedIndex = 2;
            }
        }

        //Method if the button is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            //Set the correct radio button
            if(rdInvincible.Checked)
            {
                buttonChecked = rdButtons.Invincible;
            }
            else
            {
                buttonChecked = rdButtons.NoCheat;
            }

            //Set the correct skill level
            if(skillLevel.SelectedIndex == 0)
            {
                LevelSelected = SkillLevel.Beginner;
            }
            else if(skillLevel.SelectedIndex == 1)
            {
                LevelSelected = SkillLevel.Intermediate;
            }
            else
            {
                LevelSelected = SkillLevel.Advanced;
            }
        }   
    }
}
