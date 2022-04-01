using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionClass : MonoBehaviour
{
    public string ActionName;
    public AnimationClip ActionAnimation;

    public GameObject Character;

    public virtual void Start()
    {
        Character = this.gameObject;
    }

    public void ExecuteAction()
    {
        //Send message to opponent players
        GameObject MessageHandler = GameObject.FindGameObjectWithTag("MessageHandler");

        MessageHandler.GetComponent<MessageTextHandler>().NewSendMessage(GetComponent<CharacterCard>().Card_Name + " used " + ActionName);

        string ActionString = ActionAnimation.ToString().Substring(0, ActionAnimation.ToString().IndexOf(" "));

        Character.GetComponent<Animator>().Play(ActionString
            );

    }
}
