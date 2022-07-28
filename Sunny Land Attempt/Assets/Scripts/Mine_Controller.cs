using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine_Controller : MonoBehaviour
{
    public GameObject destroyMine;

    Player_Heal_Controller player_Heal_Controller;

        private void Awake()
    {
        player_Heal_Controller = Object.FindObjectOfType<Player_Heal_Controller>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyFNC();

            player_Heal_Controller.TakeDamage();
        }
    }

    public void DestroyFNC()
    {
        Destroy(this.gameObject);

        Instantiate(destroyMine, transform.position, transform.rotation);
    }
}
