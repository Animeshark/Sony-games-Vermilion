using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour 
{
    public int number = 1;

    public AudioSource[] audioCollection;

    public void PlaySound(int index)
    {
        audioCollection[index].Play();
    }

    private void Start()
    {
        PlaySound(0);
    }

    private void Jump()
    {
        audioCollection[2].Play();

        //Jump stuff

        //When space bar press -> Jump
    }
}



