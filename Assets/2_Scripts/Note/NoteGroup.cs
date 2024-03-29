using System.Collections.Generic;
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
    [SerializeField] private Animation anim;

    private List<Note> noteList = new List<Note>();
    internal void OnInput(bool v)
    {
        anim.Play();
        btnSpriteRenderer.sprite = selectBtnSprite;
    }
    void Start()
    {
        for (int i = 0; i < noteMaxNum; i++)
        {
            GameObject noteGameObj = Instantiate(notePrefab);
            noteGameObj.transform.SetParent(noteSpawn.transform);


            noteGameObj.transform.localPosition = Vector3.up * noteList.Count * noteGap;
            Debug.Log("noteGameObj.transform.position ;  " + noteGameObj.transform.position);
            Note note = noteGameObj.GetComponent<Note>();

            noteList.Add(note);
        }
    }

    public void OnIntput(bool isSelect)
    {
        anim.Play();
        btnSpriteRenderer.sprite = selectBtnSprite;
    }

    public void callAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }

}
