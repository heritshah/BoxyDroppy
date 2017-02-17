using UnityEngine;
using System.Collections;

public class GVars : MonoBehaviour
{
    public const int SCREEN_MENU = 0;
    public const int SCREEN_OTHER_MENU = 1;
    public const int SCREEN_PLAYING = 2;
    public const int SCREEN_BADGE = 3;
    public const int SCREEN_BADGE_OTHER = 4;

    public const float BOX_WIDTH = 16;

    static public int ScreenState;
    public const string SCENE_MENU = "menu";
    public const string SCENE_PLAYING = "Playing";

    public const string TAG_GROUND = "Ground";
    public const string TAG_BASE_BOX = "BaseBox";
    public const string TAG_BOX = "Box";
    public const string TAG_CAMERA = "MainCamera";
    public const string TAG_SPAWN = "Spawn";
    public const string TAG_GAME_CONTROLLER = "GameController";
    public const string TAG_MOVING = "Moving";
    public const string TAG_BOTTOM_BORDER = "BottomBorder";
    public const string TAG_MOVE_SOUND = "MoveSound";
    public const string TAG_BADGE = "Badge";

    private const string m_highscoreKey = "highscore";
    private const string m_totalXP = "totalXP";
    private const string m_instructionShowed = "instruction";

    public const string URL_ABOUT = "http://www.alsatian.co/p/about.html";
    public const string URL_RATE = "market://details?id=com.alsatian.BoxusDroppusPremium";
    //public const string URL_RATE = "market://details?id=com.alsatian.BoxusDroppusPremium";
    //public const string URL_RATE = "market://details?id=com.alsatian.BoxusDroppus";
    public const string URL_PREMIUM = "market://details?id=com.alsatian.BoxusDroppusPremium";

    static public GameObject gameController;
    static public int m_score;
    static public bool m_isPlaying;
    static public float m_currentX;

    static public int TotalXP
    {
        get
        {
            int temp = PlayerPrefs.GetInt(m_totalXP, 0);
            return temp;
        }

        set
        {
            PlayerPrefs.SetInt(m_totalXP, value);
        }
    }

    static public int HighScore
    {
        get
        {
            int temp = PlayerPrefs.GetInt(m_highscoreKey, 0);
            return temp;
        }
        set
        {
            int temp = PlayerPrefs.GetInt(m_highscoreKey, 0);
            if(value > temp)
            {
                PlayerPrefs.SetInt(m_highscoreKey, value);
            }
        }
    }

    static public bool IsShowInstruction
    {
        get
        {
            int temp = PlayerPrefs.GetInt(m_instructionShowed, 1);
            if (temp == 1)
                return true;
            else
                return false;
        }
        set
        {
            if (value == true)
                PlayerPrefs.SetInt(m_instructionShowed, 1);
            else
                PlayerPrefs.SetInt(m_instructionShowed, 0);
        }
    }
}
