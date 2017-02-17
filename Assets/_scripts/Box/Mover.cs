using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float m_force;

    private int m_direction;
    private GameObject m_MoveSound;


	// Use this for initialization
	void OnEnable ()
	{
        m_MoveSound = GameObject.FindGameObjectWithTag(GVars.TAG_MOVE_SOUND);

        m_direction = Random.Range(0, 2);
        if (m_direction < 1) m_direction = -1;

        Move();	
	}

    private void Move()
    {
        Vector2 velocity = new Vector2(m_force * m_direction, GetComponent<Rigidbody2D>().velocity.y);

        GetComponent<Rigidbody2D>().velocity = velocity;
        //Vector2 force = new Vector2(m_direction * m_force, 0f);
        //Vector2 resetVelocity = new Vector2(0f, GetComponent<Rigidbody2D>().velocity.y);

        //GetComponent<Rigidbody2D>().velocity = resetVelocity;
        //GetComponent<Rigidbody2D>().AddForce(force);

        m_direction *= -1;        
    }
	
	// Update is called once per frame
	void Update ()
    {
    //    if (!GetComponent<TouchGround>().m_isTouched)
    //    {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                m_MoveSound.GetComponent<AudioSource>().Play();
                Move();
            }
            else if (Touch())
            {
                m_MoveSound.GetComponent<AudioSource>().Play();
                Move();
            }
        //}
	}

    private bool Touch()
    {
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
                return true;
        }

        return false;
    }
}
