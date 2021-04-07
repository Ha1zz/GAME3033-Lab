using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSlotAmountWidget : MonoBehaviour
{
    [SerializeField] TMP_Text AmountText;

    private ItemScriptables Item;

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
        if (!Item.Stackable) return;

        Item = item;
        ShowWidget();
        Item.OnAmountChange += OnAmountChange;
        OnAmountChange();

    }

    private void OnAmountChange()
    {
        AmountText.text = Item.Amount.ToString();
    }

    private void OnDisable()
    {
        if(Item) Item.OnAmountChange -= OnAmountChange;
    }
}
