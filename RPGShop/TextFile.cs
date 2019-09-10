using System.IO;

namespace RPGShop
{
    
    class TextFile
    {
        private string resetPlayer = "Crude Leather Helmet,"+Armor.checkValue("Crude Leather Helmet").ToString()+",Crude Leather Chestpiece,"+Armor.checkValue("Crude Leather Chestpiece").ToString()+",Crude Leather Gauntlets,"+Armor.checkValue("Crude Leather Gauntlets")+ ",Crude Leather Leggings," + Armor.checkValue("Crude Leather Leggings");
        public void readFilePlayer()
        {
            StreamReader reader = new StreamReader("player.txt");
            string[] items = reader.ReadLine().Split(',');
            int x = 0;
            for (int i = 0; i < WorkSpace.player.Length; i++) {
                if (i >=4)
                {
                    WorkSpace.player[i].item = null;
                    WorkSpace.player[i].value = 0;
                }
                else{
                    WorkSpace.player[i].item = items[x].ToString();
                    int.TryParse( items[x+1].ToString(), out WorkSpace.player[i].value);
                    x+=2;
                }
            }
            reader.Close();
        }
        public void writeFilePlayer()
        {
            StreamWriter writer = new StreamWriter("player.txt");
            int calc = 0;
            foreach(playerItem i in WorkSpace.player){
                if (i.item != null)
                {
                    writer.Write(i.item + ","+i.value);
                    calc++;
                    if (calc != WorkSpace.player.Length)
                    {
                        writer.Write(",");
                    }
                }

            }
            writer.Close();
        }
        public void readFileSK()
        {
            StreamReader reader = new StreamReader("shopkeep.txt");
            string[] items = reader.ReadLine().Split(',');
            int x = 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (i % 2 == 0)
                {
                    WorkSpace.shopKeep[x].item = items[i].ToString();
                }
                else
                {
                    int.TryParse(items[i].ToString(), out WorkSpace.shopKeep[x].value);
                    x++;
                }
            }
            reader.Close();
        }
        public void writeFileSK()
        {
            StreamWriter writer = new StreamWriter("shopkeep.txt");
            writer.Close();
        }
        public void reset()
        {
            StreamWriter writer = new StreamWriter("player.txt");
            writer.Write(resetPlayer);
            writer.Close();
        }
    }
}
