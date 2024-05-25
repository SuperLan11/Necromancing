using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerScript: EnemyScript
{    
    int spawnTimer = 0;
    int timeToSpawn = 1000;    
    AudioSource spawnSFX;
    private bool spawnLeft = true;

    // represents enemy type. increments up to 2, then resets to 0, i'll probably improve readability later
    int enemyIdentifier = 0;
    float summonLength = 0;

    [SerializeField] private GameObject skeletonPrefab;
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject vampirePrefab;

    private GameObject[] enemyTypes = { null, null, null };

    private List<GameObject> enemiesBeingSummoned = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        enemySFX = GameObject.Find("SkeletonHit_SFX").GetComponent<AudioSource>();
        spawnSFX = GameObject.Find("enemySpawn_SFX").GetComponent<AudioSource>();
        // need to get spawn sfx
        //spawnSFX = GameObject.Find("___").GetComponent<AudioSource>();
        enemyHealth = 10;
        enemyMovementSpeed = 0f;

        enemyTypes[0] = skeletonPrefab;
        enemyTypes[1] = zombiePrefab;
        enemyTypes[2] = vampirePrefab;
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

        if (enemyIdentifier == 1)
        {
            // lower zombie y since it is shorter than the other enemies
            enemyLoc.y -= 1;
        }

        // once enemy is spawning, prevent their movement, increase y from -5 to 5 (hard code), then allow movement                        
        GameObject enemyObj = Instantiate(enemyTypes[enemyIdentifier], enemyLoc, Quaternion.identity);
        enemyObj.GetComponent<EnemyScript>().isSpawning = true;
        //enemiesBeingSummoned

        // keep array/list of spawning enemies? once summonTimer of enemy reaches summonTime, change isSpawning and remove from list
    }

    // Update is called once per frame
    void Update()
    {        
        spawnTimer++;
        Debug.Log("delta time: " + Time.deltaTime);
        // delta time is ~0.01
        // want 1 second spawns, 1/0.01
        if (spawnTimer >= timeToSpawn/(600*Time.deltaTime))
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
