using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRGOrB : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    void Awake()
    {
        int color = Random.Range(1,4);

        switch(color)
        {
            case 1:
                spriteRenderer.color = new Color(1,0,0,1f);
                break;
            case 2:
                spriteRenderer.color = new Color(0,1,0,1f);
                break;
            case 3:
                spriteRenderer.color = new Color(0,0,1,1f);
                break;
            default:
                break;
        }
    }
}
