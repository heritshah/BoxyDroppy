using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
	void OnEnable()
    {
        GVars.gameController = GameObject.FindGameObjectWithTag(GVars.TAG_GAME_CONTROLLER);
        
        if (GVars.ScreenState == GVars.SCREEN_PLAYING)
        {
            GVars.m_score = 0;
            GVars.m_isPlaying = true;
            GVars.m_currentX = 0;
        }
    }
}
