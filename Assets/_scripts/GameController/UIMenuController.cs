using UnityEngine;
using System.Collections;

public class UIMenuController : MonoBehaviour
{
    public Canvas cvMenu, cvSupport, cvDonation;

	// Use this for initialization
	void OnEnable ()
	{
        GVars.ScreenState = GVars.SCREEN_MENU;
	}
	
	public void _btnSupport()
    {
        HideAllCanvas();
        GVars.ScreenState = GVars.SCREEN_OTHER_MENU;
        cvSupport.gameObject.SetActive(true);
    }

    public void _btnDonation()
    {
        HideAllCanvas();
        GVars.ScreenState = GVars.SCREEN_OTHER_MENU;
        cvDonation.gameObject.SetActive(true);
    }

    public void _btnBack()
    {
        HideAllCanvas();
        GVars.ScreenState = GVars.SCREEN_MENU;
        cvMenu.gameObject.SetActive(true);
    }

    private void HideAllCanvas()
    {
        cvMenu.gameObject.SetActive(false);
        cvSupport.gameObject.SetActive(false);
        cvDonation.gameObject.SetActive(false);
    }
}
