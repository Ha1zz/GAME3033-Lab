using System.Collections;
using System.Collections.Generic;
using System.Health_System;
using UnityEngine;

namespace System.Health_System
{
    public class HealthComponent : MonoBehaviour, IDamagable
    {

        public float Health => CurrentHealth;
        public float MaxHealth => TotalHealth;


        [SerializeField] private float CurrentHealth;
        [SerializeField] private float TotalHealth;

        public void HealPlayer(int effect)
        {
            if (CurrentHealth < MaxHealth && CurrentHealth > 0)
            {
                CurrentHealth += effect;
            }

            if (CurrentHealth <= 0)
            {
                Destroy();
            }
        }

        // Start is called before the first frame update
        protected virtual void Awake()
        {
            CurrentHealth = TotalHealth;
        }



        public virtual void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            Debug.Log(CurrentHealth);
            if (CurrentHealth <= 0)
            {
                Destroy();
            }
        }

        public virtual void Destroy()
        {
            Destroy(gameObject);
        }
    }
}

