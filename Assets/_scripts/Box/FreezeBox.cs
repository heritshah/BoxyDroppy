using UnityEngine;
using System.Collections;

public class FreezeBox : MonoBehaviour
{
	public void FreezeMe(float time)
    {
        StartCoroutine(Freeze(time));
    }

    public void DisableKinematic(GameObject other, float timeToFreeze)
    {
        StartCoroutine(IE_DisableKinematic(other, timeToFreeze));
    }

    IEnumerator Freeze(float time)
    {
        yield return new WaitForSeconds(time);

        transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody2D>().isKinematic = true;

        Destroy(GetComponent<FreezeBox>());
    }

    IEnumerator IE_DisableKinematic(GameObject other, float timeToFreeze)
    {
        yield return new WaitForSeconds(timeToFreeze);

        GetComponent<Rigidbody2D>().isKinematic = false;

        if (other.gameObject.tag != GVars.TAG_BASE_BOX)
            other.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
