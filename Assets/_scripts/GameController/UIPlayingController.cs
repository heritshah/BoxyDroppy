using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPlayingController : MonoBehaviour
{
    public Canvas m_cvPlaying, m_cvLose;
    public Text m_txtScore, m_txtInfo, m_txtBonus;

    public float m_timeToShowBonusText;
	// Use this for initialization
	void OnEnable ()
	{
        GVars.ScreenState = GVars.SCREEN_PLAYING;
	}
	
    public void ShowBonusText(string text)
    {
        m_txtBonus.gameObject.SetActive(true);
        m_txtBonus.text = text;

        StartCoroutine(HideBonusText());
    }

    public void _PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Lose()
    {
        SetNewXP();
        SetHighScore();
        FillInfo();
        SwitchToLoseScene();
    }

    public void UpdateScore(int score)
    {
        GVars.m_score = score;
        m_txtScore.text = GVars.m_score.ToString();

        GetComponent<AudioSource>().Play();
    }

    private void SetNewXP()
    {
        int xp = GVars.TotalXP + GVars.m_score;
        GVars.TotalXP = xp;
    }

    private void SetHighScore()
    {
        GVars.HighScore = GVars.m_score;
    }

    private void FillInfo()
    {
        string info = GVars.m_score.ToString() + "\n" + GVars.HighScore.ToString() + "\n" + "\n" + GVars.TotalXP;

        m_txtInfo.text = info;
    }

    private void DeactiveAllScenes()
    {
        m_cvLose.gameObject.SetActive(false);
        m_cvPlaying.gameObject.SetActive(false);
    }

    private void SwitchToLoseScene()
    {
        m_cvLose.gameObject.SetActive(true);
        m_cvPlaying.gameObject.SetActive(false);
    }

    IEnumerator HideBonusText()
    {
        yield return new WaitForSeconds(m_timeToShowBonusText);

        m_txtBonus.gameObject.SetActive(false);
    }
}
