using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireScript : EnemyScript
{    
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 3;
        enemyMovementSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (playerObj.transform.position - enemyObj.transform.position).normalized;
        direction.y = 0;
        enemyObj.transform.forward = direction;

        enemyObj.GetComponent<Rigidbody>().velocity = direction * enemyMovementSpeed;
    }
}
