using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerScript: EnemyScript
{    
    int spawnTimer = 0;
    // represents enemy type. increments up to 2, then resets to 0, i'll probably improve readability later
    int enemyIdentifier = 0;
    AudioSource spawnSFX;
    private bool spawnLeft = true;

    [SerializeField] private GameObject skeletonPrefab;
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject vampirePrefab;

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
        Vector3 enemyLoc = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);        

        // alternate the position of spawned enemy from left to right of necromancer
        if(spawnLeft)
        {
            enemyLoc.x -= 10;
        }
        else
        {
            enemyLoc.x += 10;
        }
        spawnLeft = !spawnLeft;

        switch(enemyIdentifier)
        {
            case 0:                
                Instantiate(skeletonPrefab, enemyLoc, Quaternion.identity);
                break;
            case 1:                
                Instantiate(zombiePrefab, enemyLoc, Quaternion.identity);
                break;
            case 2:                
                Instantiate(vampirePrefab, enemyLoc, Quaternion.identity);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {        
        spawnTimer++;
        if (spawnTimer >= 100)
        {
            SpawnEnemy(enemyIdentifier);
            //spawnSFX.Play();

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
