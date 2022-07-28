using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    public static Level_Manager instance;

    Player_Controller player_Controller;

    UI_Controller ui_Controller;

    public string screenName;


    private void Awake()
    {
        instance = this;
        player_Controller = Object.FindObjectOfType<Player_Controller>();
        ui_Controller = Object.FindObjectOfType<UI_Controller>();
    }

    public int collectionGem;

   public void ScreenFinish()
    {
        StartCoroutine(FinishScreenRoutine());
    }

    IEnumerator FinishScreenRoutine()
    {
        yield return new WaitForSeconds(.1f);
        player_Controller.moveYesOrNo = false;

        yield return new WaitForSeconds(1f);
        ui_Controller.FadeScreenOpen();

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(screenName);
    }
}
