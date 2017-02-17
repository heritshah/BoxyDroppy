using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour
{
    public float m_step, m_minX, m_maxX;
	// Use this for initialization
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == GVars.TAG_BOTTOM_BORDER)
        {
            JumpToNewPos();
        }
    }

    private void JumpToNewPos()
    {
        int choice = Random.Range(0, 2);
        Vector3 newPos = transform.position;

        newPos.y += m_step;

        if(choice == 0)
        {
            newPos.x = m_minX;
        }
        else
        {
            newPos.x = m_maxX;
        }

        transform.position = newPos;
    }
}
