using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public void _Rate()
    {
        Application.OpenURL(GVars.URL_RATE);
    }

    public void _Buy()
    {
        Application.OpenURL(GVars.URL_PREMIUM);
    }

    public void _About()
    {
        Application.OpenURL(GVars.URL_ABOUT);
    }

    public void _BackToMainMenu()
    {
        GVars.ScreenState = GVars.SCREEN_MENU;
        SceneManager.LoadScene(GVars.SCENE_MENU);
    }

    public void _LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void _Play()
    {
        GVars.ScreenState = GVars.SCREEN_PLAYING;
        GVars.IsShowInstruction = true;
        _LoadScene(GVars.SCENE_PLAYING);
    }
}
