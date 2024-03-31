using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource music1;
    public AudioSource music2;
    public AudioSource music3;
    private int _number;

    private void Start()
    {
        RandomMusic();
    }
    private void Update()
    {
        if(music1.isPlaying == false && music2.isPlaying == false && music3.isPlaying == false)
        {
            RandomMusic();
        }
    }

    void RandomMusic()
    {
        _number = Random.Range(0, 2);
        switch (_number)
        {
            case 0:
                music1.Play();
                break;
            case 1:
                music2.Play();
                break;
            case 2:
                music3.Play();
                break;
        }
    }
}
