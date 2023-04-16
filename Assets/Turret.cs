using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab to be instantiated
    public Transform firePoint; // The point where the bullets will be fired from
    public float fireDelay = 1.0f; // The delay between shots in seconds
    public float bulletSpeed = 10.0f; // The speed of the bullets
    private float timeSinceLastFire = 0.0f; // The time since the last shot

    void Update()
    {
        // Increment the time since the last shot
        timeSinceLastFire += Time.deltaTime;

        // If enough time has passed since the last shot, fire a bullet
        if (timeSinceLastFire >= fireDelay)
        {
            // Reset the timer
            timeSinceLastFire = 0.0f;

            // Instantiate a bullet at the fire point
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Set the velocity of the bullet
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        }
    }
}
