using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleFollowTest : MonoBehaviour
{
    [SerializeField] private GameObject cursor;
    [SerializeField] private float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, cursor.transform.position, speed * Time.deltaTime);
        transform.forward = cursor.transform.position - transform.position;
    }
}
