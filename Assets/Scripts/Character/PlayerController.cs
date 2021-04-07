using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Health_System;

public class PlayerController : MonoBehaviour,IPausable
{
    public Crosshair CrossHair => CrossHairComponent;
    [SerializeField] private Crosshair CrossHairComponent;



    public HealthComponent Health => HealthComponent;
    private HealthComponent HealthComponent;

    public InventoryComponent Inventory => InventoryComponent;
    private InventoryComponent InventoryComponent;



    public WeaponHolder WeaponHolder => WeaponHolderComponent;
    private WeaponHolder WeaponHolderComponent;


    private GameUIController GameUIController;
    private PlayerInput PlayerInput;

    [SerializeField] private ConsumableScriptable Consume;

    public bool IsFiring;
    public bool IsReloading;
    public bool IsJumping;
    public bool IsRunning;
    public bool InInventory;

    private void Awake()
    {
        if (GameUIController == null) GameUIController = FindObjectOfType<GameUIController>();
        if (PlayerInput == null) PlayerInput = GetComponent<PlayerInput>();
        if (WeaponHolderComponent == null) WeaponHolderComponent = GetComponent<WeaponHolder>();
        if (HealthComponent == null) HealthComponent = GetComponent<HealthComponent>();
        if (InventoryComponent == null) InventoryComponent = GetComponent<InventoryComponent>();

    }

    private void Start()
    {
        Health.TakeDamage(50);
        //Consume.UseItem(this);
    }


    public void OnPauseGame()
    {
        PauseManager.Instance.PauseGame();
    }

    public void OnInventory(InputValue button)
    {
        if (InInventory)
        {
            InInventory = false;
            OpenInventory(false);
        }
        else
        {
            InInventory = true;
            OpenInventory(true);
        }

    }

    private void OpenInventory(bool open)
    {
        if (open)
        {
            PauseManager.Instance.PauseGame();
            GameUIController.EnableInventoryMenu();
        }
        else
        {
            PauseManager.Instance.UnPauseGame();
            GameUIController.EnableGameMenu();
        }
    }


    public void OnUnPauseGame()
    {
        PauseManager.Instance.UnPauseGame();
    }

    public void PauseGame()
    {
        GameUIController.EnablePauseMenu();
        if (PlayerInput)
        {
            PlayerInput.SwitchCurrentActionMap("PauseActionMap");
        }
    }

    public void UnPauseGame()
    {
        GameUIController.EnableGameMenu();
        if (PlayerInput)
        {
            PlayerInput.SwitchCurrentActionMap("PlayerActionMap");
        }
    }
}
