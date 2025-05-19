using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    [Header("AudioSource")]
    public AudioSource BGM;
    public AudioSource SFX;
    public AudioSource ghostSFX;
    [SerializeField] private AudioSource ghostBGM;
    [SerializeField] private AudioSource playerAudio;

    public AudioClip BGMclip;

    public AudioClip[] playerMoveClip;
    public AudioClip[] playerHideClip;

    public AudioClip ghostNearClip;
    public AudioClip ghostChaseClip;

    public AudioClip ghostSkillClip;
    public AudioClip ghostDeathClip;

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
        PlayBGM(BGMclip);
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
