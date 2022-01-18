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

    private void Start()
    {
        MaxHealth = PlayerCollision.GetHealth();
        Debug.Log("Max Health "+ MaxHealth);
    }

    private void Update()
    {
        CurrentHealth = PlayerCollision.GetHealth();

        healthBar.localScale = new Vector3(CurrentHealth/MaxHealth,1.0f,1.0f);
    }
}
