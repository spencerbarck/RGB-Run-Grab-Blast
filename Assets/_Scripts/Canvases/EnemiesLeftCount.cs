using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesLeftCount : MonoBehaviour
{
    [SerializeField]
    private Text healthText;
    void Update()
    {
        healthText.text=GameManager.instance.enemyCount.ToString();
    }
}
