using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    [Header("AudioSource")]
    public AudioSource BGM;
    public AudioSource SFX;
    public AudioSource ghostSFX;
    [SerializeField] private AudioSource ghostBGM;
    [SerializeField] private AudioSource playerAudio;

    [Header("AudioMixer")]
    [SerializeField] private AudioMixer BGM_Mixer;
    [SerializeField] private AudioMixer SFX_Mixer;

    [Header("Slider")]
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SFXSlider;

    [Header("Clip")]
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

        BGMSlider.onValueChanged.AddListener(SetBGMVolume);
        SFXSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void Start()
    {
        PlayBGM(BGMclip);

        BGMSlider.value = 0.5f;
        SFXSlider.value = 0.5f;
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
    public void SetBGMVolume(float volume)
    {
        BGM_Mixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        SFX_Mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}
