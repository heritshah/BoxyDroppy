using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    public GameObject[] m_things;
    public float m_time, m_delayTime;

	// Use this for initialization
	void OnEnable ()
	{
        StartCoroutine(Spawning());
	}

    IEnumerator Spawning()
    {
        float delayTime = m_delayTime;

        if (GVars.IsShowInstruction)
            delayTime = m_time;

        yield return new WaitForSeconds(delayTime);

        while (true)
        {
            if (GVars.m_isPlaying)
            {
                int choice = Random.Range(0, m_things.Length);

                Instantiate(m_things[choice], transform.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(m_time);
        }
    }
}
