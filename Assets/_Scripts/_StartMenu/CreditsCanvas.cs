using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsCanvas : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Canvas>().enabled=false;
    }
    public void ToggleCredits()
    {
        if(GetComponent<Canvas>().enabled)GetComponent<Canvas>().enabled=false;
        else GetComponent<Canvas>().enabled=true;
    }
}
