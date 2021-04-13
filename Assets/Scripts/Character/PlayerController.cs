using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Health_System;
using System.Linq;

namespace Character
{
    public partial class PlayerController : MonoBehaviour,IPausable,ISavable
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

        public void OnSave(InputValue Button)
        {
            SaveSystem.Instance.SaveGame();
        }

        public void OnLoad(InputValue Button)
        {
            SaveSystem.Instance.LoadGame();
        }

        public SaveDataBase SaveData()
        {
            Debug.Log("HEALTH" + HealthComponent.Health);
            PlayerSaveData saveData = new PlayerSaveData
            {
                Name = gameObject.name,
                Position = transform.position,
                Rotation = transform.rotation,
                CurrentHealth = HealthComponent.Health,
                EquippedWeaponData = new WeaponSaveData(WeaponHolder.EquippedWeapon.WeaponStats)
            };

            var itemSaveList = Inventory.GetItemList().Select(item => new ItemSaveData(item)).ToList();
            saveData.itemList = itemSaveList;

            return saveData;
        }


        public void LoadData(SaveDataBase saveData)
        {
            PlayerSaveData playerData = (PlayerSaveData)saveData;
            if (playerData == null) return;

            Transform playerTransform = transform;
            playerTransform.position = playerData.Position;
            playerTransform.rotation = playerData.Rotation;

            Health.SetCurrentHealth(playerData.CurrentHealth);

            foreach (ItemSaveData itemSaveData in playerData.itemList)
            {
                ItemScriptables item = InventoryReferencer.Instance.GetItemReference(itemSaveData.Name);
                Inventory.AddItem(item, itemSaveData.Amount);
            }

            WeaponScriptable weapon = (WeaponScriptable)Inventory.FindItem(playerData.EquippedWeaponData.Name);


            if (!weapon) return;
            weapon.WeaponStats = playerData.EquippedWeaponData.WeaponStats;
            WeaponHolder.EquipWeapon(weapon);


        }
    }
}
