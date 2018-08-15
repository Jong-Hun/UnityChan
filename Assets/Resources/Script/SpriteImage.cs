using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteImage : MonoBehaviour {
    
    public Sprite[] images = null;
    public bool isLoop = true;
    public float speed = 0.0f;

    private int curImageCount = 0;
    private bool isPlay = false;

    // Use this for initialization
    void Start () {
        if (!isPlay)
            Play();
    }

    public void Play()
    {
        StartCoroutine(ChangeImage());
    }

    IEnumerator ChangeImage()
    {
        float timer = 0.0f;
        int maxImageCount = images.Length;
        int imageCount = 0;
        isPlay = true;

        if (speed == 0)
            yield break;

        while (true)
        {
            yield return null;

            timer += Time.deltaTime;

            if (timer > speed)
            {
                timer = 0.0f;
                this.gameObject.GetComponent<Image>().sprite = images[imageCount];

                if (imageCount < maxImageCount - 1)
                    imageCount++;
                else
                {
                    if (!isLoop)
                        yield break;

                    imageCount = 0;
                }
            }

            curImageCount = imageCount;
        }
        
        yield return null;
    }

    public void AddImages(string folderPath)
    {
        images = Resources.LoadAll<Sprite>(folderPath);
    }

    public void AddImage(string folderPath, string imageName)
    {
        Sprite image = Resources.Load<Sprite>(folderPath + "/" + imageName);
        images[images.Length] = image;
    }

    public bool IsStop()
    {
        int maxImageCount = images.Length;
        
        if(isLoop == false)
        {
            if (curImageCount == maxImageCount - 1)
                return true;
        }

        return false;
    }

    public float GetTotalPlayTime()
    {
        int maxImageCount = images.Length;

        return speed * (maxImageCount);
    }
}
