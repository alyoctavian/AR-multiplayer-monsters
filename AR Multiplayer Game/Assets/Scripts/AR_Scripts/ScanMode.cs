using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using static Vuforia.VuforiaUnity;

public class ScanMode : MonoBehaviour
{

    public static bool ScanModeActive;

    public GameObject ScanButton;
    public GameObject StopScanButton;

    public GameObject ScanUI;
    public GameObject ScanFound;
    public GameObject TeamUIParent;

    // Scan found objects
    public GameObject Btn_AddToTeam;
    public GameObject Btn_SelectChar;

    public GameObject CurrentScannedObject;

    // Character objcets
    public GameObject ActionButtonsParent;

    private void Start()
    {
        CurrentScannedObject = null;

        ScanModeActive = false;
    }

    #region Scan methods

    void DisableAllImageTargets()
    {
        GameObject[] myImageTargets = GameObject.FindGameObjectsWithTag("ImageTarget");

        foreach(GameObject target in myImageTargets)
        {
            target.GetComponent<DefaultTrackableEventHandler>().enabled = false;
        }
    }

    void EnableAllImageTargets()
    {
        GameObject[] myImageTargets = GameObject.FindGameObjectsWithTag("ImageTarget");

        foreach (GameObject target in myImageTargets)
        {
            target.GetComponent<DefaultTrackableEventHandler>().enabled = true;
        }
    }

    public void CheckActiveSprites()
    {
        GameObject[] myImageTargets = GameObject.FindGameObjectsWithTag("ImageTarget");

        foreach (GameObject target in myImageTargets)
        {
            if(target.GetComponentInChildren<SpriteRenderer>().enabled)
            {
                ScanTargetFound(target.transform.GetChild(0).gameObject);
            }
        }
    }

    public void OnScanEnter()
    {
        Debug.Log("Entered Scan Mode");

        ScanModeActive = true;

        VuforiaUnity.SetHint(VuforiaHint.HINT_MAX_SIMULTANEOUS_IMAGE_TARGETS, 1);

        ScanUI.SetActive(true);

        ActionButtonsParent.SetActive(false);

        TeamUIParent.SetActive(false);

        ScanButton.SetActive(false);

        StopScanButton.SetActive(true);

        CheckActiveSprites();
    }

    public void OnScanExit()
    {
        Debug.Log("Exit Scan Mode");

        ScanModeActive = false;

        VuforiaUnity.SetHint(VuforiaHint.HINT_MAX_SIMULTANEOUS_IMAGE_TARGETS, 10);

        ActionButtonsParent.SetActive(false);
        ScanUI.SetActive(false);
        ScanFound.SetActive(false);

        StopScanButton.SetActive(false);

        ScanButton.SetActive(true);
    }

    public void ScanTargetFound(GameObject CardTarget)
    {
        if (ScanModeActive)
        {
            CurrentScannedObject = CardTarget;

            ScanUI.SetActive(false);

            if (CardTarget.GetComponent<CharacterCard>())
            {
                CharacterFound(CardTarget);
            }
        }
    }

    public void ScanTargetLost(GameObject CardTarget)
    {
        if (ScanModeActive && CurrentScannedObject == CardTarget)
        {
            CurrentScannedObject = null;

            ScanFound.SetActive(false);
            ScanUI.SetActive(true);
        }
    }

    #endregion

    #region Team and character methods

    public void TeamUIEnter()
    {
        VuforiaUnity.SetHint(VuforiaHint.HINT_MAX_SIMULTANEOUS_IMAGE_TARGETS, -1);

        OnScanExit();

        TeamUIParent.SetActive(true);
    }

    void CharacterFound(GameObject Character)
    {
        ScanFound.SetActive(true);

        ScanFound.GetComponent<ScanFoundBasic>().InitializeBasicInfo(CurrentScannedObject);

        CharButtons();
    }

    public void CharButtons()
    {
        GameObject Character = CurrentScannedObject;

        if (Character.GetComponent<CharacterCard>().is_inTeam)
        {
            Btn_AddToTeam.SetActive(false);

            Btn_SelectChar.SetActive(true);
        }
        else
        {
            Btn_AddToTeam.SetActive(true);

            Btn_SelectChar.SetActive(false);
        }
    }

    #endregion

    #region Actions methods

    public void SelectCharacter()
    {
        OnScanExit();

        ActionButtonsParent.SetActive(true);

        ActionButtonsParent.GetComponent<ActionsManager>().InitializeMoves(CurrentScannedObject);
    }

    #endregion
}
