using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    public float bulletSpeed;

    Player_Heal_Controller player_Heal_Controller;

    private void Awake()
    {
        player_Heal_Controller = Object.FindObjectOfType<Player_Heal_Controller>();
    }
    private void Update()
    {
        transform.position += new Vector3(-bulletSpeed * transform.localScale.x * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player_Heal_Controller.TakeDamage();
        }
        Destroy(gameObject);
    }
}
