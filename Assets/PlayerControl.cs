using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Image fillImage; // The UI image to fill
    public float fillSpeed = 1.0f; // The speed at which the image fills
    public int maxNumber = 65; // The maximum number to increment to when the image is fully filled
    public float fillDelay = 1.0f; // The delay before the image can be filled again
    private bool isFilling = false; // Flag indicating whether the image is being filled
    private float fillAmount = 0.0f; // The current fill amount of the image
    private int currentNumber = 0; // The current number being incremented
    private bool isDelayed = false; // Flag indicating whether there is a delay before the image can be filled again
    private float currentDelayTime = 0.0f; // The current delay time remaining


    public float maxDistance = 10.0f; // The maximum distance the player can target
    public float healAmount = 10.0f; // The amount of healing done per second
    public LayerMask targetLayer; // The layer to search for valid targets

    private bool isHealing = false; // Flag indicating whether the player is currently healing
    private GameObject currentTarget = null; // The current target being healed

    void Update()
    {
        // Check if the right mouse button is being held down
        if (Input.GetMouseButton(1))
        {
            // Increment the fill amount based on the fill speed
            fillAmount += fillSpeed * Time.deltaTime;

            // Clamp the fill amount between 0 and 1
            fillAmount = Mathf.Clamp01(fillAmount);

            // Update the fill amount of the UI image
            fillImage.fillAmount = fillAmount;

            // Increment the current number based on the fill amount
            currentNumber = (int)Mathf.Lerp(0, maxNumber, fillAmount);
        }

        if (Input.GetMouseButtonUp(1))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits a valid target, start healing it
            if (Physics.Raycast(ray, out hit, maxDistance, targetLayer))
            {
                currentTarget = hit.collider.gameObject;
                Health targetHealth = currentTarget.GetComponent<Health>();
                
                if (targetHealth != null)
                {
                    // Heal the target based on the heal amount and time
                    targetHealth.Heal(currentNumber);
                    Debug.Log("Healed for " + currentNumber);

                    // Reset the fill amount and current number
                    fillAmount = 0.0f;
                    currentNumber = 0;

                    // Update the fill amount of the UI image
                    fillImage.fillAmount = fillAmount;
                }
            }
            else
            {
                currentTarget = null;
                // Reset the fill amount and current number
                fillAmount = 0.0f;
                currentNumber = 0;

                // Update the fill amount of the UI image
                fillImage.fillAmount = fillAmount;
            }

            Debug.Log("released");
            Debug.Log(currentNumber);
        }

        // Set the isFilling flag based on the fill amount
        isFilling = (fillAmount > 0.0f);
    }
}
