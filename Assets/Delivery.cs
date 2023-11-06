using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    // Package pick up
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.1f;

    // To change car color
    [SerializeField] Color32 hasPackageColor = new Color32(0,255,122,255);
    [SerializeField] Color32 noPackageColor  = new Color32(255,255,255,255);

    SpriteRenderer spriteRenderer;

    void Start() {
        // Get the sprite renderer of this object
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Crash!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Package" && !hasPackage) {
            Debug.Log("Package picked up.");

            // Change status of hasPackage
            hasPackage = true;

            // Destroy package
            Destroy(other.gameObject, destroyDelay);

            // Change color
            spriteRenderer.color = hasPackageColor;
        }

        if (other.tag == "Customer" && hasPackage) {
            Debug.Log("Package delivered.");

            // Change status of hasPackage
            hasPackage = false;

            //Change color
            spriteRenderer.color = noPackageColor;
        }
    }
}
