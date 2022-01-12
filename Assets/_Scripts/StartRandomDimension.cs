using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRandomDimension : MonoBehaviour
{
    [SerializeField]
    private float maxXSize = 4f;
    [SerializeField]
    private float maxYSize = 4f;
    void Start()
    {
        GetComponent<Transform>().localScale = new Vector3(Random.Range(0.1f,maxXSize),Random.Range(0.1f,maxYSize),1);
    }
}
