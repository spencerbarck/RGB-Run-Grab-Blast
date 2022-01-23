using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishOnStart : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer.enabled=false;
    }
}
