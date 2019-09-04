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
        public int value;//for buying, have it +25 more than the original price
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
        public static shopItem[] shopKeep = new shopItem[6];
        /// <summary>
        /// Holds all of the item data and the items value for the Player
        /// </summary>
        public static playerItem[] player = new playerItem[50];
        public static Random rand = new Random();
        public static TextFile file = new TextFile();
        public static playerStats plyrStat = new playerStats();
        public static bool run = true;
        static void Main()
        {
            bool tutorial = true;
            string input;
            file.readFilePlayer();
            file.readFileSK();
            firstEquip();
            plyrStat.gold = 100;
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
                            Console.WriteLine($"You have equiped the {player[i].item}!");
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
                            Console.WriteLine($"You have equiped the {player[i].item}!");
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
                    done = true;
                }
                else if(tutorial)
                {
                    Console.WriteLine("You should probably visit the equipment shop first!");
                }
                Console.WriteLine("Where would you like to do?");
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
                        Console.WriteLine("Welcome to my shop! Here, you can buy and sell equipment.");
                        Console.WriteLine("Would you like a more in depth look at how you would do this?.");
                        input = Console.ReadLine().ToLower().Trim();
                        if (input == "yes")
                        {
                            Console.WriteLine("Alright! Like I said previously, you can buy and sell equipment here.\nAfter you\'ve specified what you want to do,");
                            shopHelp("You can type");
                        }
                        else
                        {
                            Console.WriteLine("Oh well, I guess you already know how to use shops.\nNo big deal I suppose.");
                        }
                        Console.WriteLine("So, can i do anything for ya?");
                        while (true)
                        {
                            input = Console.ReadLine();
                            if (input == "n"||input == "no")
                            {
                                Console.WriteLine("Oh well, come back next time!");
                                break;
                            }
                            else if (input == "sell")
                            {
                                Console.WriteLine("Alright, let\'s get down to buisness!");
                                sellShop();
                                break;
                            }
                            else if (input == "buy")
                            {
                                Console.WriteLine("Alright, let\'s see what I have for you today!");
                                buyShop();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("I didn\'t quite get that.\nCould you say that again?");
                            }
                        }
                        tutorial = false;
                    }
                    else
                    {
                        Console.WriteLine("Ah, you\'re back! What can I do for ya?");
                        while (true) {
                            input = Console.ReadLine().ToLower().Trim();
                            if (input == "sell")
                            {
                                Console.WriteLine("Alright, let\'s get down to buisness!");
                                sellShop();
                                break;
                            }
                            else if (input == "buy")
                            {
                                Console.WriteLine("Alright, let\'s see what I have for you today!");
                                buyShop();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("I didn\'t quite get that.\nCould you say that again?");
                            }
                        }
                    }
                }
                else if (input == "hut" || input == "witch")
                {
                    Console.WriteLine("Um, spells?(WIP)");
                }
                else if (input == "forest")
                {
                    forestTrial();
                    checkPrice();
                    shopReset();
                }
                else if(input == "inventory" || input == "equipment")
                {
                    checkInventory();
                    Console.WriteLine("Still more things to do!");

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
                }
                else if (input == "kill")
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
        /// <summary>
        /// Resets the shop after you 
        /// </summary>
        private static void shopReset()
        {
            shopKeep[0].item = Armor.randHelm(5,4);
            shopKeep[0].value = (Armor.checkValue(shopKeep[0].item)+25);
            shopKeep[1].item = Armor.randChest(5,4);
            shopKeep[1].value = (Armor.checkValue(shopKeep[1].item) + 25);
            shopKeep[2].item = Armor.randGaunt(5,4);
            shopKeep[2].value = (Armor.checkValue(shopKeep[2].item) + 25);
            shopKeep[3].item = Armor.randLeg(5,4);
            shopKeep[3].value = (Armor.checkValue(shopKeep[3].item) + 25);
            shopKeep[4].item = Weapons.randCreation(8,7,4);
            shopKeep[4].value = (Weapons.checkValue(shopKeep[4].item)+25);

        }
        /// <summary>
        /// Prints the inventory of the player
        /// </summary>
        private static void checkInventory()
        {
            Console.WriteLine("You have:");
            foreach (playerItem i in player)
            {
                if (i.item != null)
                {
                    Console.WriteLine(i.item);
                }
            }
        }
        /// <summary>
        /// WIP Adventure
        /// </summary>
        private static void forestTrial()
        {
            int _rand = rand.Next(0,2);
            string item_ = "";
            if (_rand == 0)
            {
                int newRand = rand.Next(0,4);
                if (newRand == 0)
                {
                    item_ = Armor.randChest(5,4);
                }
                else if (newRand == 1)
                {
                    item_ = Armor.randGaunt(5,4);
                }
                else if (newRand == 2)
                {
                    item_ = Armor.randHelm(5,4);
                }
                else if (newRand == 3)
                {
                    item_ = Armor.randLeg(5,4);
                }
            }
            else if (_rand == 1)
            {
                item_ = Weapons.randCreation(8,7,4);
            }
            for (int i = 0; i <50; i ++)
            {
                if (player[i].item == null)
                {
                    Console.WriteLine($"You picked up a {item_}");
                    player[i].item = item_;
                    break;
                }
            }
        }
        /// <summary>
        /// Allows the player to sell items
        /// </summary>
        private static void sellShop()
        {
            string input;
            string thisName;
            bool finish = false;
            Console.WriteLine("So, what would ya like to sell?");
            string[] items = new string[50];
            int[] val = new int[50];
            int tries = 0;
            int x = 0;
            while (true) {
                input = Console.ReadLine().ToLower().Trim();
                thisName = input;
                if (input == "helmet" || input == "helm")
                {
                    foreach (playerItem i in player)
                    {
                        if (i.item != null)
                        {
                            string[] _item = i.item.Split(' ');
                            if (_item[2] == "Helmet")
                            {
                                items[x] = i.item;
                                if (i.value == 0)
                                {
                                    val[x] = Weapons.checkValue(i.item);
                                }
                                else
                                {
                                    val[x] = i.value;
                                }
                                x++;
                            }
                        }
                    }
                    break;
                }
                else if (input == "chestpiece" || input == "chest")
                {
                    foreach (playerItem i in player)
                    {
                        if (i.item != null)
                        {
                            string[] _item = i.item.Split(' ');
                            if (_item[2] == "Chestpiece")
                            {
                                items[x] = i.item;
                                if (i.value == 0)
                                {
                                    val[x] = Weapons.checkValue(i.item);
                                }
                                else
                                {
                                    val[x] = i.value;
                                }
                                x++;
                            }
                        }
                    }
                    break;
                }
                else if (input == "gauntlet" || input == "gaunt")
                {
                    foreach (playerItem i in player)
                    {
                        if (i.item != null)
                        {
                            string[] _item = i.item.Split(' ');
                            if (_item[2] == "Gauntlet")
                            {
                                items[x] = i.item;
                                if (i.value == 0)
                                {
                                    val[x] = Weapons.checkValue(i.item);
                                }
                                else
                                {
                                    val[x] = i.value;
                                }
                                x++;
                            }
                        }
                    }
                        break;
                }
                else if (input == "leggings" || input == "leg")
                {
                    foreach (playerItem i in player)
                    {
                        string[] _item = i.item.Split(' ');
                        if (_item[2] == "Leggings")
                        {
                            items[x] = i.item;
                            if (i.value == 0)
                            {
                                val[x] = Weapons.checkValue(i.item);
                            }
                            else
                            {
                                val[x] = i.value;
                            }
                            x++;
                        }
                    }
                    break;
                }
                else if (input == "weapons" || input == "weapon")
                {
                    Console.WriteLine("Is there a certian weapon that you would like to sell?(Y/N)");
                    input = Console.ReadLine().ToString().Trim();
                    thisName = input;
                    if (input == "y" || input == "yes")
                    {
                        Console.WriteLine("Which weapon would you like to sell?");
                        while(true){
                            input = Console.ReadLine();
                            thisName = input;
                            if (input == "axe")
                            {
                                foreach (playerItem i in player)
                                {
                                    if (i.item != null)
                                    {
                                        string[] _item = i.item.Split(' ');
                                        if (_item[2] == "Axe")
                                        {
                                            items[x] = i.item;
                                            if (i.value == 0)
                                            {
                                                val[x] = Weapons.checkValue(i.item);
                                            }
                                            else
                                            {
                                                val[x] = i.value;
                                            }
                                            x++;
                                        }
                                    }
                                }
                                break;
                            }
                            else if(input == "sword")
                            {
                                foreach (playerItem i in player)
                                {
                                    if (i.item != null) {
                                        string[] _item = i.item.Split(' ');
                                        if (_item[2] == "Sword")
                                        {
                                            items[x] = i.item;
                                            if (i.value == 0)
                                            {
                                                val[x] = Weapons.checkValue(i.item);
                                            }
                                            else
                                            {
                                                val[x] = i.value;
                                            }
                                            x++;
                                        }
                                    }
                                }
                                break;
                            }
                            else if (input == "mace")
                            {
                                foreach (playerItem i in player)
                                {
                                    if (i.item != null)
                                    {
                                        string[] _item = i.item.Split(' ');
                                        if (_item[2] == "Mace")
                                        {
                                            items[x] = i.item;
                                            if (i.value == 0)
                                            {
                                                val[x] = Weapons.checkValue(i.item);
                                            }
                                            else
                                            {
                                                val[x] = i.value;
                                            }
                                            x++;
                                        }
                                    }
                                }
                                break;
                            }
                            else if (input == "pike")
                            {
                                foreach (playerItem i in player)
                                {
                                    if (i.item != null)
                                    {
                                        string[] _item = i.item.Split(' ');
                                        if (_item[2] == "Pike")
                                        {
                                            items[x] = i.item;
                                            if (i.value == 0)
                                            {
                                                val[x] = Weapons.checkValue(i.item);
                                            }
                                            else
                                            {
                                                val[x] = i.value;
                                            }
                                            x++;
                                        }
                                    }
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please type an actual weapon type:");
                            }
                        }
                    }
                    else
                    {
                        foreach (playerItem i in player)
                        {
                            if (i.item != null)
                            {
                                string[] _item = i.item.Split(' ');
                                if (_item[2] == "Axe" || _item[2] == "Sword" || _item[2] == "Mace" || _item[2] == "Pike")
                                {

                                    items[x] = i.item;
                                    if (i.value == 0)
                                    {
                                        val[x] = Weapons.checkValue(i.item);
                                    }
                                    else
                                    {
                                        val[x] = i.value;
                                    }
                                    x++;
                                }
                            }
                        }
                        break;
                    }
                }
                else if (input == "help")
                {
                    shopHelp("Type");
                }
                else if (input == "n"||input =="no"||input == "stop")
                {
                    finish = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter what you would like to sell:");
                    if (tries>=5)
                    {
                        Console.WriteLine("If you are having trouble, please type \'help\'.");
                    }
                    tries++;
                }
            }
            if (!finish) {
                Console.WriteLine($"These are the {thisName} you can sell:\n");
                for (int i = 0; i < 50; i++)
                {
                    if (items[i] != null)
                    {
                        Console.WriteLine(items[i]);
                    }
                }
                Console.WriteLine($"Which {thisName} would you like to sell:");
                int setItem = 0;
                bool sellDone = false;
                while (true)
                {
                    input = Console.ReadLine();
                    for (int i = 0; i < 50; i++)
                    {
                        if (input == items[i])
                        {
                            bool far = true;
                            Console.WriteLine($"So you want to sell the {input}, do ya?\nI can give you {val[i]} for it.\nWould you like to do this?");
                            while (far)
                            {
                                input = Console.ReadLine();
                                if (input == "n" || input == "no")
                                {
                                    Console.WriteLine("Oh well. That\'ll probably be the best deal you\'ll get.");
                                    break;
                                } else if (input == "y" || input == "yes")
                                {
                                    if (items[i] == plyrStat.equipeChest || items[i] == plyrStat.equipeGaunt || items[i] == plyrStat.equipedWeapon || items[i] == plyrStat.equipeChest || items[i] == plyrStat.equipeLeg)
                                    {
                                        Console.WriteLine("This item is currently equiped. Would you still like to sell it?");
                                        while (true)
                                        {
                                            input = Console.ReadLine();
                                            if (input == "n" || input == "no")
                                            {
                                                Console.WriteLine("Oh well. That\'ll probably be the best deal you\'ll get.");
                                                break;
                                            } else if (input == "y" || input == "yes")
                                            {
                                                Console.WriteLine("Good deal!");
                                                if (items[i] == plyrStat.equipeChest) { plyrStat.equipeChest = null; }
                                                if (items[i] == plyrStat.equipeLeg) { plyrStat.equipeLeg = null; }
                                                if (items[i] == plyrStat.equipeGaunt) { plyrStat.equipeGaunt = null; }
                                                if (items[i] == plyrStat.equipedWeapon) { plyrStat.equipedWeapon = null; }
                                                if (items[i] == plyrStat.equipedHelm) { plyrStat.equipedHelm = null; }
                                                for (int k = 0; k < 50; k++)
                                                {
                                                    if (items[i] == player[k].item)
                                                    {
                                                        setItem = k;
                                                        break;
                                                    }
                                                }
                                                items[i] = null;
                                                player[setItem].item = null;
                                                plyrStat.gold += player[setItem].value;
                                                player[setItem].value = 0;
                                                Console.WriteLine("Is this all you want to sell?");
                                                input = Console.ReadLine();
                                                if (input == "n" || input == "no")
                                                {
                                                    Console.WriteLine($"Alright, come and pick another {thisName}.");
                                                    break;
                                                }
                                                else if (input == "y" || input == "yes")
                                                {
                                                    Console.WriteLine("Alright, I\'ll see you later than.");
                                                    sellDone = true;
                                                    far = false;
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("I\'ll just take tht as a yes...");
                                                    sellDone = true;
                                                    far = false;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Yes or No?");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Good deal!");
                                        for (int k = 0; k < 50; k++)
                                        {
                                            if (items[i] == player[k].item)
                                            {
                                                setItem = k;
                                                break;
                                            }
                                        }
                                        items[i] = null;
                                        player[setItem].item = null;
                                        plyrStat.gold += player[setItem].value;
                                        player[setItem].value = 0;
                                        Console.WriteLine("Is this all you want to sell?");
                                        input = Console.ReadLine();
                                        if (input == "n" || input == "no")
                                        {
                                            Console.WriteLine($"Alright, come and pick another {thisName}.");
                                            break;
                                        }
                                        else if (input == "y" || input == "yes")
                                        {
                                            Console.WriteLine("Alright, I\'ll see you later than.");
                                            sellDone = true;
                                            far = false;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("I\'ll just take tht as a yes...");
                                            sellDone = true;
                                            far = false;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Yes or No?");
                                }
                            }
                        } else if (i == 49)
                        {
                            Console.WriteLine("\nPlease enter the name again:");
                        }
                    }
                    if (sellDone)
                    {
                        break;
                    }
                }
                sortItems();
            }
            Console.WriteLine("I hope that I could be of assistance!");
        }
        /// <summary>
        /// An easy way to provaide assistace with the shop
        /// </summary>
        /// <param name="words">The first thing that is said</param>
        private static void shopHelp(string words)
        {
            Console.WriteLine($"{words} \'helmet\' or\'helm\' to sell helmets.\n{words} \'chestpiece\' or\'chest\' to sell chestpieces.\n{words} \'gauntlet\' or\'gaunt\' to sell gauntlets.\n{words} \'leggings\' or\'leg\' to sell gauntlets.\n{words} \'weapon\' or\'weapons\' to sell weapons.");
        }
        /// <summary>
        /// Allows the player to buy items for the shopkeep
        /// </summary>
        private static void buyShop()
        {
            string input;
            Console.WriteLine($"You have {plyrStat.gold} gold!");
            Console.WriteLine("Here's my daily stock!");
            string[] items = new string[shopKeep.Length];
            int[] val = new int[shopKeep.Length];
            int x = 0;
            foreach (shopItem i in shopKeep)
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
                if (input == "stop") { break; }
                if (input == "helmet" && items[0] != null && plyrStat.gold >= val[0])
                {
                    Console.WriteLine($"So, the {items[0]} strikes you're fancy, eh? So be it!");
                    for (int i = 0; i < 50; i++)
                    {
                        if (player[i].item == null)
                        {
                            player[i].item = items[0];
                            plyrStat.gold -= player[i].value;
                            player[i].value = (val[0]-25) <= 0? 0:val[0]-25;
                            break;
                        }
                        else
                        {
                            if (i == 49)
                            {
                                Console.WriteLine("It looks like you are full on inventory space, you should probably sell some items.");
                            }
                        }
                    }
                    break;
                }
                else if (input == "chestpiece" && items[1] != null && plyrStat.gold >= val[1])
                {
                    Console.WriteLine($"So, the {items[1]} strikes you're fancy, eh? So be it!");
                    for (int i = 0; i < 50; i++)
                    {
                        if (player[i].item == null)
                        {
                            player[i].item = items[1];
                            plyrStat.gold -= player[i].value;
                            player[i].value = (val[1] - 25) <= 0 ? 0 : val[1] - 25;
                            break;
                        }
                        else
                        {
                            if (i == 49)
                            {
                                Console.WriteLine("It looks like you are full on inventory space, you should probably sell some items.");
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
                            plyrStat.gold -= player[i].value;
                            player[i].value = (val[2] - 25) <= 0 ? 0 : val[2] - 25;
                            break;
                        }
                        else
                        {
                            if (i == 49)
                            {
                                Console.WriteLine("It looks like you are full on inventory space, you should probably sell some items.");
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
                            plyrStat.gold -= player[i].value;
                            player[i].value = (val[3] - 25) <= 0 ? 0 : val[3] - 25;
                            break;
                        }
                        else
                        {
                            if (i == 49)
                            {
                                Console.WriteLine("It looks like you are full on inventory space, you should probably sell some items.");
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
                            plyrStat.gold -= player[i].value;
                            player[i].value = (val[4] - 25) <= 0 ? 0 : val[4] - 25;
                            break;
                        }
                        else
                        {
                            if (i == 49)
                            {
                                Console.WriteLine("It looks like you are full on inventory space, you should probably sell some items.");
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
        /// <summary>
        /// Sorts your items if there is a gap between them in the array
        /// </summary>
        private static void sortItems()
        {
            for (int i = 0; i < 50; i++)
            {
                if (player[i].item == null && (player[i+1].item != null && i <49))
                {
                    player[i].item = player[i + 1].item;
                    player[i].value = player[i + 1].value;
                }
            }
        }
        /// <summary>
        /// Checks the value of all of your weapons and armor if it doesn't have a price
        /// </summary>
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
        /// <summary>
        /// Checks the armor and attack value of your equiped items
        /// </summary>
        private static void checkEquip()
        {
            float defense = 0, attack = 0;
            defense += Armor.checkDefense(plyrStat.equipedHelm);
            defense += Armor.checkDefense(plyrStat.equipeLeg);
            defense += Armor.checkDefense(plyrStat.equipeGaunt);
            defense += Armor.checkDefense(plyrStat.equipeChest);
            attack += Weapons.checkAttack(plyrStat.equipedWeapon);
            Console.WriteLine($"You\'re total defense is {defense}\nYou\'re Attack is {attack}");
        }
        /// <summary>
        /// Kills the player and sets them back up with the begining armor.
        /// </summary>
        private static void death()
        {
            Console.WriteLine("It looks like you have died, better luck next time!");
            file.reset();
            Console.ReadLine();
        }
        /// <summary>
        /// Equips the first set of armor that you have based of what was in the text file.
        /// </summary>
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
                    if (plyrStat.equipedWeapon == null && (_item[2] == "Axe"|| _item[2] == "Sword"|| _item[2] == "Mace"|| _item[2] == "Pike"))
                    {
                        plyrStat.equipedWeapon = i.item;
                    }
                }
            }
        }
    }
}
