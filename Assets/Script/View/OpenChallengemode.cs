using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChallengemode : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject menu;
    public string level;
    
    private void OnMouseDown() {
        /*Singlemode.gameObject.SetActive(true);
        Challengemode.gameObject.SetActive(true);
        black_screen.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        Mainmenu.gameObject.SetActive(false);

        InButton.GetComponent<InputNumber>().checkC = true;*/

        MainMenu.GetComponent<MainMenu>().OpenChallengemode1(menu, level);
    }
}
