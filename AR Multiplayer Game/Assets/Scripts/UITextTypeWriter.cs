using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UITextTypeWriter : MonoBehaviour
{
    public Text txt;
    public float WaitTime;
    string story;

    void Awake()
    {
        story = txt.text;
    }

    public void StartWriting(string newString)
    {
        if (story == txt.text)
        {
            story = newString;
            txt.text = "";
            StartCoroutine("PlayText");
        }
    }

    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            txt.text += c;
            yield return new WaitForSeconds(0.125f);
        }
    }
}
