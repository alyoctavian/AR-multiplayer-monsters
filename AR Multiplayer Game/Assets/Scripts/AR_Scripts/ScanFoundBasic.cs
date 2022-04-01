using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanFoundBasic : MonoBehaviour
{
    public Text nameText;
    public Text typeText;

    public void InitializeBasicInfo(GameObject CardTarget)
    {
        nameText.text = CardTarget.GetComponent<CardClass>().Card_Name;

        typeText.text = CardClass.ElementString(CardTarget.GetComponent<CardClass>().Card_Element);
    }
}
