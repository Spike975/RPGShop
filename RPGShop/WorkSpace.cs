using System;

namespace RPGShop
{
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
        public int gold;
        public int potionS;
        public int potionM;
        public int potionL;
        public float health;
        public float speed;
        public float defence;
        public float attack;
        public string name;
        public string equipedHelm;
        public string equipeChest;
        public string equipeLeg;
        public string equipeGaunt;
        public string equipedWeapon;
    }
    //If time, add random percentages for armor and weapons
    class WorkSpace
    {
        /// <summary>
        /// Holds all of the item data and the items value for the Shop Keep
        /// </summary>
        public static shopItem[] shopKeep = new shopItem[5];
        /// <summary>
        /// Holds all of the item data and the items value for the Player
        /// </summary>
        public static playerItem[] player = new playerItem[50];
        public static Random rand = new Random();//for random numbers
        public static TextFile file = new TextFile();//for using the text file class
        public static playerStats plyrStat = new playerStats();// PLAYER STATS!
        public static bool run = true;//For the main code
        public static int baseAttack = 10;
        static void Main()
        { 
            bool tutorial = true;//for the tutorial
            bool witch = true;
            bool day = false;
            bool done = false;//kinda not needed, but only used once
            string input;//player input string
            file.readFilePlayer();
            file.readFileSK();
            file.readPlayerStats();
            firstEquip();
            int items = 0;
            //checks items
            while (true) {
                foreach (playerItem i in player)
                {
                    if (i.item != null)
                    {
                        items++;
                    }
                }
                break;
            }
            if (items < 5)
            {
                Console.WriteLine("Welcome to a short RPG adventure game.\n\nPlease enter you name adventurer:");
                plyrStat.name = Console.ReadLine();
                Console.WriteLine($"Welcome {plyrStat.name}! Today, your adventure begins!\n");
                Console.WriteLine("Would you like to start off with a sword or an axe?");
                //Does what it says up above, based off the anwser  ^
                while (true)
                {
                    input = Console.ReadLine().ToLower();
                    if (input == "axe")
                    {
                        plyrStat.equipedWeapon = "Chipped Wooden Axe";
                        for (int i = 0; i < player.Length; i++)
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
                    }
                    else if (input == "sword")
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
                Console.WriteLine("\nYou arrive in town. You notice an inn, an equipment shop, what appears to be a witches hut,\n    or you can travel into the forest beyond.");
            }
            else
            {
                Console.WriteLine($"Welcome back {plyrStat.name}.");
                tutorial = false;
                done = true;
            }
            
            //main piece of code:
            while (run)
            {
                if (!tutorial && !done)
                {
                    Console.WriteLine("\nYou arrive back in town.\nYou can now check your \'inventory\' and your \'gold\'!");
                    done = true;
                }
                else if(tutorial)
                {
                    Console.WriteLine("You should probably visit the equipment shop first!\n");
                }
                else if (day)
                {
                    Console.WriteLine("\nYou\'ve sucessfuly made it back to town.!\nIt\'s getting pretty late, maybe you should call it a night.");
                }
                else
                {
                    Console.WriteLine("\nYou arive back in town.");
                }
                Console.WriteLine("\nWhere would you like to go?");
                input = Console.ReadLine().ToLower().Trim();
                //idk what to do with this
                if (input == "inn")
                {
                    Console.WriteLine("You slept the night peacefully");
                    plyrStat.health = 100;
                    Console.WriteLine("Saving game...... Done.");
                    file.writeFilePlayer();
                    file.writeFileSK();
                    file.writePlayerStats();
                    day = false;
                }
                //hopefully done. to much stuff here
                else if (input == "shop")
                {
                    Console.WriteLine("You enter the shop.\n");
                    if (tutorial)
                    {
                        Console.WriteLine("Welcome to my shop! Here, you can buy and sell equipment.");
                        Console.WriteLine("Would you like a more in depth look at how you would do this?.");
                        input = Console.ReadLine().ToLower().Trim();
                        if (input == "yes")
                        {
                            Console.WriteLine("Alright! Like I said previously, you can buy and sell equipment here.\n  You can type \'buy\' or \'sell\' to accomplish this.\n");
                            shopHelp("sell");
                            Console.WriteLine();
                            shopHelp("buy");
                            Console.WriteLine("\nThe same works for equiping items as well.");
                        }
                        else
                        {
                            Console.WriteLine("Oh well, I guess you already know how to use shops.\nNo big deal I suppose.");
                        }
                        Console.WriteLine("\nSo, can I do anything for ya?");
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
                            else if (input == "cheat")
                            {
                                Console.WriteLine("\nHow much gold would you like to add?");
                                int add = 0;
                                while (true)
                                {
                                    input = Console.ReadLine();
                                    int.TryParse(input, out add);
                                    if (add != 0&& add > 0)
                                    {
                                        plyrStat.gold += add;
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
                //POTIONS! For Boss Fights!... i think... EDIT: yes
                else if (input == "hut" || input == "witch")
                {
                    Console.WriteLine("\nWelcome to my shop.");
                    if (witch)
                    {
                        Console.WriteLine("\nI see that this is your first time here.\nI am a potion vendor, and sell all sorts of potions.\nWell, let me give you an introduction to how this works.");
                        Console.WriteLine("\nMy main stock is health potions. I sell small, normal, and large versions.\n   The small is 50 gold, and gives 10 health back.\n   The normal is 100 gold, and gives 25 health back.\n   The large is 200 gold, and restores 50 health.");
                        Console.WriteLine("\nNow that you know all this, would you like anything?");
                        witch = false;
                        while (true)
                        {
                            input = Console.ReadLine().Trim().ToLower();
                            if (input == "small")
                            {
                                if (plyrStat.gold < 50)
                                {
                                    Console.WriteLine("\nI\'m afraid that you don\'t have enough to purchase this.\nCome back later!");
                                }
                                else
                                {
                                    Console.WriteLine("\nSounds like a deal!");
                                    plyrStat.gold -= 50;
                                    plyrStat.potionS++;
                                }
                                break;
                            }
                            else if (input == "normal")
                            {
                                if (plyrStat.gold < 100)
                                {
                                    Console.WriteLine("\nI\'m afraid that you don\'t have enough to purchase this.\nCome back later!");
                                }
                                else
                                {
                                    Console.WriteLine("\nSounds like a deal!");
                                    plyrStat.gold -= 100;
                                    plyrStat.potionM++;
                                }
                                break;
                            }
                            else if (input == "large")
                            {
                                if (plyrStat.gold < 200)
                                {
                                    Console.WriteLine("\nI\'m afraid that you don\'t have enough to purchase this.\nCome back later!");
                                }
                                else
                                {
                                    Console.WriteLine("\nSounds like a deal!");
                                    plyrStat.gold -= 500;
                                    plyrStat.potionL++;
                                }
                                break;
                            }
                            else if (input == "other")
                            {
                                Console.WriteLine("\nIt doesn\'t seem like I have anything else in stock.");
                                Console.WriteLine("\nPlease enter again:");
                            }
                            else if (input == "no" || input == "n")
                            {
                                Console.WriteLine("\nOkay, have a good day!\nHope to see you again soon!");
                                break;
                            }
                            else if (input == "cheat")
                            {
                                Console.WriteLine("\nOkay, what would you like?");
                                while (true)
                                {
                                    int i = 0;
                                    input = Console.ReadLine().Trim().ToLower();
                                    if (input == "small")
                                    {
                                        Console.WriteLine("\nHow many do you want?");
                                        int.TryParse(Console.ReadLine(), out i);
                                        plyrStat.potionS += i;
                                        break;
                                    }
                                    else if (input == "normal")
                                    {
                                        Console.WriteLine("\nHow many do you want?");
                                        int.TryParse(Console.ReadLine(), out i);
                                        plyrStat.potionM += i;
                                        break;
                                    }
                                    else if(input == "large")
                                    {
                                        Console.WriteLine("\nHow many do you want?");
                                        int.TryParse(Console.ReadLine(), out i);
                                        plyrStat.potionL += i;
                                        break;
                                    }
                                    else if(input == "all")
                                    {
                                        Console.WriteLine("\nHow many do you want?");
                                        int.TryParse(Console.ReadLine(), out i);
                                        plyrStat.potionS += i;
                                        plyrStat.potionM += i;
                                        plyrStat.potionL += i;
                                        break;
                                    }
                                    else if (i == 0)
                                    {
                                        Console.WriteLine("\nPotion amount not entered correctly.\nEnter again.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nDude, you wrote this, how can you forget this?\nEnter again:");
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
                        Console.WriteLine("\nWhat would you like?");
                        while (true)
                        {
                            input = Console.ReadLine().Trim().ToLower();
                            if (input == "small")
                            {
                                if (plyrStat.gold<50)
                                {
                                    Console.WriteLine("\nI\'m afraid that you don\'t have enough to purchase this.\nCome back later!");
                                }
                                else
                                {
                                    Console.WriteLine("\nSounds like a deal!");
                                    plyrStat.gold -= 50;
                                    plyrStat.potionS++;
                                }
                                break;
                            }
                            else if (input == "normal")
                            {
                                if (plyrStat.gold < 100)
                                {
                                    Console.WriteLine("\nI\'m afraid that you don\'t have enough to purchase this.\nCome back later!");
                                }
                                else
                                {
                                    Console.WriteLine("\nSounds like a deal!");
                                    plyrStat.gold -= 100;
                                    plyrStat.potionM++;
                                }
                                break;
                            }
                            else if (input == "large")
                            {
                                if (plyrStat.gold < 200)
                                {
                                    Console.WriteLine("\nI\'m afraid that you don\'t have enough to purchase this.\nCome back later!");
                                }
                                else
                                {
                                    Console.WriteLine("\nSounds like a deal!");
                                    plyrStat.gold -= 500;
                                    plyrStat.potionL++;
                                }
                                break;
                            }else if (input =="other")
                            {
                                Console.WriteLine("\nIt doesn\'t seem like I have anything else in stock.");
                                Console.WriteLine("\nPlease enter again:");
                            }
                            else
                            {
                                Console.WriteLine("\nPlease enter again:");
                            }
                        }
                    }
                }
                //big boss fights/avdentures to get items/gold!(need to finish) :) EDIT: Giant almost done
                else if (input == "forest"&& !day)
                {
                    checkEquip(false);
                    Console.WriteLine("\nWould you like to explore, or go fight?");
                    while (true) {
                        input = Console.ReadLine();
                        if (input == "fight") {
                            Console.WriteLine("Where would you like to travel too?\n   Cave\n   Maze");
                            while (true)
                            {
                                input = Console.ReadLine().Trim().ToLower();
                                if (input == "cave")
                                {
                                    Giant g = new Giant();
                                    break;
                                }
                                else if (input == "maze")
                                {
                                    Minotaur m = new Minotaur();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nPlease enter again:");
                                }
                            }
                            break;
                        }
                        else if (input == "explore")
                        {
                            Console.WriteLine("\nWhere would you like to go:\n   Woods");
                            while (true)
                            {
                                input = Console.ReadLine();
                                if (input == "woods"||input == "wood")
                                {
                                    Woods wood = new Woods();
                                }
                                break;
                            }
                            break;
                        }
                        else{
                            Console.WriteLine("\nPlease enter again:");
                        }
                    }
                    if (plyrStat.health>=0)
                    {
                        checkPrice();
                        shopReset();
                        Console.WriteLine("\nYou return triumphant from the forest!... but you\'re exaushted");
                    }
                    else
                    {
                        death();
                        break;
                    }

                }
                //if you've already adventured today
                else if (input == "forest" && day)
                {
                    Console.WriteLine("\nYou\'re too exausted to go back out.\nTry going to the inn for some rest.");
                }
                //i think i'm done
                else if(input == "inventory" || input == "inv")
                {
                    Console.WriteLine("You can check your items, check stats, check potions, or equip items.\n\nWhat would you like to do?");
                    while (true)
                    {
                        input = Console.ReadLine().ToLower().Trim();
                        if (input == "items")
                        {
                            sortItems();
                            checkInventory();
                            checkPrice();
                            break;
                        }
                        else if (input == "stats")
                        {
                            checkEquip(true);
                            break;
                        }
                        else if (input == "equip")
                        {
                            equipItems();
                            break;
                        }
                        else if (input == "potions"|| input == "potion")
                        {
                            Console.WriteLine($"\nYou have:\n   Small: {plyrStat.potionS}\n  Normal: {plyrStat.potionM}\n   Large: {plyrStat.potionL}");
                            break;
                        }
                        else if (input == "help")
                        {
                            Console.WriteLine("\n   You can type \'items\' to view your items, \'stats\' to veiw stats,\n   \'potions\' to view potions and \'equip\' to equip items.");
                        }
                        else
                        {
                            Console.WriteLine("\nYou can type \'help\' for help.\n\nPlease enter again:");
                        }
                    }
                    Console.WriteLine("Still more things to do!");

                }
                //done. pretty easy
                else if(input == "gold"||input == "bal"||input == "balance")
                {
                    Console.WriteLine($"\nYou have {plyrStat.gold} gold!\nDon't go spend it all in one place.");
                }
                //done... unless i add more
                else if (input == "help")
                {
                    Console.WriteLine("You can type \'inn\' to go to the inn.\nYou can type \'shop\' to visit the equipment shop.");
                    Console.WriteLine("You can type \'witch\' or \'hut\' to go to the witches hut.\nYou can type \'forest\' to delve into the forest.");
                    if (!tutorial) Console.WriteLine("You can type \'inventory\' or \'inv\' to access your inventory.\nYou can type \'bal\',\'balance\', or \'gold\' to view you total gold!");
                }
                //it kills you, it's pretty simple....
                else if (input == "kill")
                {
                    death();
                    run = false;
                }
                //um... redo?
                else
                {
                    Console.WriteLine("I didn't quite understand that. Please recheck your spelling, or type an actual place.");
                    Console.WriteLine("You can also type \'help\' for assistance in where to go!");
                }
            }
            file.writeFilePlayer();

        }
        /// <summary>
        /// Resets the shop after you finish the forest 
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
            Console.WriteLine("\nYou have:");
            foreach (playerItem i in player)
            {
                if (i.item != null)
                {
                    Console.WriteLine("   "+i.item);
                }
            }
        }
        /// <summary>
        /// Allows the player to sell items
        /// </summary>
        private static void sellShop()
        {
            string input;
            string name = "";
            bool finish = false;
            Console.WriteLine("So, what would ya like to sell?\n[1]Helmets\n[2]Chestpieces\n[3]Gauntlets\n[4]Legging\n[5]Weapons");
            string[] items = new string[50];
            int[] val = new int[50];
            int tries = 0;
            int x = 0;
            while (true) {
                input = Console.ReadLine().ToLower().Trim();
                if (input == "1")
                {
                    name = "Helmet";
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
                else if (input == "2")
                {
                    name = "Chestpiece";
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
                else if (input == "3")
                {
                    name = "Gauntlets";
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
                else if (input == "4")
                {
                    name = "Leggings";
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
                else if (input == "5")
                {
                    name = "Weapon";

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
                else if (input == "help")
                {
                    shopHelp("sell");
                }
                else if (input == "n" || input == "no" || input == "stop")
                {
                    finish = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter what you would like to sell:");
                    if (tries >= 5)
                    {
                        Console.WriteLine("If you are having trouble, please type \'help\'.");
                    }
                    tries++;
                }
            }
            if (!finish) {
                Console.WriteLine($"These are the {name} you can sell:\n");
                for (int i = 0; i < 50; i++)
                {
                    if (items[i] != null)
                    {
                        Console.WriteLine($"[{i+1}]"+items[i]);
                    }
                }
                Console.WriteLine($"Which {name} would you like to sell:");
                int setItem = 0;
                int _item = 0;
                bool sellDone = false;
                while (true)
                {
                    input = Console.ReadLine();
                    int.TryParse(input, out _item);

                    if (items[_item - 1] != null)
                    {
                        bool far = true;
                        Console.WriteLine($"So you want to sell the {items[_item-1]}, do ya?\nI can give you {val[_item-1]} for it.\nWould you like to do this?");
                        while (far)
                        {
                            input = Console.ReadLine();
                            if (input == "n" || input == "no")
                            {
                                Console.WriteLine("Oh well. That\'ll probably be the best deal you\'ll get.");
                                break;
                            }
                            else if (input == "y" || input == "yes")
                            {
                                if (items[_item - 1] == plyrStat.equipeChest || items[_item - 1] == plyrStat.equipeGaunt || items[_item - 1] == plyrStat.equipedWeapon || items[_item - 1] == plyrStat.equipeChest || items[_item - 1] == plyrStat.equipeLeg)
                                {
                                    Console.WriteLine("This item is currently equiped. Would you still like to sell it?");
                                    while (true)
                                    {
                                        input = Console.ReadLine();
                                        if (input == "n" || input == "no")
                                        {
                                            Console.WriteLine("Oh well. That\'ll probably be the best deal you\'ll get.");
                                            break;
                                        }
                                        else if (input == "y" || input == "yes")
                                        {
                                            Console.WriteLine("Good deal!");
                                            if (items[_item - 1] == plyrStat.equipeChest) { plyrStat.equipeChest = null; }
                                            if (items[_item - 1] == plyrStat.equipeLeg) { plyrStat.equipeLeg = null; }
                                            if (items[_item - 1] == plyrStat.equipeGaunt) { plyrStat.equipeGaunt = null; }
                                            if (items[_item - 1] == plyrStat.equipedWeapon) { plyrStat.equipedWeapon = null; }
                                            if (items[_item - 1] == plyrStat.equipedHelm) { plyrStat.equipedHelm = null; }
                                            for (int k = 0; k < 50; k++)
                                            {
                                                if (items[_item - 1] == player[k].item)
                                                {
                                                    setItem = k;
                                                    break;
                                                }
                                            }
                                            items[_item - 1] = null;
                                            player[setItem].item = null;
                                            plyrStat.gold += player[setItem].value;
                                            player[setItem].value = 0;
                                            Console.WriteLine("Is this all you want to sell?");
                                            input = Console.ReadLine();
                                            if (input == "n" || input == "no")
                                            {
                                                Console.WriteLine($"Alright, come and pick another {name}.");
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
                                        if (items[_item - 1] == player[k].item)
                                        {
                                            setItem = k;
                                            break;
                                        }
                                    }
                                    items[_item - 1] = null;
                                    player[setItem].item = null;
                                    plyrStat.gold += player[setItem].value;
                                    player[setItem].value = 0;
                                    Console.WriteLine("Is this all you want to sell?");
                                    input = Console.ReadLine();
                                    if (input == "n" || input == "no")
                                    {
                                        Console.WriteLine($"Alright, come and pick another {name}.");
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
                    }
                    else
                    {
                        Console.WriteLine("\nPlease enter the number again:");
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
        /// <param name="words">"Buy" or "Sell"</param>
        private static void shopHelp(string words)
        {

            if (words == "sell")
            {
                Console.WriteLine("To sell, you go to the shop, then type in \'sell\'. Then you type the number of what you want to sell, then type the item number you want to sell.");
            }else if (words == "buy")
            {
                Console.WriteLine("To buy, you go to the shop, type \'buy\', then follow type the number of the item that you want to buy.");
            }
            else
            {
                Console.WriteLine("You messed up. FIX IT!!!!!!!!!!!!");
            }
        }
        /// <summary>
        /// Allows the player to buy items for the shopkeep
        /// </summary>
        private static void buyShop()
        {
            string input;
            Console.WriteLine($"\nYou have {plyrStat.gold} gold!");
            Console.WriteLine("\nHere's my daily stock:\n");
            string[] items = new string[shopKeep.Length];
            int[] val = new int[shopKeep.Length];
            int x = 0;
            foreach (shopItem i in shopKeep)
            {
                if (i.item != null) {
                    Console.WriteLine($"[{x+1}] {i.item} for {i.value} gold.");
                    items[x] = i.item;
                    val[x] = i.value;
                }
                x++;
            }
            Console.WriteLine("\nWhat would you like to buy?");
            while (true)
            {
                input = Console.ReadLine().ToLower().Trim();
                if (input == "stop") { break; }
                if (input == "1" && items[0] != null)
                {
                    if (plyrStat.gold <= val[0]) { Console.WriteLine("\nYou don't seem like you have enough money. Come back later and try again."); }
                    else if (shopKeep[0].item == null) { Console.WriteLine("That has already been sold."); }
                    else
                    {
                        Console.WriteLine($"So, the {items[0]} strikes you're fancy, eh? So be it!");
                        for (int i = 0; i < 50; i++)
                        {
                            if (player[i].item == null)
                            {
                                player[i].item = items[0];
                                plyrStat.gold -= shopKeep[0].value;
                                player[i].value = (val[0] - 25) <= 0 ? 0 : val[0] - 25;
                                shopKeep[0].item = null;
                                shopKeep[0].value = 0;
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
                    }
                    break;
                }
                else if (input == "2" && items[1] != null)
                {
                    if (plyrStat.gold <= val[1]) { Console.WriteLine("\nYou don't seem like you have enough money. Come back later and try again.");}
                    else if (shopKeep[1].item == null) { Console.WriteLine("That has already been sold."); }
                    else
                    {
                        Console.WriteLine($"So, the {items[1]} strikes you're fancy, eh? So be it!");
                        for (int i = 0; i < 50; i++)
                        {
                            if (player[i].item == null)
                            {
                                player[i].item = items[1];
                                plyrStat.gold -= shopKeep[1].value;
                                player[i].value = (val[1] - 25) <= 0 ? 0 : val[1] - 25;
                                shopKeep[1].item = null;
                                shopKeep[1].value = 0;
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
                    }
                        break;
                }
                else if (input == "3" && items[2] != null)
                {
                    if (plyrStat.gold <= val[2]) { Console.WriteLine("\nYou don't seem like you have enough money. Come back later and try again."); break; }
                    else if (shopKeep[2].item == null) { Console.WriteLine("That has already been sold."); }
                    else
                    {
                        Console.WriteLine($"So, the {items[2]} strikes you're fancy, eh? So be it!");
                        for (int i = 0; i < 50; i++)
                        {
                            if (player[i].item == null)
                            {
                                player[i].item = items[2];
                                plyrStat.gold -= shopKeep[2].value;
                                player[i].value = (val[2] - 25) <= 0 ? 0 : val[2] - 25;
                                shopKeep[2].item = null;
                                shopKeep[2].value = 0;
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
                }
                else if (input == "4" && items[3] != null)
                {
                    if (plyrStat.gold <= val[3]) { Console.WriteLine("\nYou don't seem like you have enough money. Come back later and try again."); }
                    else if (shopKeep[3].item == null) { Console.WriteLine("That has already been sold."); }
                    else
                    {
                        Console.WriteLine($"So, the {items[3]} strikes you're fancy, eh? So be it!");
                        for (int i = 0; i < 50; i++)
                        {
                            if (player[i].item == null)
                            {
                                player[i].item = items[3];
                                plyrStat.gold -= shopKeep[3].value;
                                player[i].value = (val[3] - 25) <= 0 ? 0 : val[3] - 25;
                                shopKeep[3].item = null;
                                shopKeep[3].value = 0;
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
                    }
                    break;
                }
                else if (input == "5" && items[4] != null)
                {
                    if (plyrStat.gold <= val[4]) { Console.WriteLine("\nYou don't seem like you have enough money. Come back later and try again."); }
                    else if (shopKeep[4].item == null) { Console.WriteLine("That has already been sold."); }
                    else
                    {
                        Console.WriteLine($"So, you enjoy the gleam of the {items[4]}, do ya? So be it!");
                        for (int i = 0; i < 50; i++)
                        {
                            if (player[i].item == null)
                            {
                                player[i].item = items[4];
                                plyrStat.gold -= shopKeep[4].value;
                                player[i].value = (val[4] - 25) <= 0 ? 0 : val[4] - 25;
                                shopKeep[4].item = null;
                                shopKeep[4].value = 0;
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
                    }
                    break;
                }
                else if (input == "help")
                {
                    shopHelp("buy");
                }
                else
                {
                    Console.WriteLine("I didn't quite get that, can you enter again?\nYou can type help if needed.");
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
                if (player[i].item == null && i < 49)
                {
                    player[i].item = player[i + 1].item;
                    player[i].value = player[i + 1].value;
                    player[i + 1].item = null;
                    player[i + 1].value = 0;
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
                }
            }
        }
        /// <summary>
        /// Checks the armor and attack value of your equiped items
        /// </summary>
        /// <param name="check">Print statement</param>
        private static void checkEquip(bool check)
        {
            float defense = 0, attack = 0;
            defense += Armor.checkDefense(plyrStat.equipedHelm);
            defense += Armor.checkDefense(plyrStat.equipeLeg);
            defense += Armor.checkDefense(plyrStat.equipeGaunt);
            defense += Armor.checkDefense(plyrStat.equipeChest);
            attack += Weapons.checkAttack(plyrStat.equipedWeapon);
            plyrStat.attack = attack;
            plyrStat.defence = defense;
            if (check) {
                Console.WriteLine($"You\'re total defense is {defense}\nYou\'re Attack is {attack}");
            }
        }
        /// <summary>
        /// Allows the player to equip items
        /// </summary>
        private static void equipItems()
        {
            string input = "";
            string ites = "";
            string[] _items = new string[50];
            int place = 0;
            Console.WriteLine($"You currently have equiped:");

            if (plyrStat.equipedHelm != null)
            {
                Console.WriteLine($"[1]{plyrStat.equipedHelm}");
            }
            else
            {
                Console.WriteLine("[1] Equip Helm");
            }

            if (plyrStat.equipeChest != null)
            {
                Console.WriteLine($"[2]{plyrStat.equipeChest}");
            }
            else
            {
                Console.WriteLine("[2] Equip Chestpeice");
            }

            if (plyrStat.equipeGaunt != null)
            {
                Console.WriteLine($"[3]{plyrStat.equipeGaunt}");
            }
            else
            {
                Console.WriteLine("[3] Equip Gauntlets");
            }

            if (plyrStat.equipeLeg != null)
            {
                Console.WriteLine($"[4]{plyrStat.equipeLeg}");
            }
            else
            {
                Console.WriteLine("[4] Equip Leggings");
            }

            if (plyrStat.equipedWeapon != null)
            {
                Console.WriteLine($"[5]{plyrStat.equipedWeapon}");
            }
            else
            {
                Console.WriteLine("[5] Equip Weapon");
            }

            Console.WriteLine("\nWhich would you like to change out?");
            while (true)
            {
                input = Console.ReadLine().Trim().ToLower();
                if (input == "1")
                {
                    ites = input;
                    for (int i = 0; i < player.Length; i++)
                    {
                        if (player[i].item != null)
                        {
                            string[] item = player[i].item.Split(' ');
                            if (item[2] == "Helmet")
                            {
                                _items[place] = player[i].item;
                                place++;
                            }
                        }
                    }
                    break;
                }
                else if (input == "2")
                {
                    ites = input;
                    for (int i = 0; i < player.Length; i++)
                    {
                        if (player[i].item != null)
                        {
                            string[] item = player[i].item.Split(' ');
                            if (item[2] == "Chestpiece")
                            {
                                _items[place] = player[i].item;
                                place++;
                            }
                        }
                    }
                    break;
                }
                else if (input == "3")
                {
                    ites = input;
                    for (int i = 0; i < player.Length; i++)
                    {
                        if (player[i].item != null)
                        {
                            string[] item = player[i].item.Split(' ');
                            if (item[2] == "Gauntlets")
                            {
                                _items[place] = player[i].item;
                                place++;
                            }
                        }
                    }
                    break;
                }
                else if (input == "4")
                {

                    ites = input;
                    for (int i = 0; i < player.Length; i++)
                    {
                        if (player[i].item != null)
                        {
                            string[] item = player[i].item.Split(' ');
                            if (item[2] == "Leggings")
                            {
                                _items[place] = player[i].item;
                                place++;
                            }
                        }
                    }
                    break;
                }
                else if (input == "5")
                {
                    ites = input;
                    for (int i = 0; i < player.Length; i++)
                    {
                        if (player[i].item != null)
                        {
                            string[] item = player[i].item.Split(' ');
                            if (item[2] == "Axe" || item[2] == "Sword" || item[2] == "Mace" || item[2] == "Pike")
                            {
                                _items[place] = player[i].item;
                                place++;
                            }
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Please number enter again:");
                }
            }
            Console.WriteLine("You can equip:\n");
            int x = 0;
            foreach (string i in _items)
            {
                if (i != null)
                {
                    Console.WriteLine($"[{x + 1}]" + i);
                    x++;
                }
            }
            bool done = false;
            Console.WriteLine($"\nWhich item would you like to equip?");
            while (true)
            {

                input = Console.ReadLine().Trim();
                int.TryParse(input, out place);
                for (int i = 0; i < _items.Length; i++)
                {
                    if (ites == "1") {
                        if (_items[place - 1] != null && place > 0)
                        {
                            plyrStat.equipedHelm = _items[place - 1];
                            Console.WriteLine($"\nYou have equiped {plyrStat.equipedHelm}!\n");
                            done = true;
                            break;
                        }
                        else if (i == 49)
                        {
                            Console.WriteLine("\nPlease enter an actual item number:");
                        }
                    }
                    if (ites == "2")
                    {
                        if (_items[place - 1] != null && place > 0)
                        {
                            plyrStat.equipeChest = _items[place - 1];
                            Console.WriteLine($"\nYou have equiped {plyrStat.equipeChest}!\n");
                            done = true;
                            break;
                        }
                        else if (i == 49)
                        {
                            Console.WriteLine("\nPlease enter an actual item number:");
                        }
                    }
                    if (ites == "3")
                    {
                        if (_items[place - 1] != null && place > 0)
                        {
                            plyrStat.equipeGaunt = _items[place - 1];
                            Console.WriteLine($"\nYou have equiped {plyrStat.equipeGaunt}!\n");
                            done = true;
                            break;
                        }
                        else if (i == 49)
                        {
                            Console.WriteLine("\nPlease enter an actual item number:");
                        }
                    }
                    if (ites == "4")
                    {
                        if (_items[place - 1] != null && place > 0)
                        {
                            plyrStat.equipeLeg = _items[place - 1];
                            Console.WriteLine($"\nYou have equiped {plyrStat.equipeLeg}!\n");
                            done = true;
                            break;
                        }
                        else if (i == 49)
                        {
                            Console.WriteLine("\nPlease enter an actual item number:");
                        }
                    }
                    if (ites == "5")
                    {
                        if (_items[place - 1] != null && place > 0)
                        {
                            plyrStat.equipedWeapon = _items[place - 1];
                            Console.WriteLine($"\nYou have equiped {plyrStat.equipedWeapon}!\n");
                            done = true;
                            break;
                        }
                        else if (i == 49)
                        {
                            Console.WriteLine("\nPlease enter an actual item number:");
                        }
                    }
                }
                if (done)
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Kills the player and sets them back up with the begining armor.
        /// </summary>
        private static void death()
        {
            Console.WriteLine("It looks like you have died, better luck next time!");
            file.reset();
            file.readFilePlayer();
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
                    if ((plyrStat.equipeChest == null || plyrStat.equipeChest  == "") && _item[2] == "Chestpiece")
                    {
                        plyrStat.equipeChest = i.item;
                    }
                    if ((plyrStat.equipeGaunt  == null || plyrStat.equipeGaunt == "") && _item[2] == "Gauntlets")
                    {
                        plyrStat.equipeGaunt = i.item;
                    }
                    if ((plyrStat.equipeLeg == null || plyrStat.equipeLeg == "") && _item[2] == "Leggings")
                    {
                        plyrStat.equipeLeg= i.item;
                    }
                    if ((plyrStat.equipedHelm == null || plyrStat.equipedHelm== "") && _item[2] == "Helmet")
                    {
                        plyrStat.equipedHelm = i.item;
                    }
                    if ((plyrStat.equipedWeapon == null || plyrStat.equipedWeapon == "") && (_item[2] == "Axe"|| _item[2] == "Sword"|| _item[2] == "Mace"|| _item[2] == "Pike"))
                    {
                        plyrStat.equipedWeapon = i.item;
                    }
                }
            }
        }
    }
}