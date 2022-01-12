using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance=this;
    }

    public Color playerColor;

    public void StorePlayerColor(Color inputColor)
    {
        playerColor = inputColor;
    }
}
