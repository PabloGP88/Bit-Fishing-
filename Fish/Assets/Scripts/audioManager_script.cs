using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager_script : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip[] sounds;

    // sound 0 - pop

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(int id_sonido,float volume)
    {
        audioSource.PlayOneShot(sounds[id_sonido], volume);
    }

}
