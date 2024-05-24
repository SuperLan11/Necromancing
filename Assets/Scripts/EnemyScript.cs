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

    //the fact that I have to do it this way makes me think Unity's parents are cousins
    protected Player playerScript;

    private const int MAX_JANK_COOLDOWN = 60;
    private int currentCooldown = 60;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = playerObj.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider collision)
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

        }else if(collision.gameObject == playerObj){
            //playerScript.DamagePlayer(1);
            //Debug.Log("we get here");
            playerObj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            playerObj.GetComponent<Player>().DamagePlayer(1);
        }
    }

    //this is jank but it's a game jam
    private void OnTriggerStay(Collider collision)
    {
        if (currentCooldown <= 0){
            currentCooldown = MAX_JANK_COOLDOWN;

            Debug.Log("collision detected");

            GameObject needleObj = GameObject.Find("Needle");
            if (collision.gameObject == needleObj) {
                enemyHealth--;
                enemySFX.Play();
                ScoreScript.AddScore(1);

                if(enemyHealth <= 0){
                    EnemyDeath();
                }

            }else if(collision.gameObject == playerObj){
                //playerScript.DamagePlayer(1);
                //Debug.Log("we get here");
                playerObj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                playerObj.GetComponent<Player>().DamagePlayer(1);
            }

        }else{
            currentCooldown--;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void EnemyDeath(){
        Destroy(enemyObj);
    }
};