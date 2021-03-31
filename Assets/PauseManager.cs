using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; /// <summary>
/// /////////////////
/// </summary>

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance = null;

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




    // Start is called before the first frame update
    void Start()
    {
        UnPauseGame();
    }

    public void PauseGame()
    {
        var pausebles = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>();
        foreach (IPausable pauseObject in pausebles)
        {
            pauseObject.PauseGame();
        }

        Time.timeScale = 0;
        AppEvents.Invoke_OnMouseCursorEnable(true);

    }
    public void UnPauseGame()
    {
        var pausebles = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>();
        foreach (IPausable pauseObject in pausebles)
        {
            pauseObject.UnPauseGame();
        }

        Time.timeScale = 1;
        AppEvents.Invoke_OnMouseCursorEnable(false);
    }

    private void OnDestroy()
    {
        UnPauseGame();
    }


}

interface IPausable
{
    void PauseGame();
    void UnPauseGame();
}