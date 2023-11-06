using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Variables
    [SerializeField] float steerSpeed = 110f;
    [SerializeField] float moveSpeed = 8.5f;
    [SerializeField] float fastSpeed = 12f;
    [SerializeField] float slowSpeed = 8.5f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Driving mechanics
        float moveInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float steerInput = Input.GetAxis("Horizontal") * steerSpeed * (moveInput/moveSpeed);

        transform.Rotate(0,0, -steerInput);
        transform.Translate(0,moveInput,0);        
    }

    void OnTriggerEnter2D(Collider2D other) {
        // Boosts
        if (other.tag == "Boost") {
            moveSpeed = fastSpeed;
            Debug.Log("Boost!");
        }    
    }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }
}
