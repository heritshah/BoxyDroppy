using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GVars.ScreenState == GVars.SCREEN_MENU)
            {
                Application.Quit(); 
            }
            else if(GVars.ScreenState == GVars.SCREEN_OTHER_MENU)
            {
                GVars.gameController.GetComponent<UIMenuController>()._btnBack();
            }
            else if(GVars.ScreenState == GVars.SCREEN_PLAYING)
            {
                GVars.gameController.GetComponent<UIManager>()._BackToMainMenu();
            }
            else if(GVars.ScreenState == GVars.SCREEN_BADGE)
            {
                GVars.gameController.GetComponent<UIManager>()._Play();
            }
            else
            {
                GVars.gameController.GetComponent<UIMenuBadgeController>()._ShowBadge();
            }
        }
            
	}
}
