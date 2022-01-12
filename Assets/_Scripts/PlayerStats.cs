using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.StorePlayerColor(GetComponent<SpriteRenderer>().color);
    }
}
