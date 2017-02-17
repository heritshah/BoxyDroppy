using UnityEngine;
using System.Collections;

public class ClickSound : MonoBehaviour
{
    public void _ClickSound()
    {
        GetComponent<AudioSource>().Play();
    }
}
