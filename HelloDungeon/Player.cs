﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace HelloDungeon
{
    internal class Player : Character
    {
        private string _playerChoice;
        private int _lives = 3;
        public Player(string name, float health, float damage, Weapon weapon) : base(name, health, damage, weapon)
        {
            _playerChoice = "";
        }

        public string GetInput(string prompt, string option1, string option2, string option3)
        {

        }
    }
}