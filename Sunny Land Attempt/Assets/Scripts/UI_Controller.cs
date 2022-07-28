using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UI_Controller : MonoBehaviour
{
    [SerializeField]
    Image heart1_Img, heart2_Img, heart3_Img;

    [SerializeField]
    Sprite fullHeart, emptyHeart, halfHeart;

    Player_Heal_Controller player_Heal_Controller;

    [SerializeField]
    TMP_Text gemTxt;

    Level_Manager level_Manager;

    public GameObject fadeScreen;

    private void Awake()
    {
        player_Heal_Controller = Object.FindObjectOfType<Player_Heal_Controller>();
        level_Manager = Object.FindObjectOfType<Level_Manager>();
    }

    public void HealthSituation()
    {
        switch(player_Heal_Controller.validHealth)
        {
            case 6:
                heart1_Img.sprite = fullHeart;
                heart2_Img.sprite = fullHeart;
                heart3_Img.sprite = fullHeart;
                break;

            case 5:
                heart1_Img.sprite = fullHeart;
                heart2_Img.sprite = fullHeart;
                heart3_Img.sprite = halfHeart;
                break;

            case 4:
                heart1_Img.sprite = fullHeart;
                heart2_Img.sprite = fullHeart;
                heart3_Img.sprite = emptyHeart;
                break;
            case 3:
                heart1_Img.sprite = fullHeart;
                heart2_Img.sprite = halfHeart;
                heart3_Img.sprite = emptyHeart;
                break;

            case 2:
                heart1_Img.sprite = fullHeart;
                heart2_Img.sprite = emptyHeart;
                heart3_Img.sprite = emptyHeart;
                break;

            case 1:
                heart1_Img.sprite = halfHeart;
                heart2_Img.sprite = emptyHeart;
                heart3_Img.sprite = emptyHeart;
                break;

            case 0:
                heart1_Img.sprite = emptyHeart;
                heart2_Img.sprite = emptyHeart;
                heart3_Img.sprite = emptyHeart;

                

                break;



        }
    }

    public void GemUpdateNumber()
    {
        gemTxt.text = level_Manager.collectionGem.ToString();
    }

    public void FadeScreenOpen()
    {
        fadeScreen.GetComponent<CanvasGroup>().DOFade(1, .4f);
    }

    
}
