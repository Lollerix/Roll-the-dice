using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageAnimation : MonoBehaviour
{

    public Sprite[] sprites;
    public int spritePerFrame = 6;
    public bool loop = true;
    public bool destroyOnEnd = false;

    private int index = 0;
    private Image image;
    private int frame = 0;
    private bool play = false;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (play)
        {
            if (!loop && index == sprites.Length) return;
            frame++;
            if (frame < spritePerFrame) return;
            image.sprite = sprites[index];
            frame = 0;
            index++;
            if (index >= sprites.Length)
            {
                if (loop) index = 0;
                if (destroyOnEnd) Destroy(gameObject);
            }

        }
    }

    public void Restart()
    {
        index = 0;
        loop = true;
        play = true;
    }

    public void Stop()
    {
        loop = false;
        play = false;
    }
}