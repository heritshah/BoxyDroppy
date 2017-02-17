using UnityEngine;
using System.Collections;

public class TouchBox : MonoBehaviour
{
    public float m_timeToDestroy;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == GVars.TAG_BOX)
        {
            Lose();
        }
    }

    private void Lose()
    {
        StopSpawn();
        GVars.gameController.GetComponent<UIPlayingController>().Lose();
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, m_timeToDestroy);
    }

    private void StopSpawn()
    {
        GVars.m_isPlaying = false;
    }
}
