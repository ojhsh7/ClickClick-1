using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;
    [SerializeField] private NoteGroup[] noteGroupArr;
    private void Awake()
    {
        Instance = this;
    }
    public void OnInput(KeyCode keyCode)
    {
        int randld = Random.Range(0, noteGroupArr.Length);
        bool isApple = randld == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupArr)
        {
            if (keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
            }
        }

       
        
    }
}
