using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteImage : MonoBehaviour {
    
    public Sprite[] images = null;
    public bool isLoop = true;
    public int speed = 0;


    // Use this for initialization
    void Start () {
        StartCoroutine(ChangeImage());
    }

    IEnumerator ChangeImage()
    {
        int count = 0;
        int maxImageCount = images.Length;
        int imageCount = 0;

        while (isLoop)
        {
            yield return null;

            count++;
            
            if (count >= 100 / speed)
            {
                count = 0;
                this.gameObject.GetComponent<Image>().sprite = images[imageCount];

                if (imageCount < maxImageCount - 1)
                    imageCount++;
                else
                    imageCount = 0;
            }
        }
        
        yield return null;
    }


}
