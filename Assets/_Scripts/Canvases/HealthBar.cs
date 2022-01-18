using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private RectTransform healthBar;
    public float CurrentHealth=100f;
    public float MaxHealth=100f;
    [SerializeField]
    private PlayerCollision PlayerCollision;
    [SerializeField]
    private Text healthText;

    private void Start()
    {
        MaxHealth = PlayerCollision.GetHealth();
    }

    private void Update()
    {
        healthText.text = Mathf.RoundToInt(CurrentHealth).ToString();

        if(PlayerCollision.GetHealth()>0)
            CurrentHealth = PlayerCollision.GetHealth();
        else
            CurrentHealth = 0f;

        healthBar.localScale = new Vector3(CurrentHealth/MaxHealth,1.0f,1.0f);
    }
}
