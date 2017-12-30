using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMover : MonoBehaviour {

    public float speed;

    Rigidbody boltRigidbody;

	// Use this for initialization
	void Start () {
        boltRigidbody = GetComponent<Rigidbody>();

        boltRigidbody.velocity = new Vector3(1f, 0f, 0f) * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
