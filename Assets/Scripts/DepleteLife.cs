using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepleteLife : MonoBehaviour
{
    public Image fill;
    float totalX;
    float totalWidth;
    int incrementSize = 1;
    
    // Start is called before the first frame update
    void Start()
    {
       totalX = GameStateUpdate.Instance.remainingSeconds; 
       totalWidth = fill.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
       float ratio = GameStateUpdate.Instance.remainingSeconds / totalX;
       float widthRemaining = ratio * totalWidth;
    //    Debug.Log("rectangle width " + fill.rectTransform.rect + "total remaining " + ratio);
       fill.rectTransform.sizeDelta = new Vector2(widthRemaining, fill.rectTransform.rect.height); 
    }
}
