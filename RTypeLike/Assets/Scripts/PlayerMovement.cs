using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10f;
    public Vector3 initialPosition = new Vector3(-5f, 0f, 0f);
    public Quaternion initialRotation = new Quaternion(0f, 0f, 0f, 0f);

    Transform transformPlayer;
    Rigidbody playerRigidBody;
    Vector3 movement;

    // Use this for initialization
    void Start()
    {
        transformPlayer = GetComponent<Transform>();
        transformPlayer.position = initialPosition;

        //transform.SetPositionAndRotation(initialPosition, initialRotation);

        playerRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 velocity = new Vector3(1f, 0f, 0f);

        movement.Set(h, v, 0f);

        movement = movement.normalized * speed * Time.deltaTime;

        //transform.position = transform.position + velocity * speed * Time.deltaTime;
        //playerRigidBody.MovePosition(transform.position + velocity * speed * Time.deltaTime + movement * speed * Time.deltaTime);

        playerRigidBody.MovePosition(transformPlayer.position + (movement + velocity) * speed * Time.deltaTime);
    }

    void Update()
    {
        //playerRigidBody.MovePosition(transform.position + movement);

        if (Input.GetButton("Fire1"))
        {

            Debug.Log("Fire1 Key");
            Shoot();
        }
    }

    private void Shoot()
    {

    }
}
