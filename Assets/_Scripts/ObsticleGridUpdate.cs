using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleGridUpdate : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D obsticleCollider;
    void Start()
    {
        AstarPath.active.UpdateGraphs (obsticleCollider.bounds);
    }
}
