using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {

        struct Character
        {
            public string Name;
            public float Health;
            public float Damage;
            public float Defense;
            public float Stamina;
            public float playerChoice;
            public Weapon weapon;
        }
        struct Weapon
        {
            public string Name;
            public float Health;
            public float Damage;
        }
        bool gameOver;
        int currentScene = 1;
        Character JoePable;
        Character JohnCena;
        Character LucyJill;
        Character Player;
        Weapon Sword;
        public string GetInput(string prompt , string choice1 , string choice2)
        {
            Console.WriteLine(prompt);
            Console.WriteLine(choice1);
            Console.WriteLine(choice2); 
            string playerchoice = Console.ReadLine();
            return playerchoice;
        }
        public void NamingScene()
        {
            currentScene = 2;
            Console.WriteLine("Choose 1 for Joe, 2 for John, or 3 for Lucy");
            Console.Write(">");
            string playerChoice;
            playerChoice = Console.ReadLine();

            if (playerChoice == "1")
            {
                Console.WriteLine("You chose Joe!");

                Player = JoePable;
            }
            else if (playerChoice == "2")
            {
                Console.WriteLine("You chose John!");

                Player = JohnCena;
            }
            else if (playerChoice == "3")
            {
                Console.WriteLine("You chose Lucy!");

                Player = LucyJill;
            }

            else
            {
                Console.WriteLine("Invalid.");
                Console.Clear();
                return;
            }
            PrintStats(Player);
            Console.Clear();

        }
        void PrintStats(Character character)
        {
            Console.WriteLine("Name: " + character.Name);
            Console.WriteLine("Health: " + character.Health);
            Console.WriteLine("Damage: " + character.Damage);
            Console.WriteLine("Defense: " + character.Defense);
            Console.WriteLine("Stamina: " + character.Stamina);
        }

        float Attack(Character attacker, Character defender)
        {
            float totalDamage = attacker.weapon.Damage - defender.Defense;
            return defender.Health - totalDamage;
        }

        void Fight(ref Character monster1, ref Character monster2)
        {


            string battleChoice = GetInput("What would you like to do?", "1. Fight", "2. Run");

            if (battleChoice == "1")
            {
                monster2.Health = Attack(Player, monster2);
                Console.WriteLine("You used" + Player.weapon.Name + "!");
            }

            if (battleChoice == "2")
            {
                Console.WriteLine("You ran away!");
                currentScene = 1;
                return;
            }

            PrintStats(monster1);
            PrintStats(monster2);

            Console.WriteLine(monster1.Name + " punches " + monster2.Name + "!");
            monster2.Health = Attack(monster1, monster2);
            Console.ReadKey(true);

            PrintStats(monster1);
            PrintStats(monster2);

            Console.WriteLine(monster2.Name + " punches " + monster1.Name + "!");
            monster1.Health = Attack(monster2, monster1);
            Console.ReadKey(true);

            PrintStats(monster1);
            PrintStats(monster2);
        }

        float Heal(Character monster, float healAmount)
        {
            float newHealth = monster.Health + healAmount;

            return newHealth;
        }
        void BattleScene()
        {

            Fight(ref JoePable, ref LucyJill);

            Console.Clear();

            if (JoePable.Health > 0 && LucyJill.Health > 0)
            {
                currentScene = 3;
            }
        }

        void WinResultsScene()
        {

            if (JoePable.Health > 0 && LucyJill.Health > 0)
            {
                Console.WriteLine("The winner is: " + JoePable.Name);
            }
        }
        void Start()
        {
            ///Make a function that can heal a monster. The function should take in the monster
            ///that needs to be healed and the amount to heal it by. Return the new health of
            ///the monster.
            Sword.Name = "Planet Slasher";
            Sword.Health = 2119f;
            Sword.Damage = 246.90f;



            JoePable.Name = "JoePable";
            JoePable.Health = 2119f;
            JoePable.Damage = 246.90f;
            JoePable.Defense = .9f;
            JoePable.Stamina = 3;
            JoePable.weapon = Sword;

            JohnCena.Name = "JOHN.....cena";
            JohnCena.Health = 2120f;
            JohnCena.Damage = 246.91f;
            JohnCena.Defense = 1f;
            JohnCena.Stamina = 4f;
            JohnCena.weapon = Sword;

            LucyJill.Name = "Lucy Jill Dirtbag Biden";
            LucyJill.Health = 2118f;
            LucyJill.Damage = 246.89f;
            LucyJill.Defense = .8f;
            LucyJill.Stamina = 0f;
            LucyJill.weapon = Sword;
        }



        void Update()
        {
            if (currentScene == 1)
            {
                NamingScene();
            }
            if (currentScene == 2)
            {
                BattleScene();
            }
            else if (currentScene == 3)
            {
                WinResultsScene();
            }
        }
        public void End()
        {
            Console.WriteLine("Thanks for playing!");
        }


        public void Run()
        {
            // make a new scene for character selection. Display all options for charactars that have been made.
            // when selected, display the player's current status.
            // in battle scene, give player the ability to fight another character.
            // give the choice to attack or another extra mechanic like defense or running away.

            //start - called before first loop, used to initialize variables at the beginning of game.
            //update - called every time game loops, used for updating game logic
            //end - called after main game loop exits

            Start();




            while (gameOver == false)
            {
                Update();
            }
            End();

        }
    }


}