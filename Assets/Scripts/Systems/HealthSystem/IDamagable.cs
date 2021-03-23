using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace System.Health_System
{
    public interface IDamagable
    {
        void TakeDamage(float damage);
        void Destroy();
    }
}

