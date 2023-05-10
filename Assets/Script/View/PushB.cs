using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using controller;

public class PushB : MonoBehaviour
{
    public GameObject ChallengeMode;
    public string BallLabel;
    /*public TMP_Text Inputnum;
    public GameObject BlockB;*/

    private void OnMouseDown() {
        /*Inputnum.text += BallLabel;
        this.gameObject.SetActive(false);
        BlockB.gameObject.SetActive(true);*/

        ChallengeMode.GetComponent<ChallengeMode>().PushB1(BallLabel, this.gameObject);
    }
}