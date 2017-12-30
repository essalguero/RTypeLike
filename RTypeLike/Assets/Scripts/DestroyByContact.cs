using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "EnemySpawner")
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
