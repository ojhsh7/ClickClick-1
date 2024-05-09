using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager: MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                if (instance == null)
                {
                    GameObject soundManagerObject = new GameObject("SoundManager");
                    instance = soundManagerObject.AddComponent<SoundManager>();
                }
            }
            return instance;
        }
    }

    private Dictionary<string, AudioClip> soundLibrary;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSoundLibrary();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeSoundLibrary()
    {
        soundLibrary = new Dictionary<string, AudioClip>();
        // 여기에 필요한 사운드를 로드합니다.
        // 예시: soundLibrary.Add("사과획득", Resources.Load<AudioClip>("사과획득소리"));
    }

    public void PlaySound(string soundName)
    {
        if (soundLibrary.ContainsKey(soundName))
        {
            audioSource.PlayOneShot(soundLibrary[soundName]);
        }
        else
        {
            Debug.LogWarning("사운드 라이브러리에 " + soundName + "에 해당하는 사운드가 없습니다.");
        }
    }

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }
}