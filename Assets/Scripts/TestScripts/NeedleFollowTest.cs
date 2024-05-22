using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleFollowTest : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float speed = 5f;


    void Update()
    {
        // Raycast checking for mouse position hitting a floor or something with a collider
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Move the needle towards the hit point of the raycase
        if (Physics.Raycast(ray, out RaycastHit hit)) {
            transform.position = Vector3.MoveTowards(transform.position, hit.point, speed * Time.deltaTime);
            transform.forward = hit.point - transform.position;
        }
    }
}