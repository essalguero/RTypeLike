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

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = .25f;

    public Boundary boundary;

    public Vector3 initialPosition = new Vector3(-5f, 0f, 0f);
    //public Quaternion initialRotation = new Quaternion(0f, 0f, 0f, 0f);

    Transform transformPlayer;
    Rigidbody playerRigidBody;
    Vector3 movement;

    float nextFire;

    // Use this for initialization
    void Start()
    {
        transformPlayer = GetComponent<Transform>();
        transformPlayer.position = initialPosition;
        
        playerRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

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

        playerRigidBody.rotation = Quaternion.Euler(0f, 90f, moveVertical * tilt);
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Debug.Log("Fire1 Key");
            GameObject shotObject = Shoot();
        }
    }

    private GameObject Shoot()
    {
        //return Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
        return Instantiate(shot, shotSpawn.position, Quaternion.identity) as GameObject;
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
