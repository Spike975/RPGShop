using System;

namespace RPGShop
{
    //public float defense;
    //public string name;
    //public string type;
    //public string grade;
    //public string material;
        //grade: Rienforced, hardened, strudy, crude, rusty, tatered
        //material: Chain mail, Steel, iron, bronze, leather
    class Armor
    {
        private static Random rand = new Random();

        /// <summary>
        /// Randomly adds an armor quality to a piece of armor 
        /// </summary>
        /// <param name="grade">Specified quality in an integer value</param>
        /// <returns></returns>
        public static string armorGrade(int grade)
        {
            if (grade == 0)
            {
                return "Tatered";
            }else if (grade == 1)
            {
                return "Rusty";
            }
            else if (grade == 2)
            {
                return "Crude";
            }
            else if (grade == 3)
            {
                return "Sturdy";
            }
            else if (grade == 4)
            {
                return "Hardened";
            }
            else
            {
                return "Reinforced";
            }
        }
        /// <summary>
        /// Randomly adds a armor material to a piece of armor
        /// </summary>
        /// <param name="mat">Specified material in an integer value</param>
        /// <returns></returns>
        public static string armorMaterial(int mat)
        {
            if(mat == 0)
            {
                return "Leather";
            }else if (mat == 1)
            {
                return "Chainmail";
            }
            else if (mat == 2)
            {
                return "Bronze";
            }
            else if (mat == 3)
            {
                return "Iron";
            }
            else
            {
                return "Steel";
            }
        }
        /// <summary>
        /// Creates a random Helmet with random materials and quality
        /// </summary>
        /// <param name="grd">Between 0-5</param>
        /// <param name="mat">Between 0-4</param>
        /// <returns></returns>
        public static string randHelm(int grd,int mat)
        {
            return "" +armorGrade(rand.Next(0,grd))+" " + armorMaterial(rand.Next(0,mat)) +" Helmet";
        }
        /// <summary>
        /// Creastes a more specified helmet
        /// </summary>
        /// <param name="grdL">Lowest Value, usually 0</param>
        /// <param name="grdH">No higher than 5</param>
        /// <param name="matL">Lowest value, Usually 0</param>
        /// <param name="matH">No higher than 4</param>
        /// <returns></returns>
        public static string randHelm(int grdL, int grdH, int matL, int matH)
        {
            return "" + armorGrade(rand.Next(grdL, grdH)) + " " + armorMaterial(rand.Next(matL, matH)) + " Helmet";
        }
        /// <summary>
        /// Creates a random Chestpiece with random materials and quality
        /// </summary>
        /// <param name="grd">Between 0-5</param>
        /// <param name="mat">Between 0-4</param>
        /// <returns></returns>
        public static string randChest(int grd, int mat)
        {
            return "" + armorGrade(rand.Next(0, grd)) + " " + armorMaterial(rand.Next(0, mat)) + " Chestpiece";
        }
        /// <summary>
        /// Creastes a more specified chestpiece
        /// </summary>
        /// <param name="grdL">Lowest Value, usually 0</param>
        /// <param name="grdH">No higher than 5</param>
        /// <param name="matL">Lowest value, Usually 0</param>
        /// <param name="matH">No higher than 4</param>
        /// <returns></returns>
        public static string randChest(int grdL, int grdH, int matL, int matH)
        {
            return "" + armorGrade(rand.Next(grdL, grdH)) + " " + armorMaterial(rand.Next(matL, matH)) + " Chestpiece";
        }
        /// <summary>
        /// Creates a random pair of Gauntlets with random materials and quality
        /// </summary>
        /// <param name="grd">Between 0-5</param>
        /// <param name="mat">Between 0-4</param>
        /// <returns></returns>
        public static string randGaunt(int grd, int mat)
        {
            return "" + armorGrade(rand.Next(0, grd)) + " " + armorMaterial(rand.Next(0, mat)) + " Gauntlets";
        }
        /// <summary>
        /// Creastes a more specified pair of gauntlets
        /// </summary>
        /// <param name="grdL">Lowest Value, usually 0</param>
        /// <param name="grdH">No higher than 5</param>
        /// <param name="matL">Lowest value, Usually 0</param>
        /// <param name="matH">No higher than 4</param>
        /// <returns></returns>
        public static string randGaunt(int grdL, int grdH, int matL, int matH)
        {
            return "" + armorGrade(rand.Next(grdL, grdH)) + " " + armorMaterial(rand.Next(matL, matH)) + " Gauntlets";
        }
        /// <summary>
        /// Creates a random pair of Leggings with random materials and quality
        /// </summary>
        /// <param name="grd">Between 0-5</param>
        /// <param name="mat">Between 0-4</param>
        /// <returns></returns>
        public static string randLeg(int grd, int mat)
        {
            return "" + armorGrade(rand.Next(0, grd)) + " " + armorMaterial(rand.Next(0, mat)) + " Leggings";
        }
        /// <summary>
        /// Creastes a more specified pair of leggings
        /// </summary>
        /// <param name="grdL">Lowest Value, usually 0</param>
        /// <param name="grdH">No higher than 5</param>
        /// <param name="matL">Lowest value, Usually 0</param>
        /// <param name="matH">No higher than 4</param>
        /// <returns></returns>
        public static string randLeg(int grdL, int grdH, int matL, int matH)
        {
            return "" + armorGrade(rand.Next(grdL, grdH)) + " " + armorMaterial(rand.Next(matL, matH)) + " Leggings";
        }
        /// <summary>
        /// Totals up the value of a piece of armor and returns the amount in 
        /// </summary>
        /// <param name="item">Send the items description </param>
        /// <returns></returns>
        public static int checkValue(string item)
        {
            int val = 0;
            string[] _item = item.Split(' ');
            if (_item[0] == "Tatered"){val -= 10;}
            else if (_item[0] == "Rusty"){val -= 5;}
            else if (_item[0] == "Crude") { val += 5; }
            else if (_item[0] == "Sturdy") { val += 15; }
            else if (_item[0] == "Hardened") { val += 30; }
            else if (_item[0] == "Reinforced") { val += 50; }

            if(_item[1] == "Leather") { val += 10; }
            else if(_item[1] == "Chainmail") { val += 20; }
            else if(_item[1] == "Bronze") { val += 50; }
            else if(_item[1] == "Iron") { val += 50; }
            else if(_item[1] == "Steel") { val += 75; }

            if (_item[2] == "Helmet") { val += 35; }
            else if (_item[2] == "Chestpiece") { val += 65; }
            else if (_item[2] == "Gauntlets") { val += 45; }
            else if (_item[2] == "Leggings") { val += 55; }
            return val;
        }
        /// <summary>
        /// Checks the value of the equiped armor
        /// </summary>
        /// <param name="item">Enter the string of the item you want to check</param>
        /// <returns>Defense value in a float</returns>
        public static float checkDefense(string item)
        {
            float val = 0f;
            string[] _item = item.Split(' ');
            if (_item[0] == "Tatered") { val -= .5f; }
            else if (_item[0] == "Rusty") { val -= .25f; }
            else if (_item[0] == "Crude") { val += .25f; }
            else if (_item[0] == "Sturdy") { val += .5f; }
            else if (_item[0] == "Hardened") { val += .75f; }
            else if (_item[0] == "Reinforced") { val += 1f; }

            if (_item[1] == "Leather") { val -= .25f; }
            else if (_item[1] == "Chainmail") { val += 0f; }
            else if (_item[1] == "Bronze") { val += .25f; }
            else if (_item[1] == "Iron") { val += .5f; }
            else if (_item[1] == "Steel") { val += .75f; }

            if (_item[2] == "Helmet") { val += .25F; }
            else if (_item[2] == "Chestpiece") { val += .75f; }
            else if (_item[2] == "Gauntlets") { val += .25f; }
            else if (_item[2] == "Leggings") { val += .5f; }
            return val;
        }
    }
    
}
