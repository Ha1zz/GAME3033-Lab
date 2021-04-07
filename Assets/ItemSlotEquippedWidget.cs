using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotEquippedWidget : MonoBehaviour
{

    private EquippableScriptable Equipable;
    [SerializeField] private Image EnabledImaged;

    private void Awake()
    {
        HideWidget();
    }


    public void ShowWidget()
    {
        gameObject.SetActive(true);
    }

    public void HideWidget()
    {
        gameObject.SetActive(false);
    }

    internal void Initialize(ItemScriptables item)
    {
        if (!(item is EquippableScriptable eqItem)) return;

        Equipable = eqItem;
        ShowWidget();
        Equipable.OnEquipStatusChange += OnEquipmentChange;
        OnEquipmentChange();

    }

    private void OnEquipmentChange()
    {
        EnabledImaged.gameObject.SetActive(Equipable.Equipped);
    }

    private void OnDisable()
    {
        if (Equipable) Equipable.OnEquipStatusChange -= OnEquipmentChange;
    }

}
