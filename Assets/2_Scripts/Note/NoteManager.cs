using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class NoteManager : MonoBehaviour

{
    public static NoteManager Instance;
    [SerializeField] private KeyCode[] initKeyCodeArr;
    [SerializeField] private GameObject noteGroupPrefab;
    [SerializeField] private float noteGroupGap = 1f;
    private List<NoteGroup>noteGroupList = new List<NoteGroup>();
    private void Awake()
    {
        Instance = this;
    }

    public void Create()
    {
        foreach(KeyCode keyCode in initKeyCodeArr)
        {
            CreateNoteGroup(keyCode);
        }
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
        int randld = Random.Range(0,noteGroupList.Count);
        bool isApple = randld == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if (keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
            }
        }

       
        
    }
}
