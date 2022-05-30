using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLogic : MonoBehaviour
{
    public int value = 10;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Wanderer")
        {
            GameStateUpdate.Instance.score += value;
            GameStateUpdate.Instance.pickupsCollected += 1;
            // Debug.Log("score is now: " + GameStateUpdate.Instance.score);
            Destroy(gameObject);
        }
    }
}
