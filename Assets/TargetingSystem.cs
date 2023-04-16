using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    public float maxDistance = 10.0f; // The maximum distance the player can target
    public float healAmount = 10.0f; // The amount of healing done per second
    public LayerMask targetLayer; // The layer to search for valid targets

    private bool isHealing = false; // Flag indicating whether the player is currently healing
    private GameObject currentTarget = null; // The current target being healed

    void Update()
    {
        // Check if the left mouse button is being held down
        if (Input.GetMouseButton(0))
        {
            // Raycast from the player's position to the cursor position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits a valid target, start healing it
            if (Physics.Raycast(ray, out hit, maxDistance, targetLayer))
            {
                isHealing = true;
                currentTarget = hit.collider.gameObject;
            }
            else
            {
                isHealing = false;
                currentTarget = null;
            }
        }
        else
        {
            // Stop healing if the left mouse button is released
            isHealing = false;
            currentTarget = null;
        }

        // Heal the current target if the player is currently healing
        if (isHealing && currentTarget != null)
        {
            // Check if the target has a Health component
            Health targetHealth = currentTarget.GetComponent<Health>();
            if (targetHealth != null)
            {
                // Heal the target based on the heal amount and time
                targetHealth.Heal(healAmount * Time.deltaTime);
            }
        }
    }
}
