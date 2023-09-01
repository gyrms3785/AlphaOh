using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using controller;

public class ResetSB : MonoBehaviour
{
    /*public TMP_Text Inputnum;
    public GameObject PushCodeLock;
    public GameObject BlockStrike;
    public GameObject BlockBall;*/

    public GameObject ChallengeMode;

    private void OnMouseDown() {
        //Reset();

        ChallengeMode.GetComponent<ChallengeMode>().ResetSB1();
    }

    /*public void Reset()
    {
        Inputnum.text = "";

        for(int i=0; i<10; i++)
        {
            PushCodeLock.transform.GetChild(i).gameObject.SetActive(true);
        }

        BlockStrike.gameObject.SetActive(false);
        BlockBall.gameObject.SetActive(false);
    }*/
}
