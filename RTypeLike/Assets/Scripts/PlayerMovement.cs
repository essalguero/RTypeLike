using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerMovement : MonoBehaviour {

    public float deltaSpeed = 1.5f;
    public float tilt;

    public Boundary boundary;

    public Vector3 initialPosition = new Vector3(-5f, 0f, 0f);
    //public Quaternion initialRotation = new Quaternion(0f, 0f, 0f, 0f);

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

        /*float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 velocity = new Vector3(1f, 0f, 0f);

        movement.Set(h, v, 0f);

        movement = movement.normalized * speed * Time.deltaTime;

        //transform.position = transform.position + velocity * speed * Time.deltaTime;
        //playerRigidBody.MovePosition(transform.position + velocity * speed * Time.deltaTime + movement * speed * Time.deltaTime);

        playerRigidBody.MovePosition(transformPlayer.position + (movement + velocity) * speed * Time.deltaTime);*/

        //Vector3 movement;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical") * deltaSpeed;

        if (moveHorizontal != 0)
        {
            Debug.Log("Move Horizontal: " + moveHorizontal);
            moveHorizontal = ((moveHorizontal * deltaSpeed));
        } else
        {
            moveHorizontal = 0f;
        }

        movement = new Vector3(moveHorizontal, moveVertical, 0.0f) * Time.deltaTime;
        playerRigidBody.MovePosition(transform.position + movement);
        //playerRigidBody.velocity = movement;

        playerRigidBody.position = new Vector3
        (
            Mathf.Clamp(playerRigidBody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(playerRigidBody.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );

        //playerRigidBody.position = new Vector3(playerRigidBody.position.x, playerRigidBody.position.y, 0f);

        //playerRigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, playerRigidBody.velocity.x * -tilt);
        //playerRigidBody.rotation = Quaternion.Euler(0f, 90f, playerRigidBody.velocity.y * tilt);
        playerRigidBody.rotation = Quaternion.Euler(0f, 90f, moveVertical * tilt);
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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision with object: " + collision.gameObject.tag);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colision with object: " + other.gameObject.name);
    }
}
