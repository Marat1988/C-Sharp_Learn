using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork10
{
    public class Character
    {
        public int Health { get; private set; } = 100;

        /* public int GetHealth()
         {
             return health;
         }

         private void SetHealth(int value)
         {
             health = value;
         }*/

        public void Hit(int damage)
        {
            if (damage > Health)
            {
                damage = Health;
            }
            Health -= damage;
        }
    }
}
