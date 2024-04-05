using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private List<KeyCode> keyCodeList = new List<KeyCode>();


    private void Awake()
    {
        Instance = this;
    }
    public void AddKeyCode(KeyCode keyCode)
    {
        this.keyCodeList.Add(keyCode);
    }



    private void Update()
    {
        foreach (KeyCode keyCode in this.keyCodeList)
        {
            if (Input.GetKeyDown(keyCode) == true)
            {
                NoteManager.Instance.OnInput(keyCode);
            }
        }
    } 
}





