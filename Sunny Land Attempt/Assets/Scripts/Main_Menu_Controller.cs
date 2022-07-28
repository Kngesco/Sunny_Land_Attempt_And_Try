using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class Main_Menu_Controller : MonoBehaviour
{
    public string SceneName;

    public GameObject imageObje;
    public GameObject startBtn, exitBtn;

    public GameObject fadeScreen;

    private void Start()
    {
        StartCoroutine(OpenRoutine());
    }

    IEnumerator OpenRoutine()
    {
        yield return new WaitForSeconds(.1f);

        imageObje.GetComponent<CanvasGroup>().DOFade(1, 0.5f);

        yield return new WaitForSeconds(.4f);

        startBtn.GetComponent<CanvasGroup>().DOFade(1, .5f);
        startBtn.GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);

        yield return new WaitForSeconds(.4f);

        exitBtn.GetComponent<CanvasGroup>().DOFade(1, .5f);
        exitBtn.GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);
    }
    public void StartGame()
    {
        StartCoroutine(OpenGameRoutine());
    }

    public void GameExit()
    {
        Application.Quit();
    }

    IEnumerator OpenGameRoutine()
    {
        yield return new WaitForSeconds(.1f);
        fadeScreen.GetComponent<CanvasGroup>().DOFade(1, 1f);

        yield return new WaitForSeconds(1f);

        

        SceneManager.LoadScene(SceneName);
    }
}
