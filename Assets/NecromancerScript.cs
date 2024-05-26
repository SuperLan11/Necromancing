using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerScript: EnemyScript
{    
    private float spawnTimer = 0;
    // in seconds
    private float timeToSpawn = 2.2f;    
    AudioSource spawnSFX;
    private bool spawnLeft = true;

    // represents enemy type. increments up to 2, then resets to 0, i'll probably improve readability later
    private int enemyIdentifier = 0;
    // in seconds
    public static float summonLength = 0.8f;

    [SerializeField] private GameObject skeletonPrefab;
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject vampirePrefab;

    private GameObject[] enemyTypes = { null, null, null };

    //private List<GameObject> enemiesBeingSummoned = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        enemySFX = GameObject.Find("SkeleHit_SFX").GetComponent<AudioSource>();
        spawnSFX = GameObject.Find("enemySpawn_SFX").GetComponent<AudioSource>();

        playerObj = GameObject.Find("Player");
        enemyObj = GameObject.Find("Necromancer");

        enemyHealth = 10;
        enemyMovementSpeed = 0f;

        enemyTypes[0] = skeletonPrefab;
        enemyTypes[1] = zombiePrefab;
        enemyTypes[2] = vampirePrefab;
    }
    
    void SpawnEnemy(int enemyIdentifier)
    {
        Vector3 enemyLoc = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        // alternate the position of spawned enemy from left to right of necromancer
        if (spawnLeft)
        {
            enemyLoc.z -= 10;
        }
        else
        {
            enemyLoc.z += 10;
        }
        spawnLeft = !spawnLeft;

        // hard code the starting y for the summon to below the ground (sorry)
        switch (enemyIdentifier)
        {
            // skeleton
            case 0:
                enemyLoc.y = -8;
                break;
            // zombies
            case 1:            
                // lower zombie y less since it is shorter than the other enemies
                enemyLoc.y -= 8;
                break;
            // vampire
            case 2:
                enemyLoc.y = -9;
                break;
        }

        // once enemy is spawning, prevent their movement, increase y from -5 to 5 (hard code), then allow movement                        
        GameObject enemyObj = Instantiate(enemyTypes[enemyIdentifier], enemyLoc, Quaternion.identity);
        enemyObj.GetComponent<EnemyScript>().isSpawning = true;   
    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();

        spawnTimer += Time.deltaTime;
                
        if (spawnTimer >= timeToSpawn)
        {
            SpawnEnemy(enemyIdentifier);
            spawnTimer = 0;
            spawnSFX.Play();

            if (enemyIdentifier < 2)
            {
                enemyIdentifier++;
            }
            else
            {
                enemyIdentifier = 0;
            }
        }                
    }
}
