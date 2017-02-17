using UnityEngine;
using System.Collections;

public class TouchGround : MonoBehaviour
{
    public int m_perfectScore, m_niceScore;
    public string m_perfectText, m_niceText;

    public float m_timeToFreeze;
    public float m_timeToFreezeForever;

    public bool m_isTouched;
    public bool m_isFreezed;

    private GameObject m_camera;
    private GameObject[] m_movingObjects;

    private float m_differNice, m_differPerfect;

	// Use this for initialization
	void OnEnable ()
	{
        m_camera = GameObject.FindGameObjectWithTag(GVars.TAG_CAMERA);
        m_movingObjects = GameObject.FindGameObjectsWithTag(GVars.TAG_MOVING);
        m_isTouched = false;
        m_isFreezed = false;

        m_differNice = GVars.BOX_WIDTH / 4;
        m_differPerfect = GVars.BOX_WIDTH / 8;
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == GVars.TAG_BASE_BOX || other.gameObject.tag == GVars.TAG_BOX) && !m_isTouched)
        {
            GetComponent<FreezeBox>().FreezeMe(m_timeToFreezeForever);

            StopMoving(other.gameObject);
            IncreaseScore();
            MoveObjects();

            m_isTouched = true;

            SetNewBoxX();

            RemoveScripts();
        }
    }

    private void SetNewBoxX()
    {
        GVars.m_currentX = transform.position.x;
    }

    private void IncreaseScore()
    {
        GVars.m_score += CalculateScore();

        GVars.gameController.GetComponent<UIPlayingController>().UpdateScore(GVars.m_score);
    }

    private int CalculateScore()
    {
        float differ = Mathf.Abs(transform.position.x - GVars.m_currentX);

        if (differ <= m_differPerfect)
        {
            GVars.gameController.GetComponent<UIPlayingController>().ShowBonusText(m_perfectText);
            return m_perfectScore;
        }
        else if (differ <= m_differNice)
        {
            GVars.gameController.GetComponent<UIPlayingController>().ShowBonusText(m_niceText);
            return m_niceScore;
        }
        else return 1;            
    }

    private void MoveObjects()
    {
        foreach(GameObject movingObject in m_movingObjects)
        {
            movingObject.GetComponent<Movement>().SetNewPos();
        }
    }

    private void StopMoving(GameObject other)
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        EnableKinematic(other);
    }

    private void RemoveScripts()
    {
        Destroy(GetComponent<Mover>());
        Destroy(GetComponent<TouchGround>());

        //MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();

        //foreach(MonoBehaviour script in scripts)
        //{
        //    Destroy(script, m_timeToFreeze * 2);
        //}
    }

    private void EnableKinematic(GameObject other)
    {
        SetKinematic(other, true);
        GetComponent<FreezeBox>().DisableKinematic(other, m_timeToFreeze);
    }

    private void SetKinematic(GameObject other, bool status)
    {
        transform.rotation = Quaternion.identity;
        other.gameObject.transform.transform.rotation = Quaternion.identity;

        GetComponent<Rigidbody2D>().isKinematic = status;

        //if (other.GetComponent<Rigidbody2D>().isKinematic)
        other.GetComponent<Rigidbody2D>().isKinematic = status;
    }
}
