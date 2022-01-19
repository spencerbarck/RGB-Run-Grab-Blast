using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleGridUpdate : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D[] obsticleColliders;
    void Start()
    {
        foreach(BoxCollider2D obsticle in obsticleColliders)
            AstarPath.active.UpdateGraphs(obsticle.bounds);
    }
}
