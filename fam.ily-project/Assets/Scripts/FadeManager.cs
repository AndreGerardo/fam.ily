using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public CardContainer CardContainer;
    public GameObject MainMenuParent, GameParent;
    public Animator fadeAnim;

    public void GoToHome()
    {
        StartCoroutine(TransitionHome());
    }

    public void GoToGame()
    {
        StartCoroutine(TransitionGame());
    }

    IEnumerator TransitionHome()
    {
        fadeAnim.SetTrigger("fade_in");
        yield return new WaitForSecondsRealtime(1f);
        CardContainer.HomeButton();
    }

    IEnumerator TransitionGame()
    {
        fadeAnim.SetTrigger("fade_in");
        yield return new WaitForSecondsRealtime(1f);
        MainMenuParent.SetActive(false);
        GameParent.SetActive(true);
        CardContainer.RestartButton();
    }

}
