using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSinglemode : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject menu;
    public string level;
    
    private void OnMouseDown() {
        /*Singlemode.gameObject.SetActive(true);
        black_screen.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        Mainmenu.gameObject.SetActive(false);*/

        MainMenu.GetComponent<MainMenu>().OpenSinglemode1(menu, level);
    }
}
