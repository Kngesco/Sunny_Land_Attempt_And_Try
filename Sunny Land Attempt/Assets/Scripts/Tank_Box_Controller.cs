using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Box_Controller : MonoBehaviour
{

    Player_Controller player_Controller;
    Tank_Controller tank_Controller;

    private void Awake()
    {
        player_Controller = Object.FindObjectOfType<Player_Controller>();
        tank_Controller = Object.FindObjectOfType<Tank_Controller>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && player_Controller.transform.position.y > transform.position.y)
        {
            player_Controller.JumpFNC();

            tank_Controller.CoupFNC();
            gameObject.SetActive(false);
        }  
    }
}
