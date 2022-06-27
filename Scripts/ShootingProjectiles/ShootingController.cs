using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// A class which controlls player aiming and shooting
/// </summary>
public class ShootingController : MonoBehaviour
{
    [Header("GameObject/Component References")]
    [Tooltip("The projectile to be fired.")]
    public GameObject[] projectilePrefabList;
    public GameObject projectilePrefab = null;
    [Tooltip("The transform in the heirarchy which holds projectiles if any")]
    public Transform projectileHolder = null;

    [Header("Input")]
    [Tooltip("Whether this shooting controller is controled by the player")]
    public bool isPlayerControlled = false;

    [Header("Firing Settings")]
    [Tooltip("The minimum time between projectiles being fired.")]
    public float fireRate = 0.05f;

    [Tooltip("The maximum diference between the direction the" +
        " shooting controller is facing and the direction projectiles are launched.")]
    public float projectileSpread = 1.0f;

    // The last time this component was fired
    private float lastFired = Mathf.NegativeInfinity;

    [Header("Effects")]
    [Tooltip("The effect to create when this fires")]
    public GameObject fireEffect;

    //The input manager which manages player input
    private InputManager inputManager = null;

    public int shootStyle = 0;
    public int basePower = 0;


    /// <summary>
    /// Description:
    /// Standard unity function that runs every frame
    /// Inputs:
    /// none
    /// Returns:
    /// void (no return)
    /// </summary>
    private void Update()
    {
        ProcessInput();
    }

    /// <summary>
    /// Description:
    /// Standard unity function that runs when the script starts
    /// Inputs:
    /// none
    /// Returns:
    /// void (no return)
    /// </summary>
    private void Start()
    {
        SetupInput();
    }


    /// <summary>
    /// Description:
    /// Attempts to set up input if this script is player controlled and input is not already correctly set up 
    /// Inputs:
    /// none
    /// Returns:
    /// void (no return)
    /// </summary>
    void SetupInput()
    {
        if (isPlayerControlled)
        {
            if (inputManager == null)
            {
                inputManager = InputManager.instance;
            }
            if (inputManager == null)
            {
                Debug.LogError("Player Shooting Controller can not find an InputManager in the scene, there needs to be one in the " +
                    "scene for it to run");
            }
        }
    }

    /// <summary>
    /// Description:
    /// Reads input from the input manager
    /// Inputs:
    /// None
    /// Returns:
    /// void (no return)
    /// </summary>
    void ProcessInput()
    {
        if (isPlayerControlled)
        {
            if ((inputManager.firePressed || inputManager.fireHeld) && shootStyle == 0)
            {
                fireRate = 0.1f;
                Fire();
            }
            if ((inputManager.firePressed || inputManager.fireHeld) && shootStyle == 1)
            {
                fireRate = 0.4f;
                Fire();
            }
            if ((inputManager.firePressed || inputManager.fireHeld) && shootStyle == 2)
            {
                fireRate = 0.3f;
                FireStyle2();
            }

        }   
    }

    /// <summary>
    /// Description:
    /// Fires a projectile if possible
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
    public void Fire()
    {
        // If the cooldown is over fire a projectile
        if ((Time.timeSinceLevelLoad - lastFired) > fireRate)
        {
            // Launches a projectile
            SpawnProjectile();

            if (fireEffect != null)
            {
                Instantiate(fireEffect, transform.position, transform.rotation, null);
            }

            // Restart the cooldown
            lastFired = Time.timeSinceLevelLoad;
        }
    }


    public void FireStyle2()
    {
        // If the cooldown is over fire a projectile
        if ((Time.timeSinceLevelLoad - lastFired) > fireRate)
        {
            // Launches a projectile
            SpawnProjectile2();

            if (fireEffect != null)
            {
                Instantiate(fireEffect, transform.position, transform.rotation, null);
            }

            // Restart the cooldown
            lastFired = Time.timeSinceLevelLoad;
        }
    }

