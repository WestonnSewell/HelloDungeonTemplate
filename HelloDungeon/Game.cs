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
        int CurrentEnemyIndex = 0;
        Character[] Enemies;
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

        void Fight(ref Character monster2)
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

            PrintStats(monster2);
            PrintStats(monster2);

            Console.WriteLine(monster2.Name + " punches " + monster2.Name + "!");
            monster2.Health = Attack(monster2, monster2);
            Console.ReadKey(true);

            PrintStats(monster2);
            PrintStats(monster2);

            Console.WriteLine(monster2.Name + " punches " + monster2.Name + "!");
            monster2.Health = Attack(monster2, monster2);
            Console.ReadKey(true);

            PrintStats(monster2);
            PrintStats(monster2);
        }

        float Heal(Character monster, float healAmount)
        {
            float newHealth = monster.Health + healAmount;

            return newHealth;
        }
        void BattleScene()
        {
            Fight(ref Enemies[CurrentEnemyIndex]);

            Console.Clear();

            if (Player.Health <= 0 || Enemies[CurrentEnemyIndex].Health <= 0)
            {
                currentScene = 2;
            }
        }

        void WinResultsScene()
        {

            if (Player.Health > 0 && Enemies[CurrentEnemyIndex].Health > 0)
            {
                Console.WriteLine("The winner is: " + JoePable.Name);
                currentScene = 1;
                CurrentEnemyIndex++;

                if (CurrentEnemyIndex >= Enemies.Length) ;
                {
                    gameOver = true;
                }
            }
            else if (Enemies[CurrentEnemyIndex].Health > 0 && Player.Health <= 0)
            {
                Console.WriteLine("The winner is: " + Enemies[CurrentEnemyIndex].Name);
                currentScene = 3;
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        void EndGameScene()
        {
            string playerChoice = GetInput("You died. Play again?" , "1 for yes" , " 2 for no.");

            if (playerChoice == "1")
            {
                currentScene = 0;
            }

            else if (playerChoice == "2")
            {
                gameOver = true;
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
            //                               0         1         2
            Enemies = new Character[3] { JoePable, JohnCena, LucyJill };
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
                EndGameScene();
            }
        }
        public void End()
        {
            Console.WriteLine("Thanks for playing!");
        }

        public void PrintSum(int[]Numberz)
        {
            int biggestNumber = Numberz[0];
            for (int i = 0; i < Numberz.Length; i++)
            {
                biggestNumber += Numberz[i];
            }
            Console.WriteLine(biggestNumber);
        }
        

        public void Run()
        {
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