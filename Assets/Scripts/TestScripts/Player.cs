using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private bool debugMode = false;
    public float speed = 5f; // Speed at which the object moves
    [SerializeField] private Rigidbody rb;

    private GameObject playerObj;

    private Image heart1;
    private Image heart2;
    private Image heart3;

    [SerializeField] private AudioSource damage_SFX;

    private Image[] heartArr = {null, null, null};

    private int playerHealth = 3;
    private int maxPlayerHP = 3;

    private float keyDoorTextRange = 10;
    [SerializeField] private GameObject doorText;

    // Define isometric movement vectors
    private Vector3 isometricRight = new Vector3(1, 0, 1).normalized;
    private Vector3 isometricLeft = new Vector3(-1, 0, -1).normalized;
    private Vector3 isometricUp = new Vector3(-1, 0, 1).normalized;
    private Vector3 isometricDown = new Vector3(1, 0, -1).normalized;

    void Start(){
        if(debugMode){
            playerHealth = int.MaxValue;
        }

        AssignHearts();

        heartArr[0] = heart1;
        heartArr[1] = heart2;
        heartArr[2] = heart3;

        GameObject heart = GameObject.Find("Heart1");
        Debug.Log("heart1: " + heart);

        playerObj = GameObject.Find("Player");

        doorText = GameObject.Find("DoorText");
        doorText.SetActive(false);

        damage_SFX = GameObject.Find("playerDamage_SFX").GetComponent<AudioSource>();
    }

    void AssignHearts()
    {
        heart1 = GameObject.Find("Heart1").GetComponent<Image>();
        heart2 = GameObject.Find("Heart2").GetComponent<Image>();
        heart3 = GameObject.Find("Heart3").GetComponent<Image>();
    }

    //this is all ChatGPT BS, but Unity's input system is stupid so I don't care.
    void Update()
    {
        CheckKeyText();
        // Initialize a new velocity vector
        Vector3 newVelocity = Vector3.zero;

        // Check if any of the WASD keys are held down and update the velocity accordingly
        if (Input.GetKey(KeyCode.W))
        {
            newVelocity += isometricUp * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newVelocity += isometricLeft * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newVelocity += isometricDown * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newVelocity += isometricRight * speed;
        }

        rb.velocity = newVelocity;
    }

    private void CheckKeyText()
    {
        GameObject doorObj = GameObject.Find("KeyDoor");
        //Debug.Log("player: " + playerObj);
        //Debug.Log("door: " + doorObj);
        
        float distance = Vector3.Distance(playerObj.transform.position, doorObj.transform.position);
        
        if (distance < keyDoorTextRange)
        {            
            doorText.SetActive(true);
        }
        else
        {            
            doorText.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {        
        GameObject portal = GameObject.Find("Portal");
        GameObject keyDoor = GameObject.Find("KeyDoor");

        if (collision.gameObject == portal)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);            
            playerHealth = maxPlayerHP;
        }
        else if (collision.gameObject == keyDoor)
        {            
            playerHealth = maxPlayerHP;
        }
    }

    public void DamagePlayer(int damage){
        playerHealth -= damage;
        //Debug.Log(playerHealth);

        damage_SFX.Play();

        if(playerHealth <= 0){
            //reloads current level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playerHealth = maxPlayerHP;
        }

        UpdateHearts();
    }

    private void UpdateHearts()
    {        
        for (int heartIndex = 0; heartIndex < maxPlayerHP; heartIndex++)
        {            
            if (heartIndex >= playerHealth)
            {
                heartArr[heartIndex].enabled = false;
            }
            else
            {
                heartArr[heartIndex].enabled = true;
            }            
        }
        
    }
}
