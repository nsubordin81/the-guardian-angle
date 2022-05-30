using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateUpdate : MonoBehaviour
{
    // Singleton pattern, oh well this is a game jam, will do events later
    public static GameStateUpdate Instance {get; private set;}
    public GameObject purpose;

    public int remainingSeconds = 0;
    public int score = 0;
    public int pickupsCollected = 0;
    public float experienceRequired = 40;
    AudioSource audioSource;

    bool gameOver = false;
    bool createdPurpose = false;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayDelayed(2);
        StartCoroutine(countdown());
    }

    void Update() 
    {
        if(!createdPurpose && pickupsCollected >= experienceRequired)
        {
            Instantiate(purpose, new Vector3(0.4f, 2.5f, 0.0f), Quaternion.identity);
            createdPurpose = true;
        }
    }

    IEnumerator countdown()
    {
        while(remainingSeconds > 0)
        {
            yield return new WaitForSeconds(1);
            remainingSeconds -= 1;
        }
        SceneManager.LoadScene("Game Over");
    }

}
