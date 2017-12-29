using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject [] EnemyTypes;
    public float minSpawnTime;
    public float maxSpawnTime;
    public float maxEnemies;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", minSpawnTime, maxSpawnTime);
    }
	
	// Update is called once per frame
	

    void Spawn()
    {
        GameObject enemy;

        //Vector3 enemyScale = new Vector3(.5f, 1f, .5f);
        Vector3 enemyScale = new Vector3(.5f, .7f, .6f);
        Vector3 upDirection = new Vector3(0f, 1f, 0f);
        Vector3 forwardDirection = new Vector3(-1f, 0f, 0f);
        Quaternion enemyRotation = Quaternion.LookRotation(forwardDirection, upDirection);
        float randomY;
        Vector3 spawnerPosition = transform.position;
        Vector3 enemyPosition;
        float enemySpeed = -3f;

        int enemyTypeValue;

        for (int i = 0; i < Mathf.Round(Random.Range(1f, maxEnemies)); i++)
        {
            randomY = Random.Range(-3.4f, 3.4f);
            enemyTypeValue = (int)Mathf.Round(Random.Range(0f, 1f));

            switch(enemyTypeValue)
            {
                case 0:
                    enemyScale = new Vector3(.5f, .7f, .6f);
                    upDirection = new Vector3(0f, 1f, 0f);
                    forwardDirection = new Vector3(-1f, 0f, 0f);
                    enemyRotation = Quaternion.LookRotation(forwardDirection, upDirection);
                    enemySpeed = -2f;
                    break;
                case 1:
                    enemyScale = new Vector3(.5f, 1f, .5f);
                    upDirection = new Vector3(0f, 1f, 0f);
                    forwardDirection = new Vector3(1f, 0f, 0f);
                    enemyRotation = Quaternion.LookRotation(forwardDirection, upDirection);
                    enemySpeed = -3f;
                    break;
            }

            enemyPosition = spawnerPosition;
            enemyPosition.y = randomY;
            enemy = Instantiate(EnemyTypes[enemyTypeValue], enemyPosition, enemyRotation);
            enemy.GetComponent<Transform>().localScale = enemyScale;
            enemy.GetComponent<EnemyMovement>().setSpeed(enemySpeed);

            GameObject.Destroy(enemy, 8f);
        }
    }
}
