using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGBUI : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer playerSprite;
    [SerializeField]
    private Text rText;
    [SerializeField]
    private Text gText;
    [SerializeField]
    private Text bText;

    void Update()
    {
        if(int.Parse(rText.text)>=255)
            rText.text="255";
        else
            rText.text=Mathf.RoundToInt(playerSprite.color.r*255f).ToString();

        if(int.Parse(gText.text)>=255)
            gText.text="255";
        else
            gText.text=Mathf.RoundToInt(playerSprite.color.g*255f).ToString();

        if(int.Parse(bText.text)>=255)
            bText.text="255";
        else
            bText.text=Mathf.RoundToInt(playerSprite.color.b*255f).ToString();
    }
}