    /// <summary>
    /// Description:
    /// Spawns a projectile and sets it up
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
    public void SpawnProjectile()
    {
        // Check that the prefab is valid
        if (projectilePrefab != null)
        {
            // Create the projectile
            GameObject projectileGameObject = Instantiate(projectilePrefab, transform.position, transform.rotation, null);
            projectileGameObject.GetComponent<Damage>().damageAmount += basePower;

            // Account for spread
            Vector3 rotationEulerAngles = projectileGameObject.transform.rotation.eulerAngles;
            rotationEulerAngles.z += Random.Range(-projectileSpread, projectileSpread);
            projectileGameObject.transform.rotation = Quaternion.Euler(rotationEulerAngles);

            // Keep the heirarchy organized
            if (projectileHolder != null)
            {
                projectileGameObject.transform.SetParent(projectileHolder);
            }
        }
    }

    public void SpawnProjectile2()
    {
        // Check that the prefab is valid
        if (projectilePrefab != null)
        {
            // Create the projectile
            GameObject projectileGameObject = Instantiate(projectilePrefab, transform.position, transform.rotation, null);
            GameObject projectileGameObject2 = Instantiate(projectilePrefab, transform.position, transform.rotation, null);
            GameObject projectileGameObject3 = Instantiate(projectilePrefab, transform.position, transform.rotation, null);
            GameObject projectileGameObject4 = Instantiate(projectilePrefab, transform.position, transform.rotation, null);

            projectileGameObject.GetComponent<Damage>().damageAmount += basePower;
            projectileGameObject2.GetComponent<Damage>().damageAmount += basePower;
            projectileGameObject3.GetComponent<Damage>().damageAmount += basePower;
            projectileGameObject4.GetComponent<Damage>().damageAmount += basePower;

            // Account for spread
            Vector3 rotationEulerAngles = projectileGameObject.transform.rotation.eulerAngles;
            rotationEulerAngles.z += Random.Range(-projectileSpread, projectileSpread);
            projectileGameObject.transform.rotation = Quaternion.Euler(rotationEulerAngles);

            // Account for spread
            rotationEulerAngles = projectileGameObject2.transform.rotation.eulerAngles + new Vector3(0, 0, 270);
            rotationEulerAngles.z += Random.Range(-projectileSpread, projectileSpread);
            projectileGameObject2.transform.rotation = Quaternion.Euler(rotationEulerAngles);
;
            rotationEulerAngles = projectileGameObject3.transform.rotation.eulerAngles + new Vector3(0,0,90);
            rotationEulerAngles.z += Random.Range(-projectileSpread, projectileSpread);
            projectileGameObject3.transform.rotation = Quaternion.Euler(rotationEulerAngles);


            // Account for spread
            rotationEulerAngles = projectileGameObject4.transform.rotation.eulerAngles + new Vector3(0, 0, 180);
            rotationEulerAngles.z += Random.Range(-projectileSpread, projectileSpread);
            projectileGameObject4.transform.rotation = Quaternion.Euler(rotationEulerAngles);

            // Keep the heirarchy organized
            if (projectileHolder != null)
            {
                projectileGameObject.transform.SetParent(projectileHolder);
                projectileGameObject2.transform.SetParent(projectileHolder);
                projectileGameObject3.transform.SetParent(projectileHolder);
                projectileGameObject4.transform.SetParent(projectileHolder);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlayerControlled)
        {
            if (collision.gameObject.tag == "StyleChanger")
            {
                shootStyle = collision.gameObject.GetComponent<StyleChanger>().style;
                projectilePrefab = projectilePrefabList[collision.gameObject.GetComponent<StyleChanger>().style];

                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "StatChanger")
            {
                StatManager sm = GameObject.FindGameObjectWithTag("StatManager").GetComponent<StatManager>();
                sm.baseArmor += collision.gameObject.GetComponent<StatChanger>().armor;
                sm.basePower += collision.gameObject.GetComponent<StatChanger>().power;
                sm.baseSpeed += collision.gameObject.GetComponent<StatChanger>().speed;

                Destroy(collision.gameObject);
            }
        }
    }

}
