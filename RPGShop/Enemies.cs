﻿using System;

namespace RPGShop
{
    /// <summary>
    /// the base code
    /// </summary>
    class Explore
    {
        public struct enemy
        {
            public string name;
            public float health;
            public float defense;
            public float speed;
            public float attack;
            public int gold;
        }
        public static int enemies;
        public static int totalGold;
        public static string input;
        public static Random rand = new Random();
    }
    /// <summary>
    /// The base code for every boss fight
    /// </summary>
    class Boss
    {
        public static float health = 100;
        public static float speed = 1.0f;
        public static float defense = 1.0f;
        public static float attack = 1.0f;
        public static string input;
        public static Random rand = new Random();
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
    /// To be fought in the Cave(Working)
    /// </summary>
    class Giant : Boss
    {
        
        public Giant() : base()
        {
            int dif =0;
            bool isAttack;
            bool done = false;
            health = setHealth(2);
            speed = changeSpeed(.5f);
            defense = changeDef(1.5f);
            attack = changeAttack(1.75f);
            Console.WriteLine("\nYou march into the forest to the location of the shrine.\n");
            Console.WriteLine("You notice a low rumbling coming from somewhere in the shrine and go to investigate.\nWhen you go inside, you see a sleeping giant.\nWil you attack?");
            while (true)
            {
                input = Console.ReadLine().Trim();
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
            if ((speed * 2) <= WorkSpace.plyrStat.speed)//Thanks edward
            {
                dif = 2;
            }
            while (true)
            {
                if (health<=0)
                {
                    Console.Clear();
                    Console.WriteLine("\nYou killed the giant. Good job!");
                    int gold = rand.Next(350,500);
                    Console.WriteLine($"\nYou gain {gold} gold!");
                    WorkSpace.plyrStat.gold += gold;
                    break;
                }
                else if (WorkSpace.plyrStat.health <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("\nThe giant squished you with his giant club.");
                    break;
                }
                else
                {
                    if (isAttack)
                    {
                        for (int i = 0; i<dif; i++)
                        {
                            if (health>0) {
                                Console.WriteLine($"\nYou have {WorkSpace.plyrStat.health} health.");
                                Console.WriteLine($"The giant has {health} health");
                                Console.WriteLine("\n[1]Attack or [2]Potions:");
                                while (true)
                                {
                                    input = Console.ReadLine().Trim();
                                    if (input == "1")
                                    {
                                        string[] item = WorkSpace.plyrStat.equipedWeapon.Split(' ');
                                        Console.WriteLine($"\nYou swing your {item[2]}.\nYou did {(WorkSpace.plyrStat.attack * WorkSpace.baseAttack) - defense} damage to the giant!");
                                        health -= (WorkSpace.plyrStat.attack * WorkSpace.baseAttack) - defense;
                                        break;
                                    } else if (input == "2")
                                    {
                                        if (WorkSpace.plyrStat.potionS == 0 && WorkSpace.plyrStat.potionM == 0 && WorkSpace.plyrStat.potionL == 0)
                                        {
                                            Console.WriteLine("\nYou don\'t seem to have any potions.\nYou turn was wasted.");
                                            break;
                                        }
                                        Console.WriteLine($"\nYou have:\n[1] Small: {WorkSpace.plyrStat.potionS}\n[2] Normal: {WorkSpace.plyrStat.potionM}\n[3] Large: {WorkSpace.plyrStat.potionL}");
                                        Console.WriteLine("\nWhich potion would you like to use:");
                                        while (true)
                                        {
                                            input = Console.ReadLine();
                                            if (input == "1")
                                            {
                                                if (WorkSpace.plyrStat.potionS > 0)
                                                {
                                                    Console.WriteLine("\nRestored 10 health");
                                                    WorkSpace.plyrStat.health += 10;
                                                    if (WorkSpace.plyrStat.health > 100)
                                                    {
                                                        WorkSpace.plyrStat.health = 100;
                                                    }
                                                    WorkSpace.plyrStat.potionS--;
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nYou don\'t seem to have any small potions.\n\nEnter again:");
                                                }
                                            }
                                            else if (input == "2")
                                            {
                                                if (WorkSpace.plyrStat.potionM > 0)
                                                {
                                                    Console.WriteLine("\nRestored 25 health");
                                                    WorkSpace.plyrStat.health += 25;
                                                    if (WorkSpace.plyrStat.health > 100)
                                                    {
                                                        WorkSpace.plyrStat.health = 100;
                                                    }
                                                    WorkSpace.plyrStat.potionM--;
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nYou don\'t seem to have any normal potions.\n\nEnter again:");
                                                }
                                            }
                                            else if (input == "3")
                                            {
                                                if (WorkSpace.plyrStat.potionL > 0)
                                                {
                                                    Console.WriteLine("\nRestored 50 health");
                                                    WorkSpace.plyrStat.health += 50;
                                                    if (WorkSpace.plyrStat.health > 100)
                                                    {
                                                        WorkSpace.plyrStat.health = 100;
                                                    }
                                                    WorkSpace.plyrStat.potionL--;
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nYou don\'t seem to have any large potions.\n\nEnter again:");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nPlease enter again:");
                                            }
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nPlease enter again:");
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        isAttack = false;
                    }
                    else
                    {
                        Console.WriteLine($"\nYou have {WorkSpace.plyrStat.health} health.");
                        Console.WriteLine($"The giant has {health} health");
                        Console.WriteLine($"\nThe giant swings his club.\nYou took {(attack * WorkSpace.baseAttack) - WorkSpace.plyrStat.defence} damage!");
                        WorkSpace.plyrStat.health -= (attack * WorkSpace.baseAttack)-WorkSpace.plyrStat.defence;
                        if ((attack * WorkSpace.baseAttack) - WorkSpace.plyrStat.defence>=30 && !done)
                        {
                            Console.WriteLine("\nMaybe you shouldn\'t have decided to fight this....");
                            done = true;
                        }
                        isAttack = true;
                    }
                }
            }
        }
    }

    /// <summary>
    /// To be fought in the Maze
    /// </summary>
    class Minotaur : Boss
    {
        public Minotaur() : base()
        {
            health = setHealth(1);
            speed = changeSpeed(1.25f);
            defense = changeDef(1f);
            attack = changeAttack(1.15f);
            Console.WriteLine("\nWIP\n\nNo free-be.");
        }
    }
    class Woods : Explore
    {
        public Woods() : base()
        {
            enemies = 7;
            enemy[] _enemies = new enemy[enemies];
            float x = 1f;
            for (int i = 0; i < enemies; i++)
            {
                _enemies[i].health = 15 * x;
                _enemies[i].attack = .5f * x;
                _enemies[i].defense = 1 * x;
                _enemies[i].speed = 1f;
                _enemies[i].name = randomEnemy();
                _enemies[i].gold = rand.Next(5+(5*i),10+(5*i));
                x += .15f;
            }
            Console.WriteLine("\nYou enter the forest and make your way deeper into the forest.");
            bool done = false;
            for (int i = 0;i < enemies; i ++)
            {
                bool attack = true;
                Console.WriteLine($"\nAs you continue are walking, you come across a {_enemies[i].name}");
                while (true)//battle
                {
                    if (WorkSpace.plyrStat.health<=0)
                    {
                        Console.Clear();
                        Console.WriteLine($"\nIt seems like the {_enemies[i].name} got the better of you.");
                        done = true;
                        break;
                    }
                    else if (_enemies[i].health <=0)
                    {
                        Console.Clear();
                        Console.WriteLine($"\nYou have slain {_enemies[i].name}.\nYou gain {_enemies[i].gold} gold!");
                        WorkSpace.plyrStat.gold += _enemies[i].gold;
                        totalGold += _enemies[i].gold;
                        break;
                    }
                    else if (attack)
                    {
                        Console.WriteLine($"\nYou have {WorkSpace.plyrStat.health} health.");
                        Console.WriteLine("\n[1]Attack or [2]Potions:");
                        while (true)
                        {
                            input = Console.ReadLine().Trim();
                            if (input == "1")
                            {
                                string[] item = WorkSpace.plyrStat.equipedWeapon.Split(' ');
                                Console.WriteLine($"\nYou swing your {item[2]}.\nYou did {(WorkSpace.plyrStat.attack * WorkSpace.baseAttack) - _enemies[i].defense} damage to the {_enemies[i].name}!");
                                _enemies[i].health -= (WorkSpace.plyrStat.attack * WorkSpace.baseAttack) - _enemies[i].defense;
                                break;
                            }
                            else if (input == "2")
                            {
                                if (WorkSpace.plyrStat.potionS == 0 && WorkSpace.plyrStat.potionM == 0 && WorkSpace.plyrStat.potionL == 0)
                                {
                                    Console.WriteLine("\nYou don\'t seem to have any potions.\nYou turn was wasted.");
                                    break;
                                }
                                Console.WriteLine($"\nYou have:\n[1] Small: {WorkSpace.plyrStat.potionS}\n[2] Normal: {WorkSpace.plyrStat.potionM}\n[3] Large: {WorkSpace.plyrStat.potionL}");
                                Console.WriteLine("\nWhich potion would you like to use:");
                                while (true)
                                {
                                    input = Console.ReadLine();
                                    if (input == "1")
                                    {
                                        if (WorkSpace.plyrStat.potionS > 0)
                                        {
                                            Console.WriteLine("\nRestored 10 health");
                                            WorkSpace.plyrStat.health += 10;
                                            if (WorkSpace.plyrStat.health > 100)
                                            {
                                                WorkSpace.plyrStat.health = 100;
                                            }
                                            WorkSpace.plyrStat.potionS--;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nYou don\'t seem to have any small potions.\n\nEnter again:");
                                        }
                                    }
                                    else if (input == "2")
                                    {
                                        if (WorkSpace.plyrStat.potionM > 0)
                                        {
                                            Console.WriteLine("\nRestored 25 health");
                                            WorkSpace.plyrStat.health += 25;
                                            if (WorkSpace.plyrStat.health > 100)
                                            {
                                                WorkSpace.plyrStat.health = 100;
                                            }
                                            WorkSpace.plyrStat.potionM--;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nYou don\'t seem to have any normal potions.\n\nEnter again:");
                                        }
                                    }
                                    else if (input == "3")
                                    {
                                        if (WorkSpace.plyrStat.potionL > 0)
                                        {
                                            Console.WriteLine("\nRestored 50 health");
                                            WorkSpace.plyrStat.health += 50;
                                            if (WorkSpace.plyrStat.health > 100)
                                            {
                                                WorkSpace.plyrStat.health = 100;
                                            }
                                            WorkSpace.plyrStat.potionL--;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nYou don\'t seem to have any large potions.\n\nEnter again:");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nPlease enter again:");
                                    }
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nPlease enter again:");
                            }
                        }
                        attack = false;
                    }
                    else
                    {
                        Console.WriteLine($"The {_enemies[i].name} has {_enemies[i].health} health");
                        Console.WriteLine($"\nThe {_enemies[i].name} attacks you.\nYou took {(_enemies[i].attack * WorkSpace.baseAttack) - WorkSpace.plyrStat.defence} damage!");
                        WorkSpace.plyrStat.health -= (_enemies[i].attack * WorkSpace.baseAttack) - WorkSpace.plyrStat.defence;
                        if ((_enemies[i].attack * WorkSpace.baseAttack) - WorkSpace.plyrStat.defence >= 30 && !done)
                        {
                            Console.WriteLine("\nMaybe you shouldn\'t have decided to fight this....");
                            done = true;
                        }
                        attack = true;
                    }
                }
                if (i < enemies - 1)
                {
                    Console.WriteLine("\nThere seems to be more enemies.\nWould you like to continue?");
                    while (true)
                    {
                        input = Console.ReadLine();
                        if (input == "yes" || input == "y")
                        {
                            Console.WriteLine("\nAlright, let\'s continue!");
                            break;
                        }
                        else if (input == "no" || input == "n")
                        {
                            Console.WriteLine("\nAlright, come back later!");
                            Console.WriteLine($"\nYou gained {totalGold} gold!");
                            done = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nPlease enter again");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"\nYou\'ve killed all the enemies!");
                    Console.WriteLine($"\nYou gained {totalGold} gold!");
                    break;
                }
                if (done)
                {
                    break;
                }
            }
        }
        public static string randomEnemy()
        {
            string name = "";
            int _rand = rand.Next(0,4);
            if (_rand == 0)
            {
                name = "Rabid Squirrel";
            }
            else if (_rand == 1)
            {
                name = "Infected Racoon";
            }
            else if (_rand == 2)
            {
                name = "Sickly Rabit";
            }
            else if (_rand == 3)
            {
                name = "Screaming Monkey";
            }
            else if (_rand == 4)
            {
                name = "Porcupine";
            }
            return name;
        }
    }
}
