using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{
    // Complete each section marked TODO.

    [Header("Spawner Settings")]
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRadius = 8f;

    [Header("Animation")]
    public Animator animator;
    public bool playIdleAnimationOnStart = true;
    public string idleAnimationName = "Idle";

    [Header("Spawn Feedback")]
    public GameObject spawnParticlePrefab;
    public float spawnParticleLifetime = 2f;
    public AudioClip spawnSound;
    public AudioSource audioSource;

    [Header("Game Manager")]
    public GameManager gameManager;

    [Header("Debug")]
    public bool spawningEnabled = true;
    public bool enableDebugKeys = true;
    public bool showDebugLogs = true;

    public Key toggleSpawnKey = Key.Y;
    public Key spawnOnceKey = Key.O;
    public Key destroyEnemiesKey = Key.I;

    [Header("Debug View")]
    public float spawnTimer = 0f;

    // This collection stores all enemies created by this spawner.
    public List<GameObject> spawnedEnemies = new List<GameObject>();

    private void Awake()
    {
        // If it is, get the AudioSource component from this GameObject.
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }


        // If it is, get the Animator component from this GameObject.
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }



        // If it is, find the GameManager in the scene.
        if (gameManager == null)
        {
            gameManager = GetComponent<GameManager>();
        }

    }

    private void Start()
    {
        //Call the function that plays the idle animation.
        PlayIdleAnimation();


        //If debug logs are enabled, print that the EnemySpawner has started.
        if (showDebugLogs == true)
        {
            Debug.Log("Enemy Spawner Has Started");
        }


        // Check that gameManager is not null.
        // If it exists, call AddSpawner.
        if (gameManager != null)
        {
            gameManager = GetComponent<GameManager>();
            gameManager.AddSpawner();
        }


    }

    private void Update()
    {
        // Call the function that handles the debug input.

        HandleDebugInput();

        // Check whether spawning is disabled.
        // If it is, stop this function.

        if (spawningEnabled != true)
        {
            return;
        }

        // TODO: Check whether enemyPrefab is null.
        // If it is:
        // - Print a warning if debug logs are enabled.
        // - Stop this function.
        if (enemyPrefab == null)
        {
            if(showDebugLogs == true)
            {
                Debug.Log("Warning Enemey Prefab is Null!!");
            }
            return;
        }


        // Add Time.deltaTime to spawnTimer.

        spawnTimer += Time.deltaTime;

        // : Check whether spawnTimer is greater than or equal to spawnInterval.
        // If it is:
        // - Reset spawnTimer to 0.
        // - Call SpawnEnemy.
        if(spawnTimer >= spawnInterval)
        {
            spawnTimer = 0;
            SpawnEnemy();
        }

    }

    private void PlayIdleAnimation()
    {
        // Check whether playIdleAnimationOnStart is false.
        // If it is, stop this function.
        if(playIdleAnimationOnStart == false)
        { 
            return; 
        }



        // Check whether animator is null.
        // If it is:
        // - Print a warning if debug logs are enabled.
        // - Stop this function.

        if(animator == null)
        {
            if(showDebugLogs == true)
            {
                Debug.Log("Warning Animator is Null!!");
            }
            return;
        }

        //: Check whether idleAnimationName is empty.
        // Hint: Use string.IsNullOrWhiteSpace().
        // If it is:
        // - Print a warning if debug logs are enabled.
        // - Stop this function.
        if (string.IsNullOrWhiteSpace(idleAnimationName))
        {
            if (showDebugLogs == true)
            {
                Debug.Log("Warning idleAnimationName is Empty!!");
            }
            return;
        }


        // Play the animation stored in idleAnimationName.

        animator.Play(idleAnimationName);

        // If debug logs are enabled, print the animation being played.

        if (showDebugLogs == true)
        {
            Debug.Log("Animation is being Played !! woohoo!!");
        }
    }

    private void HandleDebugInput()
    {
        //: Check whether debug keys are disabled.
        // If they are, stop this function.
        if (enableDebugKeys == false)
        {
            return;
        }


        //: Check whether Keyboard.current is null.
        // If it is, stop this function.

        if (Keyboard.current == null)
        { 
            return;
        }


        // TODO: Check whether toggleSpawnKey was pressed.
        // If it was:
        // - Toggle spawningEnabled between true and false.
        // - Print the new value if debug logs are enabled.
        if (Keyboard.current[toggleSpawnKey].wasPressedThisFrame)
        {
            spawningEnabled = !spawningEnabled;
            if (showDebugLogs == true)
            {
                Debug.Log("Spawn Key Pressed");
            }
        }

        // TODO: Check whether spawnOnceKey was pressed.
        // If it was:
        // - Call SpawnEnemy.
        // - Print a debug message if debug logs are enabled.



        // TODO: Check whether destroyEnemiesKey was pressed.
        // If it was, call DestroySpawnedEnemies.


    }

    public void StopSpawning()
    {
        // TODO: Set spawningEnabled to false.



        // TODO: If debug logs are enabled, print that spawning has stopped.


    }

    public void SpawnerDestroyed()
    {
        // TODO: Check that gameManager is not null.
        // If it exists, call RemoveSpawner.


    }

    private void SpawnEnemy()
    {
        // TODO: Check whether enemyPrefab is null.
        // If it is:
        // - Print a warning if debug logs are enabled.
        // - Stop this function.



        // Generate a random position inside the spawn radius.
        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;

        // TODO: Calculate the final spawn position using
        // this GameObject's position and randomOffset.
        Vector3 spawnPosition = new Vector3(0, 0, 0);



        // TODO: Instantiate enemyPrefab at spawnPosition.
        // Store the newly created GameObject in enemyObject.
        GameObject enemyObject = null;



        // TODO: Add enemyObject to the spawnedEnemies collection.



        // TODO: Call PlaySpawnFeedback and give it spawnPosition.



        // TODO: If debug logs are enabled, print where the enemy spawned.


    }

    public void DestroySpawnedEnemies()
    {
        // Loop through every GameObject in the spawnedEnemies collection.
        for (int i = 0; i < spawnedEnemies.Count; i++)
        {
            // TODO: Check that the enemy at position i is not null.



            // TODO: Destroy the enemy at position i.


        }

        // TODO: Clear the spawnedEnemies collection.



        // TODO: If debug logs are enabled, print that all spawned enemies were destroyed.


    }

    private void PlaySpawnFeedback(Vector3 spawnPosition)
    {
        // TODO: Check that spawnParticlePrefab is not null.
        if (spawnParticlePrefab != null)
        {
            // TODO: Instantiate spawnParticlePrefab at spawnPosition.
            // Store the newly created GameObject in particleObject.
            GameObject particleObject = null;



            // TODO: Destroy particleObject after spawnParticleLifetime seconds.


        }

        // TODO: Check that spawnSound and audioSource are not null.
        // If they exist, play spawnSound using the AudioSource.



        // TODO: If debug logs are enabled, print that the spawn feedback played.


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}