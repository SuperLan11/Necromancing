using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerScript: EnemyScript
{    
    int spawnTimer = 0;
    // represents enemy type. increments up to 2, then resets to 0, will probably improve readability later
    int enemyIdentifier = 0;
    AudioSource spawnSFX;

    // Start is called before the first frame update
    void Start()
    {
        enemySFX = GameObject.Find("SkeletonHit_SFX").GetComponent<AudioSource>();
        // need to get spawn sfx
        //spawnSFX = GameObject.Find("___").GetComponent<AudioSource>();
        enemyHealth = 10;
        enemyMovementSpeed = 0f;
    }
    
    // wip
    void SpawnEnemy(int enemyIdentifier)
    {
        switch(enemyIdentifier)
        {
            case 0:
                // spawn skeleton
                break;
            case 1:
                // spawn zombie
                break;
            case 2:
                // spawn vampire
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        // placeholder value
        if (spawnTimer < 100)
        {
            SpawnEnemy(enemyIdentifier);
            spawnSFX.Play();

            if (enemyIdentifier < 2)
            {
                enemyIdentifier++;
            }
            else
            {
                enemyIdentifier = 0;
            }

            spawnTimer = 0;
        }      
    }
}
