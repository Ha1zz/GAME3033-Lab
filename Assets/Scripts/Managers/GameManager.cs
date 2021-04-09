using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    //public string GameSaveName { get; private set; } = "";

    public bool CursorActive { get; private set; } = true;

    public string SelectedSaveName { get; set; } = "";


    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void SetActiveSave(string saveName)
    {
        if (string.IsNullOrEmpty(saveName)) return;

        SelectedSaveName = saveName;
    }

    private void EnableCursor(bool enable)
    {
        if (enable)
        {

            print("doing this");
            CursorActive = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            CursorActive = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    private void OnEnable()
    {
       AppEvents.MouseCursorEnabled += EnableCursor;   
    }

    private void OnDisable()
    {
        AppEvents.MouseCursorEnabled -= EnableCursor;
    }
}
