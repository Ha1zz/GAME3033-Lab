using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons {

public class AK47WeaponComponent : WeaponComponent
{
    private Camera ViewCamera;

    private RaycastHit HitLocation;
    //[SerializeField] private WeaponStats WeaponStats;

    private void Awake()
    {
        ViewCamera = Camera.main;
    }
    protected override void FireWeapon()
    {
            //WeaponStats.BulletsInClip--;
            if (WeaponStats.BulletsInClip > 0 && !Reloading && !WeaponHolder.Controller.IsJumping)
            {
                base.FireWeapon();

                Debug.Log("CKEC");

                Ray screenRay = ViewCamera.ScreenPointToRay(new Vector3(Crosshair.CurrentAimPosition.x,
                         Crosshair.CurrentAimPosition.y, 0));

                if (Physics.Raycast(screenRay, out RaycastHit hit, WeaponStats.FireDistance, WeaponStats.WeaponHitLayer))
                {
                    Vector3 RayDirection = HitLocation.point - ViewCamera.transform.position;

                    Debug.DrawRay(ViewCamera.transform.position, RayDirection * WeaponStats.FireDistance, Color.red);

                    HitLocation = hit;
                }

            }
            else if (WeaponStats.BulletsInClip <= 0)
            {
                Debug.Log("afd");
                WeaponHolder.StartReloading();
            }
            //base.FireWeapon();
    }

    private void OnDrawGizmos()
    {
        if (HitLocation.transform)
        {
            Gizmos.DrawSphere(HitLocation.point, 0.2f);
        }
    }
}

}



