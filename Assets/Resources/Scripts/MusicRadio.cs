using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRadio : MonoBehaviour
{
    private AudioSource radioPlayer;
    public AudioClip[] compilation;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        i = Random.Range(0, compilation.Length);
        radioPlayer = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            radioPlayer.Stop();
        if (!radioPlayer.isPlaying)
        {
            radioPlayer.clip = compilation[i];
            i = (i + 1) % compilation.Length;
            radioPlayer.Play();
        }
    }
}
