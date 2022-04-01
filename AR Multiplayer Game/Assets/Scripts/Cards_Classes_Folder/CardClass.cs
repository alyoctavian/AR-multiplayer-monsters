using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardElement
{
    element_fire,
    element_water,
    element_ground,
    element_dark,
    element_ice
}

public class CardClass : MonoBehaviour
{
    public string Card_Name;

    public CardElement Card_Element;

    public int Card_Cost;

    public static string ElementString(CardElement element)
    {
        switch(element)
        {
            case CardElement.element_dark:
                return "Dark Type";

            case CardElement.element_fire:
                return "Fire Type";

            case CardElement.element_water:
                return "Water Type";

            case CardElement.element_ice:
                return "Ice Type";

            case CardElement.element_ground:
                return "Ground Type";
        }

        return "error 005 Element Null";
    }
}
