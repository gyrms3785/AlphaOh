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
        public GameObject PushCodeLock;
        public GameObject ClearMessage;
        public GameObject TextBoxBox;
        public GameObject TextBox;
        public GameObject InButton;
        public int count;

        int Sint = 0;
        int Bint = 0;

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

        public void PushS1(int StrikeLabel)
        {
            if(Sint == StrikeLabel)
            {
                StrikeLabel = 0;
            }

            Sint = StrikeLabel;
            GameObject StrikeZone = PushCodeLock.transform.GetChild(0).gameObject;
            
            if(4 - Sint < Bint)
            {
                PushB1(4-Sint);
            }
            Inputnum.text = Sint.ToString()+'S'+Bint.ToString()+'B';
            StrikeZone.transform.GetChild(4).GetComponent<TMP_Text>().text = Sint.ToString()+'S';

            for(int i=0; i<Sint; i++)
            {
                StrikeZone.transform.GetChild(3-i).GetComponent<SpriteRenderer>().material.color = new Color(1.25f, 1.25f, 1.25f);
            }
            for(int i=0; i<4-Sint; i++)
            {
                StrikeZone.transform.GetChild(i).GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f);
            }
        }

        public void PushB1(int BallLabel)
        {
            if(Bint == BallLabel)
            {
                BallLabel = 0;
            }

            Bint = BallLabel;
            GameObject BallZone = PushCodeLock.transform.GetChild(1).gameObject;

            if(4 - Bint < Sint)
            {
                PushS1(4-Bint);
            }
            Inputnum.text = Sint.ToString()+'S'+Bint.ToString()+'B';
            BallZone.transform.GetChild(4).GetComponent<TMP_Text>().text = Bint.ToString()+'B';

            for(int i=0; i<Bint; i++)
            {
                BallZone.transform.GetChild(3-i).GetComponent<SpriteRenderer>().material.color = new Color(1.25f, 1.25f, 1.25f);
            }
            for(int i=0; i<4-Bint; i++)
            {
                BallZone.transform.GetChild(i).GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f);
            }
        }

        public void ResetSB1()
        {
            Inputnum.text = "";
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