using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text speedText;
    [SerializeField]
    private Text damageText;
    [SerializeField]
    private PlayerCollision playerCollision;
    [SerializeField]
    private PlayerMover playerMover;
    [SerializeField]
    private Projectile playerProjectile;
    
    private void Start()
    {
    }

    void Update()
    {
        healthText.text = "Health: "+playerCollision.GetHealth();
        speedText.text = "Speed: "+playerMover.GetSpeed();
        

        float rgbToDamageConversion = playerProjectile.MaxDamage/255;
        float damageValue = GameManager.instance.PlayerStats.Damage * rgbToDamageConversion;

        damageValue += playerProjectile.MinDamage;

        damageText.text = "Damage: "+damageValue;
    }
}
