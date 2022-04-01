using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonScript : MonoBehaviour
{
    public ActionClass action;

    public void Btn_ExecuteAction()
    {
        action.ExecuteAction();
    }
}
