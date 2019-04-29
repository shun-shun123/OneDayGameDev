using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class GunController : MonoBehaviour {

    public Camera camera;
    public float distance = 50f;
    public int damage = 30;

    private AudioSource audio;
    private Light light;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.1f);
    private ParticleSystem shotParticle;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        light = GetComponentInChildren<Light>();
        shotParticle = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        Shoot();	
	}

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            audio.Play();
            shotParticle.Emit(1);
            StartCoroutine(ShotEffect());
            RayShoot();
        }
    }

    void RayShoot()
    {
        RaycastHit hitInfo;
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = camera.ScreenPointToRay(center);
        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            if (hitInfo.collider.gameObject.CompareTag("Enemy"))
            {
                ObjectController enemyScript = hitInfo.collider.gameObject.GetComponent<ObjectController>();
                enemyScript.Damage(damage, hitInfo.normal * (float)damage * -1);
            }
        }
    }

    IEnumerator ShotEffect()
    {
        light.enabled = true;
        yield return shotDuration;
        light.enabled = false;
    }
}
