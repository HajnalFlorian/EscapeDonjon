using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] SpawnPoint;
    public GameObject[] EnemyPrefab;

    private int RandomSpawn;
    private int RandomMob;

    private bool SpawnAllowed;

    // Start is called before the first frame update
    void Start()
    {
        SpawnAllowed = true;
        InvokeRepeating("SpawnMonster", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnMonster()
    {
        if (SpawnAllowed)
        {
            RandomSpawn = Random.Range(0, SpawnPoint.Length);
            RandomMob = Random.Range(0, EnemyPrefab.Length);
            Instantiate(EnemyPrefab[RandomMob], SpawnPoint[RandomSpawn].position, Quaternion.identity);
        }
    }
}
