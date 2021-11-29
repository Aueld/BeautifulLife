using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSourceCurveType))]
public class SoundManager : MonoBehaviour
{
    public AudioClip inGameBGM1;
    public AudioClip inGameBGM2;
    public AudioClip inGameBGM3;

    public AudioSource BGM;
    
    private void OnEnable()
    { 
        if(SceneManager.GetActiveScene().name == "Main")
        {
            InGameBGM();
        }
    }

    public void InGameBGM()
    {
        int rand = Random.Range(0, 3);

        if (rand == 1)
            InitSound(inGameBGM1);
        else if (rand == 2)
            InitSound(inGameBGM2);
        else
            InitSound(inGameBGM3);
    }

    private void InitSound(AudioClip clip)
    {
        BGM = GetComponent<AudioSource>();

        BGM.clip = clip;
        BGM.loop = true;
        BGM.Play();
    }
}
