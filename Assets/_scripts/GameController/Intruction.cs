using UnityEngine;
using System.Collections;

public class Intruction : MonoBehaviour
{
    public float m_time;

	// Use this for initialization
	void OnEnable ()
	{
        if(!GVars.IsShowInstruction)
            Destroy(gameObject);

        StartCoroutine(HideInstruction());	
	}

    IEnumerator HideInstruction()
    {
        yield return new WaitForSeconds(m_time);

        GVars.IsShowInstruction = false;
        Destroy(gameObject);
    }
}
