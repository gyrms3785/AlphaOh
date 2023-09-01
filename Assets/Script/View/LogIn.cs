using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using TMPro;
using GooglePlayGames;

public class LogIn : MonoBehaviour
{
    public TMP_Text LogText;
    public RawImage imgAvatar;

    private void Start() {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Login();
    }

    public void Login()
    {
        Social.localUser.Authenticate((bool success) => {
            if(success)
            {
                LogText.text = Social.localUser.id + "\n" + Social.localUser.userName;
                imgAvatar.texture = Social.localUser.image;
            }
            else
            {
                LogText.text = "로그인 실패";
            }
        });
    }

    private void OnMouseDown() {
        Login();
    }
}
