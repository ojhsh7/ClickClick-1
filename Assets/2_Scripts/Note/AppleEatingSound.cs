using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            SoundManager.Instance.PlaySound("���ȹ��");
            Destroy(other.gameObject);
        }
    }
}