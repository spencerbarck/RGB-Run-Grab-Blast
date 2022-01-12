using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRandomColor : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer.color = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f),1f);
    }
}
