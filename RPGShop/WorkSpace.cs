using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGShop
{
    //mount and blade quality if time
    struct shopItem {
        public string item;
        public int value;
    }
    struct playerItem {
        public string item;
        public int value;
    }
    struct playerStats
    {
        public int health;
        public int gold;
        public float defence;
        public float attack;
        public string name;
        public string equipedHelm;
        public string equipeChest;
        public string equipeLeg;
        public string equipeGaunt;
        public string equipedWeapon;
    }

    class WorkSpace
    {
        /// <summary>
        /// Holds all of the item data and the items value for the Shop Keep
        /// </summary>
        public static shopItem[] shopkeep = new shopItem[6];
        /// <summary>
        /// Holds all of the item data and the items value for the Player
        /// </summary>
        public static playerItem[] player = new playerItem[50];
        public static TextFile file = new TextFile();
        public static playerStats plyrStat = new playerStats();
        public static bool run = true;
        static void Main()
        {
            bool tutorial = true;
            string input;
            file.readFilePlayer();
            firstEquip();
            Console.WriteLine("Welcome to a short RPG adventure game.\nPlease enter you name adventurer:");
            plyrStat.name = Console.ReadLine();
            Console.WriteLine($"Welcome {plyrStat.name}! Today, your adventure begins!");
            Console.WriteLine("Would you like to start off with a sword or an axe?");
            while (true)
            {
                input = Console.ReadLine().ToLower();
                if (input == "axe")
                {
                    plyrStat.equipedWeapon = "Chipped Wooden Axe";
                    for (int i = 0; i <player.Length; i ++)
                    {
                        if (player[i].item == null)
                        {
                            player[i].item = "Chipped Wooden Axe";
                            player[i].value = Weapons.checkValue("Chipped Wooden Axe");
                            break;
                        }
                    }
                    break;
                }else if (input == "sword")
                {
                    plyrStat.equipedWeapon = "Chipped Wooden Sword";
                    for (int i = 0; i < player.Length; i++)
                    {
                        if (player[i].item == null)
                        {
                            player[i].item = "Chipped Wooden Sword";
                            player[i].value = Weapons.checkValue("Chipped Wooden Sword");
                            break;
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter again:");
                }
            }
            plyrStat.health = 100;
            Console.WriteLine("You arrive in town. You notice an inn, an equipment shop, what appears to be a witches hut,\nor travel into the forest beyond.");
            while (run)
            {
                bool done = false;
                bool shopDone = false;
                if (!tutorial && !done)
                {
                    Console.WriteLine("You arrive back in town. You can now check your \'inventory\' and your \'gold\'!");
                    done = false;
                }
                else
                {
                    Console.WriteLine("You should probably visit the equipment shop first!");
                }
                Console.WriteLine("Where would you like to go?");
                input = Console.ReadLine().ToLower().Trim();
                if (input == "inn")
                {
                    Console.WriteLine("PUB!(WIP)");
                }
                else if (input == "shop")
                {
                    Console.WriteLine("You enter the shop.");
                    
                    if (tutorial && !shopDone)
                    {
                        Console.WriteLine("Shop Keep: Welcome to my shop! Here, you can buy and sell equipment.");
                        Console.WriteLine("Shop Keep: Would you like a more in depth look at how you would do this?.");
                        input = Console.ReadLine().ToLower().Trim();
                        if (input == "yes")
                        {
                            Console.WriteLine("Shop Keep: Alright! Like i said previously, you can buy and sell equiopment here.\nTo buy items(WIP)");
                        }
                        else
                        {
                            Console.WriteLine("Shop Keep: Oh well, I guess you already know how to use shops.\n No big deal I suppose.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Shop Keep: Ah, you\'re back! What can I do for ya?");
                        input = Console.ReadLine().ToLower().Trim();
                    }
                }
                else if (input == "hut" || input == "witch")
                {
                    Console.WriteLine("Um, spells?(WIP)");
                }
                else if (input == "forest")
                {
                    Console.WriteLine("MONSTERS!(WIP)");
                }
                else if(input == "inventory" || input == "equipment")
                {
                    Console.WriteLine("(WIP)");

                }
                else if(input == "gold"||input == "bal"||input == "balance")
                {
                    Console.WriteLine($"You have {plyrStat.gold} gold!\nDon't go spend it all in one place.");
                }
                else if (input == "help")
                {
                    Console.WriteLine("You can type \'inn\' to go to the inn.\nYou can type \'shop\' to visit the equipment shop.");
                    Console.WriteLine("You can type \'witch\' or \'hut\' to go to the witches hut.\nYou can type \'forest\' to delve into the forest.");
                    if (!tutorial) Console.WriteLine("You can type \'inventory\' or \'equipment\' to look at your inventory.\nYou can type \'bal\',\'balance\', or \'gold\' to view you total gold!");
                }else if (input == "kill")
                {
                    death();
                    run = false;
                }
                else
                {
                    Console.WriteLine("I didn't quite understand that. Please recheck your spelling, or type an actual place.");
                    Console.WriteLine("You can also type \'help\' for assistance in where to go!");
                }

            }
        }

        private static void sellShop()
        {
            string input;
            Console.WriteLine("So, what would ya like to sell?");
            input = Console.ReadLine().ToLower().Trim();
            string[] items = new string[50];
            int[] val = new int[50];
            int x = 0;
            if (input == "helmet"||input == "helmets")
            {
                foreach (playerItem i in player)
                {
                    string[] _item = i.item.Split(' ');
                    if(_item[2] == "Helmet")
                    {
                        items[x] = i.item;
                        if(i.value == 0)
                        {
                            val[x] = Weapons.checkValue(i.item);
                        }
                    }
                }
            }
        }
        private static void buyShop()
        {
            string input;
            Console.WriteLine($"You have {plyrStat.gold} gold!");
            Console.WriteLine("Shop Keep: Here's my daily stock!");
            string[] items = new string[shopkeep.Length];
            int[] val = new int[shopkeep.Length];
            int x = 0;
            foreach (shopItem i in shopkeep)
            {
                if (i.item != null) {
                    Console.WriteLine($"{i.item} for {i.value} gold.");
                    items[x] = i.item;
                    val[x] = i.value;
                }
                x++;
            }
            Console.WriteLine("What would you like to buy?");
            while (true)
            {
                input = Console.ReadLine().ToLower().Trim();
                if (input == "helmet" && items[0] != null && plyrStat.gold >= val[0])
                {
                    Console.WriteLine($"So, the {items[0]} strikes you're fancy, eh? So be it!");
                    for (int i = 0; i < 50; i++)
                    {
                        if (player[i].item == null)
                        {
                            player[i].item = items[0];
                            player[i].value = (val[0]-25) <= 0? 0:val[0]-25;
                        }
                        else
                        {
                            if (i == 49)
                            {
                                Console.WriteLine("Shop Keep: It looks like you are full on inventory space, you should probably sell some items.");
                            }
                        }
                    }
                    break;
                }else if (input == "chestpiece" && items[1] != null && plyrStat.gold >= val[1])
                {
                    Console.WriteLine($"So, the {items[1]} strikes you're fancy, eh? So be it!");
                    for (int i = 0; i < 50; i++)
                    {
                        if (player[i].item == null)
                        {
                            player[i].item = items[1];
                            player[i].value = (val[1] - 25) <= 0 ? 0 : val[1] - 25;
                        }
                        else
                        {
                            if (i == 49)
                            {
                                Console.WriteLine("Shop Keep: It looks like you are full on inventory space, you should probably sell some items.");
                            }
                        }
                    }
                    break;
                }
                else if (input == "gauntlets" && items[2] != null && plyrStat.gold >= val[2])
                {
                    Console.WriteLine($"So, the {items[2]} strikes you're fancy, eh? So be it!");
                    for (int i = 0; i < 50; i++)
                    {
                        if (player[i].item == null)
                        {
                            player[i].item = items[2];
                            player[i].value = (val[2] - 25) <= 0 ? 0 : val[2] - 25;
                        }
                        else
                        {
                            if (i == 49)
                            {
                                Console.WriteLine("Shop Keep: It looks like you are full on inventory space, you should probably sell some items.");
                            }
                        }
                    }
                    break;
                }
                else if (input == "leggings" && items[3] != null && plyrStat.gold >= val[3])
                {
                    Console.WriteLine($"So, the {items[3]} strikes you're fancy, eh? So be it!");
                    for (int i = 0; i < 50; i++)
                    {
                        if (player[i].item == null)
                        {
                            player[i].item = items[3];
                            player[i].value = (val[3] - 25) <= 0 ? 0 : val[3] - 25;
                        }
                        else
                        {
                            if (i == 49)
                            {
                                Console.WriteLine("Shop Keep: It looks like you are full on inventory space, you should probably sell some items.");
                            }
                        }
                    }
                    break;
                }
                else if (input == "weapon" && items[4] != null && plyrStat.gold >= val[4])
                {
                    Console.WriteLine($"So, you enjoy the gleam of the {items[4]}, do ya? So be it!");
                    for (int i = 0; i < 50; i++)
                    {
                        if (player[i].item == null)
                        {
                            player[i].item = items[4];
                            player[i].value = (val[4] - 25) <= 0 ? 0 : val[4] - 25;
                        }
                        else
                        {
                            if (i == 49)
                            {
                                Console.WriteLine("Shop Keep: It looks like you are full on inventory space, you should probably sell some items.");
                            }
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("I didn't quite get that, can you enter again?");
                }
            }
            Console.WriteLine("Thanks for doing buisness!");
        }

        private static void checkPrice()
        {
            for (int i = 0; i < 50; i++)
            {
                if (player[i].item!= null && player[i].value == 0)
                {
                    player[i].value = Weapons.checkValue(player[i].item);
                    player[i].value = Weapons.checkValue(player[i].item);
                }
            }
        }

        private static void death()
        {
            Console.WriteLine("It looks like you have died, better luck next time!");
            file.reset();
            Console.ReadLine();
        }
        private static void firstEquip()
        {
            foreach (playerItem i in player)
            {
                if (i.item != null)
                {
                    string[] _item = i.item.Split(' ');
                    if (plyrStat.equipeChest == null && _item[2] == "Chestpiece")
                    {
                        plyrStat.equipeChest = i.item;
                    }
                    if (plyrStat.equipeGaunt == null && _item[2] == "Gauntlets")
                    {
                        plyrStat.equipeGaunt = i.item;
                    }
                    if (plyrStat.equipeLeg == null && _item[2] == "Leggings")
                    {
                        plyrStat.equipeLeg= i.item;
                    }
                    if (plyrStat.equipedHelm == null && _item[2] == "Helmet")
                    {
                        plyrStat.equipedHelm = i.item;
                    }
                }
            }
        }
    }
}
