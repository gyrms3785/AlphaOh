using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using solution.client;

public class MainMenu : MonoBehaviour
{
    public GameObject Black_screen;
    private GameObject menu;
    public GameObject Mainmenu;
    public GameObject Singlemode;
    public GameObject Challengemode;
    public GameObject InButton;

    public GameObject SingleMode;

    public IGameUseCase guc = new GameAdapter();

    //효근 -> 규민형으로 게임모드(single, challenge)와 난이도 값(예를들면 1, 2, 3 등) string 넘겨주기

    public void OpenSinglemode1(GameObject menu, string level)
    {
        Singlemode.gameObject.SetActive(true);
        Black_screen.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        Mainmenu.gameObject.SetActive(false);

        //to규민("single", level);
        guc.NewGame("BATTLE", level);
    }

    public void OpenChallengemode1(GameObject menu, string level)
    {
        Singlemode.gameObject.SetActive(true);
        Challengemode.gameObject.SetActive(true);
        Black_screen.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        Mainmenu.gameObject.SetActive(false);
        
        //InButton.GetComponent<InputNumber>().checkC = true;
        SingleMode.GetComponent<SingleMode>().CheckC1();

        //to규민("challenge", level);
        guc = new GameAdapter();
        guc.NewGame("CHALLENGE", level);
    }

    public void ShowMenu1(GameObject menu)
    {
        Black_screen.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
    }

    public void BackMenu1(GameObject menu)
    {
        Black_screen.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
    }

    public void ExitApp1()
    {
        Application.Quit();
    }
}
