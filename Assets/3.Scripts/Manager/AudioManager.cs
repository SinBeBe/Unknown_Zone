using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    public AudioSource BGM;
    public AudioSource SFX;

    public AudioClip[] BGMclip;

    public AudioClip[] playerMoveClip;
    public AudioClip[] playerHideClip;

    public AudioClip[] clips;

    public AudioClip soulClip;

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

    private void Start()
    {
        PlayBGM(BGMclip[SceneManager.sceneCount]);
    }

    public void PlayAudiocilp(AudioSource source, AudioClip clip, bool isLoop)
    {
        source.Stop();
        source.clip = clip;
        source.loop = isLoop;
        source.Play();
    }

    public void PlayBGM(AudioClip clip)
    {
        BGM.clip = clip;
        BGM.loop = true;
        BGM.Play();
    }
}
