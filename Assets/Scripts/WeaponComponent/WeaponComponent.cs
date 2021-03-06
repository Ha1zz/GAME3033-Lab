using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Weapons
{
        public enum WeaponType
        {
            None,
            MachineGun,
            Pistol,

        }

        [System.Serializable]
        public struct WeaponStats
        {
            public WeaponType WeaponType;
            public string Name;
            public float Damage;
            public float BulletsInClip;
            public int ClipSize;
            public int TotalBulletsAvailable;

            public float FireStartDelay;
            public float FireRate;
            public float FireDistance;
            public bool Repeating;

            public LayerMask WeaponHitLayer;
        }

    public class WeaponComponent : MonoBehaviour
    {
        public Transform GripLocation => GripIKLocation;
        [SerializeField] private Transform GripIKLocation;

        public WeaponStats WeaponStats;

        protected WeaponHolder WeaponHolder;
        protected Crosshair Crosshair;
        public void Initialize(WeaponHolder weaponHolder,Crosshair crosshair)
        {
            WeaponHolder = weaponHolder;
            Crosshair = crosshair;
        }
        public bool Firing { get; private set; }
        public bool Reloading { get; private set; }

        public virtual void StartFiring()
        {
            Firing = true;
            if (WeaponStats.Repeating)
            {
                InvokeRepeating(nameof(FireWeapon),WeaponStats.FireStartDelay,WeaponStats.FireRate);
            }
            else
            {
                FireWeapon();
            }
        }

        public virtual void StopFiring()
        {
            Firing = false;
            CancelInvoke(nameof(FireWeapon));
        }

        protected virtual void FireWeapon()
        {
            WeaponStats.BulletsInClip--;
        }

        public virtual void StartReloading()
        {
            Reloading = true;
            ReloadWeapon();
        }

        public virtual void StopReloading()
        {
            Reloading = false;
        }

        protected virtual void ReloadWeapon()
        {
            int bulletToReload = WeaponStats.ClipSize - WeaponStats.TotalBulletsAvailable;
            if (bulletToReload < 0)
            {
                Debug.Log("Reload");
                WeaponStats.BulletsInClip = WeaponStats.ClipSize;
                WeaponStats.TotalBulletsAvailable -= WeaponStats.ClipSize;

            }
            else
            {
                Debug.Log("Out Of Ammo");
                WeaponStats.BulletsInClip = WeaponStats.TotalBulletsAvailable;
                WeaponStats.TotalBulletsAvailable = 0;
            }
        }
    }

}

