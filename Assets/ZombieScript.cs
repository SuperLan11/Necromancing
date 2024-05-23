using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : EnemyScript
{   
    // Start is called before the first frame update
    void Start()
    {
        enemyObj = GameObject.Find("Zombie");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
