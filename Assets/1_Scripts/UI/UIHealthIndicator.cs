using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHealthIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private HealthModule healthModule;


    // Start is called before the first frame update
    void Start()
    {
        Player player = FindAnyObjectByType<Player>();
        healthModule = player.GetComponent<HealthModule>();

        healthModule.OnHealthChanged += SetHealthText;

        //FindAnyObjectByType<HealthModule>().OnHealthChanged += SetHealthText;
        SetHealthText(100);
    }

    public void SetHealthText(float healthValue)
    {
        healthText.text = healthValue.ToString();
    }

}