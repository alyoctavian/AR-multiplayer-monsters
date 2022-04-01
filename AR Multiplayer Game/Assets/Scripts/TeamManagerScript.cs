using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamManagerScript : MonoBehaviour
{
    public List<GameObject> Team;

    public GameObject TeamParentUI;

    public GameObject PrefabCharacterButton;

    GameObject VuforiaManager;

    void Start()
    {
        VuforiaManager = GameObject.Find("VuforiaManager");
    }

    public void AddCharacterToTeam()
    {
        GameObject ch = VuforiaManager.GetComponent<ScanMode>().CurrentScannedObject;

        if (ch != null && !ch.GetComponent<CharacterCard>().is_inTeam)
        {
            ch.GetComponent<CharacterCard>().is_inTeam = true;

            Team.Add(ch);

            VuforiaManager.GetComponent<ScanMode>().CharButtons();
        }
    }

    public void InitializeTeamView()
    {

        GameObject[] PreseteButtons = GameObject.FindGameObjectsWithTag("TeamChButtons");

        for(int i = 0; i < PreseteButtons.Length; i++)
        {
            if(i >= Team.Count)
            {
                PreseteButtons[i].GetComponent<Image>().enabled = false;
            }
            else
            {

                SpriteRenderer CharSprite = Team[i].GetComponent<SpriteRenderer>();

                PreseteButtons[i].GetComponent<Image>().sprite = CharSprite.sprite;

                PreseteButtons[i].GetComponent<Animator>().runtimeAnimatorController = Team[i].GetComponent<Animator>().runtimeAnimatorController;

                float maxSize = Mathf.Max(CharSprite.sprite.rect.width,
                                            CharSprite.sprite.rect.height);

                maxSize *= 2.0f;

                PreseteButtons[i].GetComponent<Image>().rectTransform.sizeDelta = new Vector2(maxSize, maxSize);

                PreseteButtons[i].GetComponent<Image>().enabled = true;
            }
        }
    }
}
