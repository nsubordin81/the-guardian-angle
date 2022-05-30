using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO parameterize this and DepleteLife to create general purpose ProgressBar script
public class AddPurpose : MonoBehaviour
{
    public Image fill;
    float maxPurpose;
    float totalWidth;
    int incrementSize = 1;
    
    // Start is called before the first frame update
    void Start()
    {
       maxPurpose = GameStateUpdate.Instance.experienceRequired; 
       totalWidth = fill.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
       float ratio = GameStateUpdate.Instance.pickupsCollected / maxPurpose;
       float widthRemaining = ratio * totalWidth;
    //    Debug.Log("rectangle width " + fill.rectTransform.rect + "total remaining " + ratio);
       if(ratio <= 1)
       {
        fill.rectTransform.sizeDelta = new Vector2(widthRemaining, fill.rectTransform.rect.height); 
       }
    }
}