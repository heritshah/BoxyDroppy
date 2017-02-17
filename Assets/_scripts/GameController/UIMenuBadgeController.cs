using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class UIMenuBadgeController : MonoBehaviour
{
    public Canvas cvMain, cvHelp;
    public int m_coefficient;

    private GameObject[] m_badges;
    private float m_phi;

	// Use this for initialization
	void OnEnable ()
	{
        int numberOfBadgeToShow;

        m_badges = GameObject.FindGameObjectsWithTag(GVars.TAG_BADGE).OrderBy(go => go.name).ToArray();

        GVars.ScreenState = GVars.SCREEN_BADGE;

        m_phi = (1 + Mathf.Sqrt(5)) / 2;

        numberOfBadgeToShow = N_thFibonaccinumber();

        if (numberOfBadgeToShow > m_badges.Length) numberOfBadgeToShow = m_badges.Length;        

        foreach(GameObject badge in m_badges)
        {
            badge.gameObject.SetActive(false);
        }

        for (int index = 0; index < numberOfBadgeToShow; index++)
        {
            m_badges[index].gameObject.SetActive(true);
        }
	}

    public void _ShowHelp()
    {
        GVars.ScreenState = GVars.SCREEN_BADGE_OTHER;
        cvMain.gameObject.SetActive(false);
        cvHelp.gameObject.SetActive(true);
    }

    public void _ShowBadge()
    {
        GVars.ScreenState = GVars.SCREEN_BADGE;
        cvMain.gameObject.SetActive(true);
        cvHelp.gameObject.SetActive(false);
    }

    private int N_thFibonaccinumber()
    {
        int fibonacciNumber = 0;
        int n = 0;
        int totalXP = GVars.TotalXP;

        while(fibonacciNumber * m_coefficient <= totalXP)
        {
            fibonacciNumber = FibonacciNumber(++n);
        }

        return n - 1;
    }

    private int FibonacciNumber(int n)
    {
        int fibonacci = Mathf.RoundToInt((Mathf.Pow(m_phi, n) - Mathf.Pow((1 - m_phi), n)) / Mathf.Sqrt(5));

        return fibonacci;
    }
}
