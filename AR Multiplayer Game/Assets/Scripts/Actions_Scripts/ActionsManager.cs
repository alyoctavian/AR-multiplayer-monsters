using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionsManager : MonoBehaviour
{
    public GameObject[] ActionButtons;

    [ContextMenu("InitializeMoves")]
    public void InitializeMoves(GameObject Character)
    {
        for(int i = 0; i < 4; i++)
        {
            CharacterCard ChCard = Character.GetComponent<CharacterCard>();
            if(i > ChCard.Actions.Length - 1)
            {
                ActionButtons[i].SetActive(false);
            }
            else
            {
                ActionButtons[i].GetComponentInChildren<Text>().text = ChCard.Actions[i].ActionName;
                ActionButtons[i].GetComponent<ActionButtonScript>().action = ChCard.Actions[i];

                ActionButtons[i].SetActive(true);
            }
        }
    }
}
