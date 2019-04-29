using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEditor;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float speed = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(x, 0f, y);
        transform.position += movement * speed;
    }

    void CameraMovement()
    {

    }
}
