using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {

    public float speed = -5f;

    Rigidbody backgroundRigidbody;

	// Use this for initialization
	void Start () {
        backgroundRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        /*Vector3 velocity = new Vector3(speed, 0f, 0f);

        backgroundRigidbody.velocity = velocity;*/

        Vector3 movement = new Vector3(speed * Time.deltaTime, 0f, 0f);
        backgroundRigidbody.MovePosition(transform.position + movement);
    }
}
