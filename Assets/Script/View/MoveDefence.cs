using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDefence : MonoBehaviour
{
    //public GameObject Singlemode;
    public GameObject ChallengeMode;

    //private RectTransform rectTransform1;
    //private RectTransform rectTransform2;

    private void OnMouseDown() {
        /*rectTransform1 = Singlemode.GetComponent<RectTransform>();
        rectTransform2 = Challengemode.GetComponent<RectTransform>();

        rectTransform1.anchoredPosition = new Vector3(-1080, 0, 0);
        rectTransform2.anchoredPosition = new Vector3(0, 0, 0);*/

        ChallengeMode.GetComponent<ChallengeMode>().MoveDefence1();
    }
}
