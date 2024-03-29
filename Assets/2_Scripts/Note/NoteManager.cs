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
        if (keyCode == KeyCode.A)
        {
            noteGroupArr[0].OnIntput(true);
        }

        if (keyCode == KeyCode.S)
        {
            noteGroupArr[1].OnIntput(true);
        }
    }
}
