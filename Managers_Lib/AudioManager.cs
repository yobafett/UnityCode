using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource clickSound;
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void PlayClickSound() => clickSound.Play();
    

    public void SetSoundsVolume(float var)
    {
        clickSound.volume = var;
    }
    
    public void SetMusicVolume(float var) => backgroundMusic.volume = var;
    
    public bool SwitchMusic()
    {
        if (backgroundMusic.volume > 0)
        {
            SetMusicVolume(0);
            return false;
        }
        SetMusicVolume(1);
        return true;
    }
    
    public bool SwitchSounds()
    {
        if (clickSound.volume > 0)
        {
            SetSoundsVolume(0);
            return false;
        }
        SetSoundsVolume(1);
        return true;
    }
}