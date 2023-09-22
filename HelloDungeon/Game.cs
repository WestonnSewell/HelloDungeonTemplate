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
    struct Weapon
    {
        public string Name;
        public float Health;
        public float Damage;
    }
    class Game
    {

        bool gameOver;
        int currentScene = 1;
        Character JoePable;
        Character JohnCena;
        Character LucyJill;
        Player PlayerCharacter;
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
        // chooses player
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

                PlayerCharacter = new Player(JoePable.GetName(), JoePable.GetDamage(), JoePable.GetDefense(), JoePable.GetWeapon());
            }
            else if (playerChoice == "2")
            {
                Console.WriteLine("You chose John!");

                PlayerCharacter = new Player(JohnCena.GetName(), JohnCena.GetDamage(), JohnCena.GetDefense(), JohnCena.GetWeapon());
            }
            else if (playerChoice == "3")
            {
                Console.WriteLine("You chose Lucy!");

                PlayerCharacter = new Player(LucyJill.GetName(), LucyJill.GetDamage(), LucyJill.GetDefense(), LucyJill.GetWeapon());
            }

            else
            {
                Console.WriteLine("Invalid.");
                Console.Clear();
                return;
            }
            PlayerCharacter.PrintStats();
            Console.Clear();

        }

        // initiates attack
        float Attack(Character attacker, Character defender)
        {
            float totalDamage = attacker.GetWeapon().Damage - defender.GetDefense();
            return defender.GetHealth() - totalDamage;
        }

        void Fight(ref Character monster2)
        {

            string battleChoice = GetInput("What would you like to do?", "1. Fight", "2. Run");

            if (battleChoice == "1")
            {
                monster2.TakeDamage ( Attack (PlayerCharacter, monster2));
                Console.WriteLine("You used" + PlayerCharacter.GetWeapon().Name + "!");
            }

            if (battleChoice == "2")
            {
                Console.WriteLine("You ran away!");
                currentScene = 1;
                return;
            }

            monster2.PrintStats();
            monster2.PrintStats();

            Console.WriteLine(monster2.GetName() + " punches " + monster2.GetName() + "!");
            monster2.TakeDamage (Attack(monster2, monster2));
            Console.ReadKey(true);

            monster2.PrintStats();
            monster2.PrintStats();

            Console.WriteLine(monster2.GetName() + " punches " + monster2.GetName() + "!");
            monster2.TakeDamage(Attack(monster2, monster2));
            Console.ReadKey(true);

            monster2.PrintStats();
            monster2.PrintStats();
        }
        // heals player
        float Heal(Character monster, float healAmount)
        {
            float newHealth = monster.GetHealth() + healAmount;

            return newHealth;
        }
        // initiates battle
        void BattleScene()
        {
            Fight(ref Enemies[CurrentEnemyIndex]);

            Console.Clear();

            if (PlayerCharacter.GetHealth() <= 0 || Enemies[CurrentEnemyIndex].GetHealth() <= 0)
            {
                currentScene = 2;
            }
        }

        void WinResultsScene()
        {

            if (PlayerCharacter.GetHealth() > 0 && Enemies[CurrentEnemyIndex].GetHealth() > 0)
            {
                Console.WriteLine("The winner is: " + JoePable.GetName());
                currentScene = 1;
                CurrentEnemyIndex++;

                if (CurrentEnemyIndex >= Enemies.Length) ;
                {
                    gameOver = true;
                }
            }
            else if (Enemies[CurrentEnemyIndex].GetHealth() > 0 && PlayerCharacter.GetHealth() <= 0)
            {
                Console.WriteLine("The winner is: " + Enemies[CurrentEnemyIndex].GetName());
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

            JoePable = new Character("Joe Pable", 2119f, 246.90f, Sword);

            JohnCena = new Character("John Cena", 2120f, 246.91f, Sword);

            LucyJill = new Character("Lucy Jill", 2118f, 246.89f, Sword);

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