using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody rigidBody;
    protected GameObject enemyObj;
    
    //public float startX;
    //public float startY;
    //public float startZ;

    // Start is called before the first frame update
    void Start()
    {
        //rigidBody.position = new Vector3(startX, startY, startZ);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision detected");
        
        GameObject needleObj = GameObject.Find("Needle");
        if(collision.gameObject == needleObj){         
            Destroy(enemyObj);
            ScoreScript.AddScore(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
