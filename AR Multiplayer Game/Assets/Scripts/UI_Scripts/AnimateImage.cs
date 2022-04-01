using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateImage : MonoBehaviour
{
    Image myImage;
    SpriteRenderer mySpriteRenderer;

    void Start()
    {
        myImage = GetComponent<Image>();

        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        myImage.sprite = mySpriteRenderer.sprite;
    }
}
