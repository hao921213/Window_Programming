using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E94111091_practice_5_2
{
    internal class Anime
    {
        int count = 0;
        public Anime()
        {
            name =count.ToString();
            hp = 1500;
            def = 300;
            damage = 600;

        }
        private string name;
        private int hp;
        private int def;
        private int damage;

        public string GetName()
        {
            return name;
        }

        public string SetName(string name)
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
    }
}
