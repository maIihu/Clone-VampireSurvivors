using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sFXSource;


    public AudioClip background;
    public AudioClip levelUp;
    public AudioClip throwArrow;
    public AudioClip dialogue;
    
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        sFXSource.PlayOneShot(clip);
    }
}