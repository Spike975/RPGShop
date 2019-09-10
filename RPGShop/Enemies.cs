using System;

namespace RPGShop
{
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
        public static Random rand = new Random();
    }
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
            if ((speed * 2) <= WorkSpace.plyrStat.speed)//Thanks edward
            {
                dif = 2;
            }
            while (true)
            {
                if (health<=0)
                {
                    int i = rand.Next(0,4);
                    Console.WriteLine("\nYou killed the giant. Good job!\nLet\'s see what you got!");
                    if (i == 0)
                    {
                        for (int x = 0; x < 50; x++) {
                            if (WorkSpace.player[x].item == null) {
                                WorkSpace.player[x].item = Armor.randHelm(3,5,2,4);
                                Console.WriteLine($"You found a {WorkSpace.player[x].item}!");
                                break;
                            }
                        }
                    }
                    else if(i == 1)
                    {
                        for (int x = 0; x < 50; x++)
                        {
                            if (WorkSpace.player[x].item == null)
                            {
                                WorkSpace.player[x].item = Armor.randChest(3, 5, 2, 4);
                                Console.WriteLine($"You found a {WorkSpace.player[x].item}!");
                                break;
                            }
                        }
                    }
                    else if (i == 2)
                    {
                        for (int x = 0; x < 50; x++)
                        {
                            if (WorkSpace.player[x].item == null)
                            {
                                WorkSpace.player[x].item = Armor.randGaunt(3, 5, 2, 4);
                                Console.WriteLine($"You found a pair of {WorkSpace.player[x].item}!");
                                break;
                            }
                        }
                    }
                    else if (i == 3)
                    {
                        for (int x = 0; x < 50; x++)
                        {
                            if (WorkSpace.player[x].item == null)
                            {
                                WorkSpace.player[x].item = Armor.randLeg(3, 5, 2, 4);
                                Console.WriteLine($"You found a pair of {WorkSpace.player[x].item}!");
                                break;
                            }
                        }
                    }
                    else if (i == 4)
                    {
                        for (int x = 0; x < 50; x++)
                        {
                            if (WorkSpace.player[x].item == null)
                            {
                                WorkSpace.player[x].item = Weapons.randCreation(4,7,3,6,2,3);
                                Console.WriteLine($"You found a {WorkSpace.player[x].item}!");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("IDK how, but you broke the game...");
                    }
                    break;
                }
                else if (WorkSpace.plyrStat.health <= 0)
                {
                    Console.WriteLine("\nThe giant squished you with his giant club.");
                    break;
                }
                else
                {
                    if (isAttack)
                    {
                        for (int i = 0; i<dif; i++)
                        {
                            Console.WriteLine($"\nYou have {WorkSpace.plyrStat.health} health.");
                            Console.WriteLine("\nAttack or Potions:");
                            while (true)
                            {
                                input = Console.ReadLine().Trim().ToLower();
                                if (input == "attack")
                                {
                                    string[] item = WorkSpace.plyrStat.equipedWeapon.Split(' ');
                                    Console.WriteLine($"\nYou swing your {item[2]}.\nYou did {(WorkSpace.plyrStat.attack * WorkSpace.baseAttack) - defense} damage to the giant!");
                                    health -= (WorkSpace.plyrStat.attack * WorkSpace.baseAttack) - defense;
                                    break;
                                }else if (input == "potion"||input == "potions")
                                {
                                    Console.WriteLine($"\nYou have:\n   Small: {WorkSpace.plyrStat.potionS}\n  Normal: {WorkSpace.plyrStat.potionM}\n   Large: {WorkSpace.plyrStat.potionL}");
                                    Console.WriteLine("\nWhich potion would you like to use:");
                                    while (true)
                                    {
                                        input = Console.ReadLine();
                                        if (WorkSpace.plyrStat.potionS == 0 && WorkSpace.plyrStat.potionM == 0 && WorkSpace.plyrStat.potionL == 0)
                                        {
                                            Console.WriteLine("\nYou don\'t seem to have any potions.\nYou turn was wasted.");
                                            break;
                                        }
                                        if (input == "small")
                                        {
                                            if (WorkSpace.plyrStat.potionS >0)
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
                                        else if (input == "normal")
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
                                        else if (input == "large")
                                        {
                                            if (WorkSpace.plyrStat.potionL > 0)
                                            {
                                                Console.WriteLine("\nRestored 50 health");
                                                WorkSpace.plyrStat.health += 50;
                                                if (WorkSpace.plyrStat.health>100)
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
                        isAttack = false;
                    }
                    else
                    {
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
            Console.WriteLine("WIP");
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
                _enemies[i].attack = .5f + x;
                _enemies[i].defense = 1 * x;
                _enemies[i].speed = 1f;
                _enemies[i].name = randomEnemy();
                _enemies[i].gold = 5 + (5*i);
                x += .15f;
            }
            Console.WriteLine("\nYou enter the forest and make your way deeper into the forest.");
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
                name = "";
            }
            return name;
        }
    }
}
