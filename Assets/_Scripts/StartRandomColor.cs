using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRandomColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float minColor = 1;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        float r = 0;
        float g = 0;
        float b = 0;
        while((r+g+b<minColor))
        {
            r = Random.Range(0f,1f);
            g = Random.Range(0f,1f);
            b = Random.Range(0f,1f);
        }

        spriteRenderer.color = new Color(r,g,b,1f);
        
    }
}
