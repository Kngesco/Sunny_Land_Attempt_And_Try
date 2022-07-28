using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Finish_Controller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Level_Manager.instance.ScreenFinish();
        }
    }
}
