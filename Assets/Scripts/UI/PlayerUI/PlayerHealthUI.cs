using System.Collections;
using System.Collections.Generic;
using System.Health_System;
using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private TMP_Text HealthText;

    private HealthComponent HealthComponent;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerEvents.OnPlayerHealthSet += OnPlayerHealthSet;
    }

    private void OnPlayerHealthSet(HealthComponent healthComponent)
    {
        HealthComponent = healthComponent;
    }

    void Update()
    {
        if (HealthComponent)
        {
            HealthText.text = HealthComponent.Health.ToString();
        }
    }

}
