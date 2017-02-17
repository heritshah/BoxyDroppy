using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float m_step, m_time;

    private Vector3 m_newPos;

	// Use this for initialization
	void OnEnable ()
	{
        m_newPos = transform.position;

        //StartCoroutine(Move());
	}
	
	// Update is called once per frame
	void Update ()
	{
        transform.position = Vector3.Lerp(transform.position, m_newPos, Time.deltaTime);	
	}

    public void SetNewPos()
    {
        m_newPos = new Vector3(transform.position.x, transform.position.y + m_step, transform.position.z);
    }

    //IEnumerator Move()
    //{
    //    yield return new WaitForSeconds(m_time);

    //    while(true)
    //    {
    //        SetNewPos();

    //        yield return new WaitForSeconds(m_time);
    //    }
    //}
}
