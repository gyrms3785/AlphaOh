using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using controller;

public class InputSB : MonoBehaviour
{
    /*public TMP_Text Inputnum;
    public TMP_Text turn;
    private string number;
    public GameObject Black_screen;
    public GameObject ClearMessage;
    public GameObject TextBoxBox;
    public GameObject TextBox;
    public GameObject ResetButton;
    public GameObject InButton;
    public int count;

    private RectTransform rectTransform;*/

    public GameObject ChallengeMode;

    private void OnMouseDown() {
        /*number = Inputnum.text;
        if(number[1] == 'B')
        {
            string temp1 = number.Substring(0, 2);
            string temp2 = number.Substring(2, 2);
            number = temp2+temp1;
        }
        if(number == "0S0B")
        {
            number = "OUT!";
        }

        for(int i=0; i<TextBoxBox.transform.childCount; i++)
        {
            rectTransform = TextBoxBox.transform.GetChild(i).GetComponent<RectTransform>();
            float temp = rectTransform.anchoredPosition.y;
            rectTransform.anchoredPosition = new Vector3(0, temp+0.2f, -10);
        }
        TextBox.transform.GetChild(0).GetComponent<TMP_Text>().text = "1234";
        TextBox.transform.GetChild(1).GetComponent<TMP_Text>().text = number;
        Instantiate(TextBox, new Vector3 (0,0.1f,-10), Quaternion.identity).transform.SetParent(TextBoxBox.transform, false);

        InButton.GetComponent<InputNumber>().count += 1;
        turn.text = InButton.GetComponent<InputNumber>().count.ToString() + "\nturn";
        
        ResetButton.GetComponent<ResetSB>().Reset();

        RectTransform rectTransform1 = GameObject.Find("Singlemode").GetComponent<RectTransform>();
        RectTransform rectTransform2 = GameObject.Find("Challengemode").GetComponent<RectTransform>();
        rectTransform1.anchoredPosition = new Vector3(0, 0, 0);
        rectTransform2.anchoredPosition = new Vector3(1080, 0, 0);*/

        ChallengeMode.GetComponent<ChallengeMode>().InputSB1();
    }
}