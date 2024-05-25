using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : EnemyScript
{    
    // Start is called before the first frame update
    void Start()
    {
        enemySFX = GameObject.Find("SkeletonHit_SFX").GetComponent<AudioSource>();
        enemyHealth = 1;
        enemyMovementSpeed = 10f;

        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
