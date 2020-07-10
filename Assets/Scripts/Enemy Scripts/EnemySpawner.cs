using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float min_Y = -4.3f, max_Y = 4.3f;
    public GameObject[] AsteroidPrefabs;
    public GameObject enemyPrefabs;
    public float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemies",timer);
    }
    void SpawnEnemies(){
        float pos_Y = Random.Range(min_Y,max_Y);
        Vector3 temp = transform.position;
        temp.y = pos_Y;

        if(Random.Range(0,2)>0){
            Instantiate(AsteroidPrefabs[Random.Range(0,AsteroidPrefabs.Length)],temp, Quaternion.identity
            );
        }else{
            Instantiate(enemyPrefabs,temp,Quaternion.Euler(0f,0f,90f));
        }
        Invoke("SpawnEnemies",timer);
    }
    
}
