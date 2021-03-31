using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UI.Menus;

public class SaveSlotWidget : MonoBehaviour
{
    private string SaveName;

    private GameManager Manager;

    private LoadGameWidget LoadWidget;

    [SerializeField] private TMP_Text SaveGameText;

    private void Awake()
    {
        Manager = GameManager.Instance;      
    }

    public void Initialize(LoadGameWidget parentWidget,string saveName)
    {
        LoadWidget = parentWidget;
        SaveName = saveName;
        SaveGameText.text = saveName;
    }

    public void SelectSave()
    {
        Manager.SetActiveSave(SaveName);
        LoadWidget.LoadScene();
    }
}
