using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Controller : MonoBehaviour
{
    Player_Heal_Controller player_Heal_Controller;
    private void Awake()
    {
        player_Heal_Controller = Object.FindObjectOfType<Player_Heal_Controller>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            player_Heal_Controller.TakeDamage();
        } 
    }
}
