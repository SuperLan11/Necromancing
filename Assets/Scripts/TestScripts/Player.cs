using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed = 5f; // Speed at which the object moves
    [SerializeField] private Rigidbody rb;

    private int playerHealth = 3;

    // Define isometric movement vectors
    private Vector3 isometricRight = new Vector3(1, 0, 1).normalized;
    private Vector3 isometricLeft = new Vector3(-1, 0, -1).normalized;
    private Vector3 isometricUp = new Vector3(-1, 0, 1).normalized;
    private Vector3 isometricDown = new Vector3(1, 0, -1).normalized;

    //this is all ChatGPT BS, but Unity's input system is stupid so I don't care.
    void Update()
    {

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

    public void DamagePlayer(int damage){
        playerHealth -= damage;
        Debug.Log(playerHealth);

        if(playerHealth <= 0){
            //reloads current level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
