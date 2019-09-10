using System;

namespace RPGShop
{
    class Enemies
    {
        public static float health = 100;
        public static float speed = 1.0f;
        public static float defense = 1.0f;
        public static float attack = 1.0f;
        public static string input;
        public static float setHealth(float change)
        {
            float _health = 100 *change;
            return _health;
        }
        public static float changeSpeed(float change)
        {
            float _speed = 1f * change;
            return _speed;
        }
        public static float changeDef(float change)
        {
            float _def = 1f * change;
            return _def;
        }
        public static float changeAttack(float change)
        {
            float _atck = 1f * change;
            return _atck;

        }
        
    }

    /// <summary>
    /// To be fought in the CAve
    /// </summary>
    class Giant : Enemies
    {
        public Giant() : base()
        {
            int dif =0;
            bool isAttack;
            health = setHealth(2);
            speed = changeSpeed(.5f);
            defense = changeDef(1.5f);
            attack = changeAttack(1.75f);
            Console.WriteLine("\nYou march into the forest to the location of the shrine.\n");
            Console.WriteLine("You notice a low rumbling coming from somewhere in the shrine and go to investigate.\nWhen you go inside, you see a sleeping Giant.\nWil you attack?");
            while (true)
            {
                input = Console.ReadLine().Trim().ToLower();
                if (input == "no" || input == "n")
                {
                    Console.WriteLine("\nYou decide not to attack the sleeping giant.\nIn almost an instant, the giant sneezes.\nYou recoil and shout in fear, not understanding what just happened.");
                    Console.WriteLine("\nAfter you let out the shout, the giant begins to stir, and you realize the severity of your situation.\nYou now have no choice but to fight the giant.");
                    isAttack = false;
                    break;
                }
                else if (input == "yes" || input == "y")
                {
                    Console.WriteLine("You walk up to the giant, still asleep, with your weapon in hand.\nYou raise it up above your head and deal a massive blow to the giant.");
                    Console.WriteLine($"You did {(WorkSpace.plyrStat.attack * WorkSpace.baseAttack * 2) - defense} damage!");
                    health -= (WorkSpace.plyrStat.attack * WorkSpace.baseAttack * 2) - defense;
                    Console.WriteLine("\nThe giant is enraged at what you have done and turns toward you with menace in it's eyes.");
                    isAttack = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter again");
                }
            }
            if ((speed*2)<= WorkSpace.plyrStat.speed)//Thanks edward
            {
                dif = 2;
            }
            while (true)
            {
                if (health<=0)
                {
                    Console.WriteLine("You killed the giant. Good job! LOOT!");

                    break;
                }
                else if (WorkSpace.plyrStat.health <= 0)
                {
                    Console.WriteLine("You got squished to death by the giant.");
                    break;
                }
                else
                {
                    if (isAttack)
                    {
                        for (int i = 0; i<dif; i++)
                        {
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The giant swings his club.");
                        WorkSpace.plyrStat.health -= (attack * WorkSpace.baseAttack)-WorkSpace.plyrStat.defence;
                    }
                }
            }
        }
    }

    /// <summary>
    /// To be fought in the Maze
    /// </summary>
    class Minotaur : Enemies
    {
        public Minotaur() : base()
        {
            health = setHealth(1);
            speed = changeSpeed(1.25f);
            defense = changeDef(1f);
            attack = changeAttack(1.15f);
            Console.WriteLine("WIP");
        }
    }
}
