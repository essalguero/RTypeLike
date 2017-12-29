using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour {

    public float speed = 10f;
    public Vector3 initialPosition = new Vector3(0f, -10f, 0f);

    Transform transform;

	// Use this for initialization
	void Start () {
        transform = GetComponent<Transform>();

        transform.SetPositionAndRotation(initialPosition, Quaternion.identity);

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 velocity = new Vector3(speed, 0f, 0f);

        transform.position = transform.position + velocity * Time.deltaTime;

    }
}
