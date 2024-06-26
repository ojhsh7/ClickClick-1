using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class NoteManager : MonoBehaviour

{
    public static NoteManager Instance;
   
    [SerializeField] private GameObject noteGroupPrefab;
    [SerializeField] private float noteGroupGap = 1f;
    [SerializeField]
    private KeyCode[] wholeKeyCodesArr = new KeyCode[]
    {
            KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F,
            KeyCode.G, KeyCode.H, KeyCode.J,KeyCode.K,KeyCode.L
    };
    [SerializeField] private int initNoteGroupNum = 2;
   
    private List<NoteGroup>noteGroupList = new List<NoteGroup>();
    private void Awake()
    {
        Instance = this;
    }

    public void Create()
    {
        for (int i = 0; i < initNoteGroupNum; i++)
        {
            CreateNoteGroup(wholeKeyCodesArr[i]);
        }
    }

    public void CreateNoteGroup()
    {
        if (wholeKeyCodesArr.Length == noteGroupList.Count)
            return;

        KeyCode keycode = wholeKeyCodesArr[noteGroupList.Count]; ;
        CreateNoteGroup(keycode);
    }
        

    private void CreateNoteGroup(KeyCode keyCode)
    {
        GameObject noteGroupObj = Instantiate(noteGroupPrefab);
        noteGroupObj.transform.position = Vector3.right * noteGroupList. Count * noteGroupGap;

        NoteGroup noteGroup = noteGroupObj.GetComponent<NoteGroup>(); 
        noteGroup.Create(keyCode);

        noteGroupList.Add(noteGroup);
    }
    public void OnInput(KeyCode keyCode)
    {
        int randld = Random.Range(0, 2);
        bool isApple = randld == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if (keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
                break;
            }
        }

    }
}
