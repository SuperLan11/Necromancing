using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //public Rigidbody rigidBody;
    public GameObject playerObj;
    public GameObject enemyObj;
    public AudioSource enemySFX;

    protected int enemyHealth;
    protected float enemyMovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }    

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision detected");
        
        GameObject needleObj = GameObject.Find("Needle");     
        if (collision.gameObject == needleObj) {            
            enemyHealth--;
            enemySFX.Play();
            ScoreScript.AddScore(1);

            if(enemyHealth <= 0){
                EnemyDeath();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemyDeath(){
        Destroy(enemyObj);
    }
}
