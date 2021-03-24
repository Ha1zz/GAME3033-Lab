using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;

namespace UI.Menus
{
    public class LoadGameWidget : MenuWidget
    {
        private GameDataList GameData;

        [Header("Scene to Load")] [SerializeField]
        private string SceneToLoad;

        [Header("References")]
        [SerializeField] private RectTransform LoadItemPanel;
        [SerializeField] private TMP_InputField NewGameInputField;

        [Header("Prefabs")]
        [SerializeField] GameObject SaveSlotPrefab;

        private const string SaveFileKey = "FileSaveData";

        [SerializeField] private bool Debug;

        // Start is called before the first frame update
        private void Start()
        {
            if (Debug) SaveDebugData();

            WipeChildren();
            LoadGameData();
        }

        private void WipeChildren()
        {
            foreach (RectTransform saveSlot in LoadItemPanel)
            {
                Destroy(saveSlot.gameObject);
            }
            LoadItemPanel.DetachChildren();
        }

        private void SaveDebugData()
        {
            GameDataList dataList = new GameDataList();
            dataList.SaveFileNames.AddRange(new List<string> { "Save 1", "Save 2", "Save 3" });
            PlayerPrefs.SetString(SaveFileKey, JsonUtility.ToJson(dataList));
        }

        private void LoadGameData()
        {
            if (!PlayerPrefs.HasKey(SaveFileKey)) return;

            string jsonString = PlayerPrefs.GetString(SaveFileKey);
            GameData = JsonUtility.FromJson<GameDataList>(jsonString);

            if (GameData.SaveFileNames.Count <= 0) return;

            foreach (string saveName in GameData.SaveFileNames)
            {
                SaveSlotWidget widget = Instantiate(SaveSlotPrefab,LoadItemPanel).GetComponent<SaveSlotWidget>();
                widget.Initialize(this, saveName);
            }
        }

        public void LoadScene()
        {
            SceneManager.LoadScene(SceneToLoad);
        }

        public void CreateNewGame()
        {
            if (string.IsNullOrEmpty(NewGameInputField.text)) return;
            GameManager.Instance.SetActiveSave(NewGameInputField.text);
            LoadScene();
        }

    }

    [SerializeField]
    class GameDataList
    {
        public List<string> SaveFileNames = new List<string>();
    }

}
