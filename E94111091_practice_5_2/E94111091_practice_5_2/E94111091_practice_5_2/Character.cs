using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E94111091_practice_5_2
{
    internal class Character
    {
        public Character(string name)
        {
            if(name == "Cardigan")
            {
                this.name = name;
                hp = 2130;
                def = 475;
                damage = 305;
                cost = 18;
                cd = 20;
            }
            else if (name=="Myrtle")
            {
                this.name = name;
                hp = 1565;
                def = 300;
                damage = 520;
                cost = 10;
                cd = 22;
            }
            else if (name == "Melantha")
            {
                this.name = name;
                hp = 2745;
                def = 155;
                damage = 738;
                cost = 15;
                cd = 40;
            }
            full_hp = hp;
        }
        private string name;
        private int hp;
        private int full_hp;
        private int def;
        private int damage;
        private int cost;
        private int cd;

        public string GetName()
        {
            return name;
        }

        public int GetHp()
        {
            return hp;
        }

        public void SetHp(int value)
        {
            hp = value;
        }

        public int GetFullHp()
        {
            return full_hp;
        }

        public int GetDef()
        {
            return def;
        }

        public void SetDef(int value)
        {
            def = value;
        }

        public int GetDamage()
        {
            return damage;
        }

        public void SetDamage(int value)
        {
            damage = value;
        }

        public int GetCost()
        {
            return cost;
        }

        public void SetCost(int value)
        {
            cost = value;
        }

        public int GetCD()
        {
            return cd;
        }

        public int SetCD()
        {
            return cd;
        }

    }
}
