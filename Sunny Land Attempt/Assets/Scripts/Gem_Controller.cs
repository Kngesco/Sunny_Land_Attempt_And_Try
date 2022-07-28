using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem_Controller : MonoBehaviour
{
    Level_Manager level_Manager;

    [SerializeField]
    bool gem, cherry;

    [SerializeField]
    GameObject collectionEffect;

    bool collection;

    UI_Controller uI_Controller;

    Player_Heal_Controller player_Heal_Controller;

    private void Awake()
    {
        level_Manager = Object.FindObjectOfType<Level_Manager>();
        uI_Controller = Object.FindObjectOfType<UI_Controller>();
        player_Heal_Controller = Object.FindObjectOfType<Player_Heal_Controller>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !collection)
        {
            if (gem)
            {
                level_Manager.collectionGem++;
                collection = true;
                Destroy(gameObject);

                uI_Controller.GemUpdateNumber();

                Instantiate(collectionEffect, transform.position, transform.rotation);
                Sound_Controller.instance.MixedSoundEffectUp(7);

            }
            if (cherry)
            {
                if (player_Heal_Controller.validHealth!=player_Heal_Controller.maxHealth)
                {
                    
                    collection = true;
                    Destroy(gameObject);
                    player_Heal_Controller.increaseHealth();
                    Instantiate(collectionEffect, transform.position, transform.rotation);
                    Sound_Controller.instance.SoundEffectUp(4);
                }
            }
            
        }
    }
}
