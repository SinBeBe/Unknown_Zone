using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    public AudioSource audioSource;

    public AudioClip[] playerMoveClip;
    public AudioClip[] playerHideClip;

    public AudioClip[] clips;

    public int clipsIndex;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayAudiocilp(AudioSource source, AudioClip clip, bool isLoop)
    {
        source.Stop();
        source.clip = clip;
        source.loop = isLoop;
        source.Play();
    }

    public void PlayBGM(AudioClip clip, float time)
    {
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
