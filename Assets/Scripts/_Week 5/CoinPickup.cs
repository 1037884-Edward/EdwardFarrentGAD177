using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CoinPickup : MonoBehaviour
{
    // Complete each section marked TODO.

    [Header("Coin Settings")]
    public int moneyAmount = 1;

    [Header("Debug")]
    public bool showDebugLogs = true;

    private void Awake()
    {
        //Get the Collider2D component from this GameObject.
        Collider2D col = GetComponent<Collider2D>();

        //Check that col is not null.
        // If it exists, set the Collider2D to be a trigger.
        if (col != null)
        {
            col.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //: Check whether the object that entered the trigger
        // has the Player tag.
        // If it does not, stop this function
        if (!other.CompareTag("Player"))
        {
            return;
        }

        //: Get the PlayerMoney component from the object
        // that entered the trigger.

        PlayerMoney money = other.gameObject.GetComponent<PlayerMoney>();

        //: If money is null, try to find the
        // PlayerMoney component in the scene.

        if (money == null)
        {
            money = FindAnyObjectByType<PlayerMoney>();
        }

        // TODO: Check that money is not null.
        // If it exists:
        // - Add moneyAmount to the player's money.
        // - Print a debug message if debug logs are enabled.

        if (money != null)
        {
            money.AddMoney(moneyAmount);
            if (showDebugLogs == true)
            {
                Debug.Log("How da fuck did this work!!!");
            }
        }




        // Remove the coin after it has been collected.
        Destroy(gameObject);
    }
}