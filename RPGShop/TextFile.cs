using System.IO;

namespace RPGShop
{
    
    class TextFile
    {
        private string resetPlayer = "Crude Leather Helmet,50,Crude Leather Chestpiece,80,Crude Leather Gauntlets,60,Crude Leather Leggings,70";
        private string resetShop = "Crude Leather Helmet,75,Crude Leather Chestpeice,105,Crude Leather Gauntlets,85,Crude Leather Leggings,95,Chipped Wooden Sword,45";
        private string resetStats = "100,0,0,1,100,0,0,0,,,,,,";

        /// <summary>
        /// Reads the file to find what the player owns and puts them in the player file
        /// </summary>
        public void readFilePlayer()
        {
            StreamReader reader = new StreamReader("player.txt");
            string[] items = reader.ReadLine().Split(',');
            int x = 0;
            for (int i = 0; i < items.Length / 2; i++)
            {
                WorkSpace.player[i].item = items[x];
                int.TryParse(items[x + 1], out WorkSpace.player[i].value);
                x += 2;
            }
            reader.Close();
        }
        /// <summary>
        /// Writes the items that the player has in his inventory
        /// </summary>
        public void writeFilePlayer()
        {
            StreamWriter writer = new StreamWriter("player.txt");
            int calc = 0;
            int maxItem = 0;
            foreach (playerItem i in WorkSpace.player)
            {
                if (i.item != null)
                {
                    maxItem++;
                }
            }
            foreach(playerItem i in WorkSpace.player){
                if (i.item != null)
                {
                    writer.Write(i.item + ","+i.value);
                    calc++;
                    if (calc != maxItem)
                    {
                        writer.Write(",");
                    }
                }

            }
            writer.Close();
        }
        /// <summary>
        /// Reads the stats of the player and puts them on the player
        /// </summary>
        public void readPlayerStats()
        {
            StreamReader reader = new StreamReader("playerStats.txt");
            string[] stats = reader.ReadLine().Split(',');
            float.TryParse(stats[0], out WorkSpace.plyrStat.health);
            float.TryParse(stats[1], out WorkSpace.plyrStat.defence);
            float.TryParse(stats[2], out WorkSpace.plyrStat.attack);
            float.TryParse(stats[3], out WorkSpace.plyrStat.speed);
            int.TryParse(stats[4],out WorkSpace.plyrStat.gold);
            int.TryParse(stats[5],out WorkSpace.plyrStat.potionS);
            int.TryParse(stats[6],out WorkSpace.plyrStat.potionM);
            int.TryParse(stats[7],out WorkSpace.plyrStat.potionL);
            WorkSpace.plyrStat.name = stats[8];
            WorkSpace.plyrStat.equipedHelm = stats[9];
            WorkSpace.plyrStat.equipeChest = stats[10];
            WorkSpace.plyrStat.equipeGaunt = stats[11];
            WorkSpace.plyrStat.equipeLeg = stats[12];
            WorkSpace.plyrStat.equipedWeapon = stats[13];
            reader.Close();
        }
        /// <summary>
        /// Writes to the file based off what the players stats are
        /// </summary>
        public void writePlayerStats()
        {
            StreamWriter writer = new StreamWriter("playerStats.txt");
            writer.Write($"{WorkSpace.plyrStat.health},{WorkSpace.plyrStat.defence},{WorkSpace.plyrStat.attack},{WorkSpace.plyrStat.speed},{WorkSpace.plyrStat.gold},{WorkSpace.plyrStat.potionS},{WorkSpace.plyrStat.potionM}," +
                $"{WorkSpace.plyrStat.potionL},{WorkSpace.plyrStat.name},{WorkSpace.plyrStat.equipedHelm},{WorkSpace.plyrStat.equipeChest},{WorkSpace.plyrStat.equipeGaunt},{WorkSpace.plyrStat.equipeLeg},{WorkSpace.plyrStat.equipedWeapon}");
            writer.Close();
        }
        /// <summary>
        /// reads file for shopkeep and outs in array
        /// </summary>
        public void readFileSK()
        {
            StreamReader reader = new StreamReader("shopkeep.txt");
            string[] items = reader.ReadLine().Split(',');
            int x = 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (i % 2 == 0)
                {
                    WorkSpace.shopKeep[x].item = items[i];
                }
                else
                {
                    int.TryParse(items[i], out WorkSpace.shopKeep[x].value);
                    x++;
                }
            }
            reader.Close();
        }
        /// <summary>
        /// writes file fore shopkeep
        /// </summary>
        public void writeFileSK()
        {
            StreamWriter writer = new StreamWriter("shopkeep.txt");
            int calc = 0;
            foreach (shopItem i in WorkSpace.shopKeep)
            {
                if (i.item != null)
                {
                    writer.Write(i.item + "," + i.value);
                    calc++;
                    if (calc != WorkSpace.shopKeep.Length)
                    {
                        writer.Write(",");
                    }
                }

            }
            writer.Close();
        }
        /// <summary>
        /// Resest all 
        /// </summary>
        public void reset()
        {
            StreamWriter writer = new StreamWriter("player.txt");
            writer.Write(resetPlayer);
            writer.Close();
            StreamWriter writer2 = new StreamWriter("shopkeep.txt");
            writer2.Write(resetShop);
            writer2.Close();
            StreamWriter writer3 = new StreamWriter("playerStats.txt");
            writer3.Write(resetStats);
            writer3.Close();
        }
    }
}
