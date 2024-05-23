using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : EnemyScript
{    
    // Start is called before the first frame update
    void Start()
    {
        enemyObj = GameObject.Find("Skeleton");
        enemySFX = GameObject.Find("SkeletonHit_SFX").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
