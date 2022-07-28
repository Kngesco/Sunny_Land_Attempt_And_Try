using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Controller : MonoBehaviour
{

    [SerializeField]
    GameObject destroyEffect;

    Player_Controller player_Controller;

    public float cherryChance;
    public GameObject cherryObje;

    private void Awake()
    {
        player_Controller = Object.FindObjectOfType<Player_Controller>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("frog"))
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(destroyEffect, transform.position, transform.rotation);

            player_Controller.JumpFNC();

            float exitStatus = Random.Range(0f, 100f);

            Sound_Controller.instance.SoundEffectUp(0);

            if (exitStatus <= cherryChance)
            {
                Instantiate(cherryObje, other.transform.position, other.transform.rotation);
            }
        }
    }
}
