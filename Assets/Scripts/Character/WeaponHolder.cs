using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;
using Character;

public class WeaponHolder : InputMonoBehaviour
{
    [Header("Weapon To Spawn"), SerializeField]
    private WeaponScriptable WeaponToSpawn;

    [SerializeField]
    private Transform WeaponSocketLocation;

    private Transform GripIKLocation;

    // Components
    public PlayerController Controller => PlayerController;
    PlayerController PlayerController;
    Crosshair PlayerCrossHair;
    Animator PlayerAnimator;

    //
    private bool WasFiring = false;
    private bool FiringPressed = false;

    // Ref
    private Camera ViewCamera;

    public WeaponComponent EquippedWeapon => WeaponComponent;
    private WeaponComponent WeaponComponent;

    // AnimatorHashes

    private new void Awake()
    {
        base.Awake();
        PlayerController = GetComponent<PlayerController>();
        PlayerAnimator = PlayerController.GetComponent<Animator>();
        if (PlayerController)
        {
            PlayerCrossHair = PlayerController.CrossHair;
        }

        ViewCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        //GameObject spawnedWeapon = Instantiate(WeaponToSpawn, WeaponSocketLocation.position, WeaponSocketLocation.rotation, WeaponSocketLocation);

        //if (!spawnedWeapon) return;
        //if (spawnedWeapon)
        //{
        //    WeaponComponent = spawnedWeapon.GetComponent<WeaponComponent>();
        //    if (WeaponComponent)
        //    {
        //        GripIKLocation = WeaponComponent.GripLocation;
        //    }
        //}

        //WeaponComponent.Initialize(this, PlayerController.CrossHair);
        //PlayerAnimator.SetInteger("WeaponType", (int)WeaponComponent.WeaponStats.WeaponType);
        //PlayerEvents.Invoke_OnWeaponEquipped(WeaponComponent);

        //if (WeaponToSpawn) EquipWeapon(WeaponToSpawn);

    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (GripIKLocation == null) return;


        PlayerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
        PlayerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, GripIKLocation.position);
    }

    //public void OnReload(InputValue pressed)
    //{
    //    PlayerAnimator.SetBool("IsReloading", pressed.isPressed);
    //}
    //public void OnFire(InputValue pressed)
    //{
    //    PlayerAnimator.SetBool("IsFiring", pressed.isPressed);
    //}

    private void StartFiring()
    {
        if (WeaponComponent.WeaponStats.TotalBulletsAvailable <= 0 &&
            WeaponComponent.WeaponStats.BulletsInClip <= 0) return;

        PlayerController.IsFiring = true;
        PlayerAnimator.SetBool("IsFiring", PlayerController.IsFiring);
        WeaponComponent.StartFiring();
    }

    private void StopFiring()
    {
        PlayerController.IsFiring = false;
        PlayerAnimator.SetBool("IsFiring", PlayerController.IsFiring);
        WeaponComponent.StopFiring();
    }

    public void OnReload(InputValue button)
    {
        StartReloading();
    }
    public void OnFire(InputValue button)
    {
        FiringPressed = button.isPressed;

        if (WeaponComponent == null) return;

        if (button.isPressed)
        {
            StartFiring();
        }
        else
        {
            StopFiring();
        }
    }

    public void OnLookFix(InputAction.CallbackContext obj)
    {
        Vector3 independentMousePosition = ViewCamera.ScreenToViewportPoint(PlayerCrossHair.CurrentAimPosition);

        PlayerAnimator.SetFloat("AimHorizontal", independentMousePosition.x);
        PlayerAnimator.SetFloat("AimVertical", independentMousePosition.y);
    }

    private new void OnEnable()
    {
        base.OnEnable();
        GameInput.PlayerActionMap.Look.performed += OnLookFix;
    }

    private new void OnDisable()
    {
        base.OnDisable();
        GameInput.PlayerActionMap.Look.performed -= OnLookFix;
    }

    public void StartReloading()
    {
        if (WeaponComponent.WeaponStats.TotalBulletsAvailable <= 0 &&
            PlayerController.IsFiring)
        {
            StopFiring();
            return;
        }

        PlayerController.IsReloading = true;
        PlayerAnimator.SetBool("IsReloading", true);
        WeaponComponent.StartReloading();

        InvokeRepeating(nameof(StopReloading), 0, 0.1f);
    }

    public void StopReloading()
    {
        if (PlayerAnimator.GetBool("IsReloading")) return;

        PlayerController.IsReloading = false;
        WeaponComponent.StopReloading();

        CancelInvoke(nameof(StopReloading));

        if (!WasFiring && !FiringPressed) return;

        StartFiring();
        WasFiring = false;
    }

    public void EquipWeapon(WeaponScriptable weaponScripable)
    {
        GameObject spawnedWeapon = Instantiate(weaponScripable.ItemPrefab, WeaponSocketLocation.position, WeaponSocketLocation.rotation, WeaponSocketLocation);

        if (!spawnedWeapon) return;
        if (spawnedWeapon)
        {
            WeaponComponent = spawnedWeapon.GetComponent<WeaponComponent>();
            if (WeaponComponent)
            {
                GripIKLocation = WeaponComponent.GripLocation;
            }
        }

        WeaponComponent.Initialize(this, weaponScripable);
        PlayerAnimator.SetInteger("WeaponType", (int)WeaponComponent.WeaponStats.WeaponType);
        PlayerEvents.Invoke_OnWeaponEquipped(WeaponComponent);
    }

    public void UnEquipWeapon()
    {
        Destroy(WeaponComponent.gameObject);
        WeaponComponent = null;
    }


}


