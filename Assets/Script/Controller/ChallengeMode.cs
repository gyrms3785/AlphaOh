using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using solution.client;

namespace controller
{
    public class ChallengeMode : MonoBehaviour
    {
        public TMP_Text Inputnum;
        public TMP_Text turn;
        private string number;
        public GameObject Singlemode;
        public GameObject Challengemode;
        public GameObject Black_screen;
        public GameObject BlockS;
        public GameObject BlockB;
        public GameObject PushCodeLock;
        public GameObject ClearMessage;
        public GameObject TextBoxBox;
        public GameObject TextBox;
        public GameObject InButton;
        public int count;

        private RectTransform rectTransform;
        private RectTransform rectTransform1;
        private RectTransform rectTransform2;

        public IGameUseCase guc = new GameAdapter();

        //with 규민이형, defence에서 먼저 효근 -> 규민형으로 방어값(0S0B나 4S나 OUT 등) string 값을 전달하면 반환형 string으로 1234(또는 정답 없음) 등을 규민형 -> 효근으로 받기

        public void MoveDefence1()
        {
            rectTransform1 = Singlemode.GetComponent<RectTransform>();
            rectTransform2 = Challengemode.GetComponent<RectTransform>();

            rectTransform1.anchoredPosition = new Vector3(-1080, 0, 0);
            rectTransform2.anchoredPosition = new Vector3(0, 0, 0);
        }

        public void MoveOffence1()
        {
            rectTransform1 = Singlemode.GetComponent<RectTransform>();
            rectTransform2 = Challengemode.GetComponent<RectTransform>();

            rectTransform1.anchoredPosition = new Vector3(0, 0, 0);
            rectTransform2.anchoredPosition = new Vector3(1080, 0, 0);
        }

        public void PushS1(string StrikeLabel, GameObject PushB)
        {
            Inputnum.text += StrikeLabel;
            PushB.SetActive(false);
            BlockS.gameObject.SetActive(true);
        }

        public void PushB1(string BallLabel, GameObject PushS)
        {
            Inputnum.text += BallLabel;
            PushS.SetActive(false);
            BlockB.gameObject.SetActive(true);
        }

        public void ResetSB1()
        {
            Inputnum.text = "";

            for(int i=0; i<10; i++)
            {
                PushCodeLock.transform.GetChild(i).gameObject.SetActive(true);
            }

            BlockS.gameObject.SetActive(false);
            BlockB.gameObject.SetActive(false);
        }

        public void InputSB1()
        {
            number = Inputnum.text;

            //public int AI_Question = to규민(number);
            
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
            TextBox.transform.GetChild(0).GetComponent<TMP_Text>().text = "1234";//AI_Question으로 수정
            TextBox.transform.GetChild(1).GetComponent<TMP_Text>().text = number;
            Instantiate(TextBox, new Vector3 (0,0.1f,-10), Quaternion.identity).transform.SetParent(TextBoxBox.transform, false);

            count += 1;
            turn.text = count.ToString() + "\nturn";
            
            ResetSB1();

            RectTransform rectTransform1 = GameObject.Find("Singlemode").GetComponent<RectTransform>();
            RectTransform rectTransform2 = GameObject.Find("Challengemode").GetComponent<RectTransform>();
            rectTransform1.anchoredPosition = new Vector3(0, 0, 0);
            rectTransform2.anchoredPosition = new Vector3(1080, 0, 0);
        }
    }
}