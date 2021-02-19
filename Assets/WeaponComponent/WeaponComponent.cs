using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{

    [System.Serializable]
    public struct WeaponStats
    {
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
    public bool Firing = false;
    public bool Reloading = false;

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

    public virtual void FireWeapon()
    {
        
    }

    public void StartReloading()
    {
        Reloading = true;
        ReloadWeapon();
    }

    public void StopReloading()
    {
        //Reloading = false;
    }

    public void ReloadWeapon()
    {
        int bulletToReload = WeaponStats.TotalBulletsAvailable - WeaponStats.ClipSize;
        if (bulletToReload < 0)
        {
            WeaponStats.BulletsInClip += WeaponStats.TotalBulletsAvailable;
            WeaponStats.TotalBulletsAvailable = 0;

        }
        else
        {
            WeaponStats.BulletsInClip = WeaponStats.ClipSize;
            WeaponStats.TotalBulletsAvailable -= WeaponStats.ClipSize;
        }
    }
}

}

