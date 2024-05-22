using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody rigidBody;
    public GameObject enemyObj;
    
    public float startX;
    public float startY;
    public float startZ;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.position = new Vector3(startX, startY, startZ);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject playerObj = GameObject.Find("Player");
        Debug.Log("collision detected");

        if(collision.gameObject == playerObj){         
            Destroy(enemyObj);
            Debug.Log("DELETING PLAYER");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
