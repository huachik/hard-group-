using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hard_group
{
    public class Creature
    {
        public int LimitHP;
        private int _hp;
        public string Icon;
        public int X;
        public int Y;
        public int Strenght;

        public Creature(int hp, int limit, string icon, int x, int y, int strenght)
        {
            _hp = hp;
            LimitHP = limit;
            Icon = icon;
            X = x;
            Y = y;
            Strenght = strenght;
        }

        public int HP()
        {
            return _hp;
        }

        public void Move(int x, int y)
        {
            X += x;
            Y += y;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
            {
                throw new Exception("Нельзя нанести отрицательное число урона");
            }

            _hp -= damage;

            if (_hp < 0)
            {
                _hp = 0;
            }
        }

        public void TakeHeal(int heal)
        {
            if (heal <= 0)
            {
                throw new Exception("Нельзя полечить на отрицательное число");
            }

            _hp += heal;

            if (_hp > LimitHP)
            {
                _hp = LimitHP;
            }
        }

        public bool IsAlive()
        {
            return _hp > 0;
        }
    }



}
}
