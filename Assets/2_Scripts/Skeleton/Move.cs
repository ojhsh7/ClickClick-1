using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            anim.CrossFade("idle", 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            anim.CrossFade("attack", 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            anim.CrossFade("death", 0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            anim.CrossFade("walk", 0, 0);
        }
      
    }
}
