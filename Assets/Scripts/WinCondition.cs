using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wanderer")
        {
            GameStateUpdate.Instance.score += 200;
            SceneManager.LoadScene("Win Screen");
            // Debug.Log("You Did It! One Extra Life, Coming Up");
            Destroy(gameObject);
        }
    }

}
