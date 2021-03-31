using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHUDWidget : MonoBehaviour
{
    public void EnableWidget()
    {
        gameObject.SetActive(true);
    }
    public void DisableWidget()
    {
        gameObject.SetActive(false);
    }
}
