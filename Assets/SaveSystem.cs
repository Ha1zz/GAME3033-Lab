using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using System;
using System.Linq;
using UI.Menus;

[Serializable]
class GameSaveData
{
    public PlayerSaveData PlayerSaveData;

    public GameSaveData()
    {
        PlayerSaveData = new PlayerSaveData();
    }

}


public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;

    private GameSaveData GameSave;

    private const string SaveFileKey = "FileSaveData";


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        if (string.IsNullOrEmpty(GameManager.Instance.SelectedSaveName)) return;
        if (!PlayerPrefs.HasKey(GameManager.Instance.SelectedSaveName)) return;

        string jsonString = PlayerPrefs.GetString(GameManager.Instance.SelectedSaveName);
        GameSave = JsonUtility.FromJson<GameSaveData>(jsonString);
        LoadGame();


    }

    public void SaveGame()
    {
        GameSave ??= new GameSaveData();

        var savableObjects = FindObjectsOfType<MonoBehaviour>()
            .Where(monoObject => monoObject is ISavable).ToList();

        ISavable playerSaveObject = savableObjects.First(monoObject => monoObject is PlayerController) as ISavable;
        GameSave.PlayerSaveData = (PlayerSaveData)playerSaveObject?.SaveData();

        string jsonString = JsonUtility.ToJson(GameSave);
        PlayerPrefs.SetString(GameManager.Instance.SelectedSaveName, jsonString);

        SaveToGameSaveList();

    }

    private void SaveToGameSaveList()
    {
        if (PlayerPrefs.HasKey(SaveFileKey))
        {
            GameDataList saveList = JsonUtility.FromJson<GameDataList>(PlayerPrefs.GetString(SaveFileKey));
            
            if (saveList.SaveFileNames.Contains(GameManager.Instance.SelectedSaveName)) return;
            saveList.SaveFileNames.Add(GameManager.Instance.SelectedSaveName);

            PlayerPrefs.SetString(SaveFileKey, JsonUtility.ToJson(saveList));
        }
        else
        {
            GameDataList saveList = new GameDataList();
            saveList.SaveFileNames.Add(GameManager.Instance.SelectedSaveName);

            PlayerPrefs.SetString(SaveFileKey, JsonUtility.ToJson(saveList));
        }
    }


    public void LoadGame()
    {
        var savableObjects = FindObjectsOfType<MonoBehaviour>()
            .Where(monoObject => monoObject is ISavable).ToList();

        ISavable playerObject = savableObjects.First(monoObject => monoObject is PlayerController) as ISavable;
        playerObject?.LoadData(GameSave.PlayerSaveData);
    }
}
