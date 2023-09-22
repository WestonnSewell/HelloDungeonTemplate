using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{

    internal class Character
    {
        private string _name;
        private float _health;
        private float _damage;
        private float _defense;
        private float _stamina;
        private float _playerChoice;
        private Weapon _weapon;
        internal Weapon Weapon;
        private int _lives;

        public Character(string name, float health, float damage, Weapon weapon)
        {
            // initialize all stats, name health damage 

            _name = name;
            _health = health;
            _damage = damage;
            _weapon = weapon;

        }
        public virtual void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
            Console.WriteLine("Defense: " + _defense);
            Console.WriteLine("Stamina: " + _stamina);
            Console.WriteLine("Lives: " + _lives);
        }
        public void TakeDamage(float damage)
        {
            _health -= damage - _defense;
        }
        public float GetDamage()
        {
            return _damage;
        }

        public float GetHealth()
        {
            return _health;
        }
        public Weapon GetWeapon()
        {
            return _weapon;
        }
        public string GetName()
        {
            return _name;
        }
        public float GetDefense()
        {
            return _defense;
        }
    }
}
