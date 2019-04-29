using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

    public float hitPoint = 100;
    private ParticleSystem destroyEffect;
    private WaitForSeconds effectDuration = new WaitForSeconds(2.0f);

    private void Start()
    {
        destroyEffect = GetComponentInChildren<ParticleSystem>();
    }

    public void Damage(int damage, Vector3 force)
    {
        Debug.Log("Damage: " + hitPoint);
        hitPoint -= damage;
        Debug.Log("force: " + force);
        gameObject.GetComponent<Rigidbody>().AddForce(force);
        if (hitPoint < 0)
        {
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        destroyEffect.Play(true);
        gameObject.GetComponent<Renderer>().enabled = false;
        yield return effectDuration;
        Destroy(this.gameObject);
    }
}
