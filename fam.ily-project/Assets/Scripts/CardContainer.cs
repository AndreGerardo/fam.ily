using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardContainer : MonoBehaviour
{
    private bool isFlipped = false;
    public float animTime = 0.25f;
    public LeanTweenType easeType;

    public GameObject cardFront, cardBack;

    private void Update() {
        //CheckActivecard();
    }

    public void FlipCard()
    {
        if(isFlipped == false)
        {
            LeanTween.rotateY(cardFront, -90f, animTime).setEase(easeType);

            LeanTween.rotateY(cardBack, 0f, animTime).setEase(easeType);

            isFlipped = true;
        }
        else
        {
            LeanTween.rotateY(cardFront, 0f, animTime).setEase(easeType);

            LeanTween.rotateY(cardBack, -90f, animTime).setEase(easeType);

            isFlipped = false;
        }
    }

    private void CheckActivecard()
    {
        if(isFlipped == false)
        {
            if(cardFront.GetComponent<RectTransform>().rotation.y == 90)
                cardBack.SetActive(true);
        }
        else
        {
            if(cardFront.GetComponent<RectTransform>().rotation.y == 90)
                cardBack.SetActive(false);
        }
    }
}
