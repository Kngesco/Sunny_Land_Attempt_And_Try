using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Heal_Controller : MonoBehaviour
{
    public int  maxHealth, validHealth;


    UI_Controller ui_Controller;

    public float invincibilityTime;
    float invincibilityCounter;

    SpriteRenderer sR;

    Player_Controller player_Controller;

    [SerializeField]
    GameObject extinctionEffect;

    private void Awake()
    {
        player_Controller = Object.FindObjectOfType<Player_Controller>();
        ui_Controller = Object.FindObjectOfType<UI_Controller>();
        sR = GetComponent<SpriteRenderer>();
    }




    private void Start()
    {
        validHealth = maxHealth;
    }
    private void Update()
    {
        invincibilityCounter -= Time.deltaTime;
        if (invincibilityCounter <= 0)
        {
            sR.color = new Color(sR.color.r, sR.color.g, sR.color.b, 1f);
        }
    }
    public void TakeDamage()
    {
        if (invincibilityCounter <= 0)
        {
            validHealth--;
            if (validHealth <= 0)
            {
                validHealth = 0;
                gameObject.SetActive(false);

                Instantiate(extinctionEffect, transform.position, transform.rotation);
                Sound_Controller.instance.SoundEffectUp(2);


            }
            else
            {
                invincibilityCounter = invincibilityTime;
                sR.color = new Color(sR.color.r,sR.color.g,sR.color.b,0.5f);

                player_Controller.RecoilFunction();
                Sound_Controller.instance.SoundEffectUp(1);

            }

            ui_Controller.HealthSituation();
            
        }
        
            
    }
    public void increaseHealth()
    {
        validHealth++;
        if (validHealth>=maxHealth)
        {
            validHealth = maxHealth;
        }
        ui_Controller.HealthSituation();
    }
}
