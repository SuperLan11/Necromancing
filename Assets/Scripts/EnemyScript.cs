using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //public Rigidbody rigidBody;
    protected GameObject enemyObj;
    public AudioSource enemySFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }    

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision detected");
        
        GameObject needleObj = GameObject.Find("Needle");     
        if (collision.gameObject == needleObj) {            
            enemySFX.Play();
            Destroy(enemyObj);            

            ScoreScript.AddScore(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
