using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private GameHUDWidget GameCanvas;
    [SerializeField] private GameHUDWidget PauseCanvas;

    private GameHUDWidget ActiveMenu;


    // Start is called before the first frame update
    void Start()
    {
        DisableAllMenu();
        EnableGameMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnablePauseMenu()
    {
        if (ActiveMenu) ActiveMenu.DisableWidget();

        ActiveMenu = PauseCanvas;
        ActiveMenu.EnableWidget();
    }

    public void EnableGameMenu()
    {
        if (ActiveMenu) ActiveMenu.DisableWidget();

        ActiveMenu = GameCanvas;
        ActiveMenu.EnableWidget();
    }

    public void DisableAllMenu()
    {
        GameCanvas.DisableWidget();
        PauseCanvas.DisableWidget();
    }
}

