using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject noteSpawn;
    [SerializeField] private float noteGap = 6f;

    [SerializeField] private SpriteRenderer btnSpriteRenderer;
    [SerializeField] private Sprite normalBtnSprite;
    [SerializeField] private Sprite selectBtnSprite;
    [SerializeField] private TextMeshPro keyCodeTmp;
    [SerializeField] private Animation anim;
    private KeyCode keyCode;

    public KeyCode KeyCode
    {
        get
        {
            return keyCode;
        }
    }

    private List<Note> noteList = new List<Note>();

    public void Create(KeyCode keyCode)
    {
        this.keyCode = keyCode;
        keyCodeTmp.text = keyCode.ToString();
        
        for (int i = 0; i < noteMaxNum; i++)
        {
            CreateNote(true);
        }
        InputManager.Instance.AddKeyCode(keyCode);
    }

    private void CreateNote(bool isApple)
    {
        GameObject noteGameObj = Instantiate(notePrefab);
        noteGameObj.transform.SetParent(noteSpawn.transform);


        noteGameObj.transform.localPosition = Vector3.up * noteList.Count * noteGap;
        Debug.Log("noteGameObj.transform.position ;  " + noteGameObj.transform.position);
        Note note = noteGameObj.GetComponent<Note>();
        note.SetSprite(isApple);

        noteList.Add(note);
    }

    public void OnInput(bool isApple)
    {
        Debug.Log("NoteGroup : " + isApple);
        //��Ʈ ����
        if (noteList.Count > 0)
        {
            Note delNote = noteList[0];
            delNote.DeleteNote();
            noteList.RemoveAt(0);
        }
      
        //�� ��������
        for (int i = 0; i < noteList.Count; i++)
            noteList[i].transform.localPosition = Vector3.up * i * noteGap;

        //����
        CreateNote(isApple);

        //��Ʈ �ִϸ��̼�
        anim.Play();
        btnSpriteRenderer.sprite = selectBtnSprite;
    }

    public void callAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }

}
