using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;
public class WeaponHolder : InputMonoBehaviour
{
    [Header("Weapon To Spawn"), SerializeField]
    private GameObject WeaponToSpawn;

    [SerializeField]
    private Transform WeaponSocketLocation;

    private Transform GripIKLocation;

    // Components
    PlayerController PlayerController;
    Crosshair PlayerCrossHair;
    Animator PlayerAnimator;

    // Ref
    Camera ViewCamera;
    private WeaponComponent EquippedWeapon;

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
        GameObject spawnedWeapon = Instantiate(WeaponToSpawn, WeaponSocketLocation.position, WeaponSocketLocation.rotation, WeaponSocketLocation);

        if (!spawnedWeapon) return;
        if (spawnedWeapon)
        {
            EquippedWeapon = spawnedWeapon.GetComponent<WeaponComponent>();
            if (EquippedWeapon)
            {
                GripIKLocation = EquippedWeapon.GripLocation;
            }
        }

        EquippedWeapon.Initialize(this, PlayerController.CrossHair);
        PlayerEvents.Invoke_OnWeaponEquipped(EquippedWeapon);
    }

    private void OnAnimatorIK(int layerIndex)
    {
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

    public void OnReload(InputValue button)
    {
        StartReloading();
    }
    public void OnFire(InputValue button)
    {
        if (button.isPressed)
        {
            PlayerController.IsFiring = true;
            PlayerAnimator.SetBool("IsFiring", PlayerController.IsFiring);
            EquippedWeapon.StartFiring();
        }
        else
        {
            PlayerController.IsFiring = false;
            PlayerAnimator.SetBool("IsFiring", PlayerController.IsFiring);
            EquippedWeapon.StopFiring();
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
        PlayerController.IsReloading = true;
        PlayerAnimator.SetBool("IsReloading", PlayerController.IsReloading);
        EquippedWeapon.StartReloading();

        InvokeRepeating(nameof(StopReloading), 0, 0.1f);
    }

    public void StopReloading()
    {
        if (PlayerAnimator.GetBool("IsReloading")) return;

        PlayerController.IsReloading = false;
        EquippedWeapon.StopReloading();

        CancelInvoke(nameof(StopReloading));
    }
}


