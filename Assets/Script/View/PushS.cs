using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using controller;

public class PushS : MonoBehaviour
{
    public GameObject ChallengeMode;
    public string StrikeLabel;
    /*public TMP_Text Inputnum;
    public GameObject BlockS;*/

    private void OnMouseDown() {
        /*Inputnum.text += StrikeLabel;
        this.gameObject.SetActive(false);
        BlockS.gameObject.SetActive(true);*/

        ChallengeMode.GetComponent<ChallengeMode>().PushS1(StrikeLabel, this.gameObject);
    }
}