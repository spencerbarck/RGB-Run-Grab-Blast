using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickup : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer pickupSprite;
    [SerializeField]
    private float pickupValue = 0.1f;
    void Start()
    {
        GameManager.instance.lastKillEvent += RemovePickup;
        pickupSprite.color = WaveManager.instance.PickupColorChoice;
    }
    private void OnCollisionEnter2D(Collision2D collsion)
    {
        //Give Player Color
        PlayerStats player = collsion.gameObject.GetComponent<PlayerStats>();
        if(player != null)
        {
            Color newColor;

            if(pickupSprite.color.r >0)
                newColor = new Color(player.circleSpriteRenderer.color.r+pickupValue,
                    player.circleSpriteRenderer.color.g,
                    player.circleSpriteRenderer.color.b);
            else if(pickupSprite.color.g >0)
                newColor = new Color(player.circleSpriteRenderer.color.r,
                    player.circleSpriteRenderer.color.g+pickupValue,
                    player.circleSpriteRenderer.color.b);
            else if(pickupSprite.color.b >0)
                newColor = new Color(player.circleSpriteRenderer.color.r,
                    player.circleSpriteRenderer.color.g,
                    player.circleSpriteRenderer.color.b+pickupValue);
            else
                newColor = new Color(0f,0f,0f);

            player.UpdateStats(newColor);
            GameManager.instance.ChangePlayerStats(pickupSprite.color.r);
            RemovePickup();
        }
    }

    public void RemovePickup()
    {
        GameManager.instance.lastKillEvent -= RemovePickup;
        Destroy(gameObject);
    }
}
