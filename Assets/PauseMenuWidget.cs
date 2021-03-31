using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuWidget : GameHUDWidget
{
    // Start is called before the first frame update
    [SerializeField] private string ExitMenuSceneName;

    public void ResumeGame()
    {
        PauseManager.Instance.UnPauseGame();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(ExitMenuSceneName);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
