using System;

namespace RPGShop
{
    //grade:Masterworked, tempered, strong, balanced, chipped, rusted, cracked
    //material: Steel, iron, brass, lead, bronze, wooden
    //Weapon type: Sword, Axe, Pike, Mace 
    //public float attack;
    //public string name;
    //public string type;
    //public string grade;
    //public string material;
    class Weapons
    {
        private static Random rand = new Random();
        
        /// <summary>
        /// Allows for the creation of a random quality for a weapon
        /// </summary>
        /// <param name="grade">Random number to select a quality</param>
        /// <returns></returns>
        public static string randQuality(int grade)
        {
            if (grade == 0)
            {
                return "Cracked";
            }else if(grade == 1)
            {
                return "Rusted";
            }
            else if (grade == 2)
            {
                return "Chipped";
            }
            else if (grade == 3)
            {
                return "Balanced";
            }
            else if (grade == 4)
            {
                return "Strong";
            }
            else if (grade == 5)
            {
                return "Tempered";
            }
            else
            {
                return "Masterworked";
            }
        }
        /// <summary>
        /// Allows for the creation of a random material for a weapon
        /// </summary>
        /// <param name="mat">Creates a material bassed off 0-5</param>
        /// <returns></returns>
        public static string randMaterial(int mat)
        {
            if (mat == 0)
            {
                return "Wooden";
            }else if (mat == 1)
            {
                return "Brass";
            }
            else if (mat == 2)
            {
                return "Lead";
            }
            else if (mat == 3)
            {
                return "Bronze";
            }
            else if (mat == 4)
            {
                return "Iron";
            }
            else
            {
                return "Steel";
            }
        }
        /// <summary>
        /// Allows for the creation of a random weapon type
        /// </summary>
        /// <param name="wpn">Creates the weapon based on an int from 0-3</param>
        /// <returns></returns>
        public static string randWeapon(int wpn)
        {
            if (wpn == 0)
            {
                return "Sword";
            }
            else if (wpn == 1)
            {
                return "Axe";
            }else if (wpn == 2)
            {
                return "Halberd";
            }
            else
            {
                return "Morningstar";
            }
        }
        /// <summary>
        /// Allows for the creation of more specified weapon
        /// </summary>
        /// <param name="gradeL">Starting varible, usually 0</param>
        /// <param name="gradeH">End varible, no higher than 7</param>
        /// <param name="matL">Starting Varible, usually 0</param>
        /// <param name="matH">Envarible, no higher than 6</param>
        /// <param name="wpnL">1-3</param>
        /// <param name="wpnH">No larger than 3</param>
        /// <returns></returns>
        public static string randCreation(int gradeL, int gradeH, int matL, int matH, int wpnL, int wpnH)
        {
            return "" + randQuality(rand.Next(gradeL,gradeH))+" "+randMaterial(rand.Next(matL,matH))+" "+randWeapon(rand.Next(wpnL,wpnH));
        }
        /// <summary>
        /// Creates a random weapon
        /// </summary>
        /// <param name="grade">1-7</param>
        /// <param name="mat">1-6</param>
        /// <param name="wpn">1-3</param>
        /// <returns></returns>
        public static string randCreation(int grade, int mat, int wpn)
        {
            return "" + randQuality(rand.Next(0, grade)) + " " + randMaterial(rand.Next(0, mat)) + " " + randWeapon(rand.Next(0, wpn));
        }
        /// <summary>
        /// Check the value of the weapon based off the name
        /// </summary>
        /// <param name="item">Name of the weapons</param>
        /// <returns>Worth in Gold</returns>
        public static int checkValue(string item)
        {
            int val = 0;
            string[] _item = item.Split(' ');
            if (_item[0] == "Cracked") { val -= 20; }
            else if (_item[0] == "Rusted") { val -= 10; }
            else if (_item[0] == "Chipped") { val -= 5; }
            else if (_item[0] == "Balanced") { val += 10; }
            else if (_item[0] == "Strong") { val += 25; }
            else if (_item[0] == "Tempered") { val += 40; }
            else if (_item[0] == "Masterworked") { val += 75; }

            if (_item[1] == "Wooden") { val -= 5; }
            else if (_item[1] == "Brass") { val += 10; }
            else if (_item[1] == "Lead") { val += 15; }
            else if (_item[1] == "Bronze") { val += 20; }
            else if (_item[1] == "Iron") { val += 35; }
            else if (_item[1] == "Steel") { val += 60; }

            if (_item[2] == "Sword") { val += 45; }
            else if (_item[2] == "Axe") { val += 50; }
            else if (_item[2] == "Halberd") { val += 65; }
            else if (_item[2] == "Morningstar") { val += 70; }
            return val;
        }
        /// <summary>
        /// Takes the weapons name and calculates the total attack power
        /// </summary>
        /// <param name="item">Weapon Name</param>
        /// <returns>Returns the attack value of the weapon</returns>
        public static float checkAttack(string item)
        {
            float val = 0;
            string[] _item = item.Split(' ');
            if (_item[0] == "Cracked") { val -= .75f; }
            else if (_item[0] == "Rusted") { val -= .5f; }
            else if (_item[0] == "Chipped") { val -= .25f; }
            else if (_item[0] == "Balanced") { val += .25f; }
            else if (_item[0] == "Strong") { val += .5f; }
            else if (_item[0] == "Tempered") { val += 1.25f; }
            else if (_item[0] == "Masterworked") { val += 1.75f; }

            if (_item[1] == "Wooden") { val -= .25f; }
            else if (_item[1] == "Brass") { val += .25f; }
            else if (_item[1] == "Lead") { val += .5f; }
            else if (_item[1] == "Bronze") { val += .75f; }
            else if (_item[1] == "Iron") { val += 1f; }
            else if (_item[1] == "Steel") { val += 1.5f; }

            if (_item[2] == "Sword") { val += 1.125f; }
            else if (_item[2] == "Axe") { val += 1.25f; }
            else if (_item[2] == "Halberd") { val += 1.75f; }
            else if (_item[2] == "Morningstar") { val += 1.875f; }
            return val;
        }
    }
}