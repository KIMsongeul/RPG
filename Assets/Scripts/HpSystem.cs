using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Songeul
{
    public class HpSystem : MonoBehaviour
    {
        public int maxHp;
        public int currentHp;
        public int attackDamage;

        private void Start()
        {
            currentHp = maxHp;
        }

        public bool Damage(int damage)
        {
            currentHp -= damage;
            if (currentHp <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
