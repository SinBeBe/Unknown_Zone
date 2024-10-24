using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    public AudioSource audioSource;
    public AudioClip[] clips;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        StartCoroutine(PlayBGM(clips[0], clips[0].length));
    }

    public void PlayAudiocilp(ref AudioSource source, AudioClip clip, bool isLoop)
    {
        source.clip = clip;
        source.loop = isLoop;
        source.Play();
    }

    IEnumerator PlayBGM(AudioClip clip, float time)
    {
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
        yield return new WaitForSeconds(time);
    }
}
