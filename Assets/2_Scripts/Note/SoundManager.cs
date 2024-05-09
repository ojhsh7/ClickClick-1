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
        // ���⿡ �ʿ��� ���带 �ε��մϴ�.
        // ����: soundLibrary.Add("���ȹ��", Resources.Load<AudioClip>("���ȹ��Ҹ�"));
    }

    public void PlaySound(string soundName)
    {
        if (soundLibrary.ContainsKey(soundName))
        {
            audioSource.PlayOneShot(soundLibrary[soundName]);
        }
        else
        {
            Debug.LogWarning("���� ���̺귯���� " + soundName + "�� �ش��ϴ� ���尡 �����ϴ�.");
        }
    }

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }
}