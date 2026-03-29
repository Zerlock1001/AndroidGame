using UnityEngine;

public class Music: MonoBehaviour
{
    public AudioClip bgm;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = bgm;
        audioSource.loop = true;
        audioSource.playOnAwake = false;

        audioSource.Play();
    }
}
