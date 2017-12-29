using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


    public float speed = 2f;

    Rigidbody enemyRigidbody;

    // Use this for initialization
    void Start () {
        enemyRigidbody = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        /*Vector3 velocity = new Vector3(speed, 0f, 0f);

        enemyRigidbody.velocity = velocity;*/

        Vector3 movement = new Vector3(speed * Time.deltaTime, 0f, 0f);
        enemyRigidbody.MovePosition(transform.position + movement);
    }

    public void setSpeed (float newSpeed)
    {
        speed = newSpeed;
    }
}
