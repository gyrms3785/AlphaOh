using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using solution.client;

public class SingleMode : MonoBehaviour
{
    public TMP_Text Inputnum;
    public TMP_Text turnS;
    public TMP_Text turnC;
    private string number;
    public GameObject Black_screen;
    public GameObject menu;
    public GameObject Gamemode;
    public GameObject Mainmenu;
    public GameObject ClearMessage;
    public GameObject TextBoxBox;
    public GameObject TextBox;
    public GameObject PushCodeLock;
    public GameObject Block;
    public GameObject ResetButton;
    public GameObject InButton;
    public int count;
    public bool checkC;

    private RectTransform rectTransform;

    public IGameUseCase guc = new GameDummy();

    //with 규민이형, offence에서 먼저 효근 -> 규민형으로 숫자의 string 값을 전달하면 반환형 string으로 0S0B나 4S나 OUT 등을 규민형 -> 효근으로 받기

    public void CheckC1()
    {
        checkC = true;
    }

    public void ExitGame1() //count, time, 텍스트, 로그
    {
        Mainmenu.gameObject.SetActive(true);
        Black_screen.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        Gamemode.gameObject.SetActive(false);
    }

    public void ResetNum1()
    {
        Inputnum.text = "";

        for(int i=0; i<10; i++)
        {
            PushCodeLock.transform.GetChild(i).gameObject.SetActive(true);
        }

        Block.gameObject.SetActive(false);
    }

    public void PushButton1(int ButtonLabel, GameObject PushButton)
    {
        Inputnum.text += ButtonLabel;
        PushButton.SetActive(false);

        if(Inputnum.text.Length == 4)
        {
            Block.gameObject.SetActive(true);
        }
    }

    public void InputNumber1()
    {
        number = Inputnum.text;

        //public string aSbB = to규민(number);
        guc.HandleHumanRequestTurn(number);

        for(int i=0; i<TextBoxBox.transform.childCount; i++)
        {
            rectTransform = TextBoxBox.transform.GetChild(i).GetComponent<RectTransform>();
            float temp = rectTransform.anchoredPosition.y;
            rectTransform.anchoredPosition = new Vector3(0, temp+0.2f, -10);
        }
        TextBox.transform.GetChild(0).GetComponent<TMP_Text>().text = Inputnum.text;
        TextBox.transform.GetChild(1).GetComponent<TMP_Text>().text = guc.HandleHumanResponseTurn();//aSbB로 수정.
        Instantiate(TextBox, new Vector3 (0,0.1f,-10), Quaternion.identity).transform.SetParent(TextBoxBox.transform, false);

        if(TextBox.transform.GetChild(1).GetComponent<TMP_Text>().text == "4S0B")
        {
            Black_screen.gameObject.SetActive(true);
            ClearMessage.gameObject.SetActive(true);
        }

        else
        {
            ResetNum1();
        }

        if(checkC == true)
        {
            count += 1;
            turnC.text = count.ToString() + "\nturn";
        
            RectTransform rectTransform1 = GameObject.Find("Singlemode").GetComponent<RectTransform>();
            RectTransform rectTransform2 = GameObject.Find("Challengemode").GetComponent<RectTransform>();
            rectTransform1.anchoredPosition = new Vector3(-1080, 0, 0);
            rectTransform2.anchoredPosition = new Vector3(0, 0, 0);
        }

        else
        {
            count += 1;
            turnS.text = count.ToString() + "\nturn";
        }
    }

    public void Clear1()
    {
        Block.gameObject.SetActive(false);
        Inputnum.text = "";
        for(int i=0; i<10; i++)
        {
            PushCodeLock.transform.GetChild(i).gameObject.SetActive(true);
        }

        Black_screen.gameObject.SetActive(false);
        Gamemode.gameObject.SetActive(false);
        ClearMessage.SetActive(false);
        Mainmenu.gameObject.SetActive(true);
    }
}
