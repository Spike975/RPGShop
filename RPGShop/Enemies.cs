using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGShop
{
    class Enemies
    {
        public static float health = 100;
        public static float speed = 1.0f;
        public static float defense = 5.0f;
        public static float attack = 1.0f;
        public static int done = 0;
        public static float setHealth(float change)
        {
            float _health = health *change;
            return _health;
        }
        public static float changeSpeed(float change)
        {
            float _speed = speed * change;
            return _speed;
        }
        public static float changeDef(float change)
        {
            float _def = defense * change;
            return _def;
        }
        public static float changeAttack(float change)
        {
            float _atck = attack * change;
            return _atck;

        }
        
    }

    /// <summary>
    /// To be fought in the Shrine
    /// </summary>
    class Giant : Enemies
    {
        public static string giant = "";

        public Giant() : base()
        {
            if ((done%2) == 0)
            {
                health = setHealth(2);
                speed = changeSpeed(.5f);
                defense = changeDef(1.5f);
                attack = changeAttack(1.75f);
                giant = $"{health} {speed} {defense} {attack}";
                int i = 0;
                while (true)
                {
                    Console.WriteLine(Weapons.randCreation(2,5,2,4,3,4));
                    if (i == 10) { break; }
                    i++;
                }

            }
            done++;
        }
    }

    /// <summary>
    /// To be fought in the Maze
    /// </summary>
    class Minotaur : Enemies
    {
        public Minotaur() : base()
        {
            //if (!done)
            //{

            //}
        }
    }
}
