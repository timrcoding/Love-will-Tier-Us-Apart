using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource AudioS;
    
    void Start()
    {
        instance = this;
        AudioS = GetComponent<AudioSource>();
    }

    public void playClip(string clip)
    {
        //LOADS CLIP AS DEFINED BY STRING FROM RESOURCES
        AudioClip clipPlayed = Resources.Load("Sounds/" + clip.ToString()) as AudioClip;
        //PLAYS CLIP
        AudioS.PlayOneShot(clipPlayed);
        Debug.Log("CLIP PLAYED");
    }
}
