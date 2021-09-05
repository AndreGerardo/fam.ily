using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CardContainer : MonoBehaviour
{
    [SerializeField]
    private GameStatsManager GM;
    private bool isFlipped = false;
    public float animTime = 0.25f;
    public LeanTweenType easeType;

    public GameObject cardFront, cardBack, cardEpilogue, cardEnd;
    public AudioSource flipSound;

    [Header("Cards")]
    public CardChoice firstCard;
    public CardChoice currentCard;
    public TMP_Text questionText, epilogueText;
    public TMP_Text[] answerText;


    void Start()
    {
        currentCard = firstCard;

        flipSound = GetComponent<AudioSource>();

        questionText.text = currentCard.questionText;
        for(int i = 0; i < answerText.Length; i++)
        {
            answerText[i].text = currentCard.choices[i].answerText;
        }
    }

    public void FlipCardButton()
    {
        if(isFlipped == false)
        {
            flipSound.Play();
            StartCoroutine(RotateFront());
        }
        else
        {
            flipSound.Play();
            StartCoroutine(RotateBack());
        }
    }

    public void AnswerButton(int ansIndex)
    {
        if(currentCard.choices[ansIndex].epilogueText == "")
        {
            epilogueText.text = currentCard.choices[ansIndex].answerText;
        }else
        {
            epilogueText.text = currentCard.choices[ansIndex].epilogueText;
        }

        GM.financial += currentCard.choices[ansIndex].fin;
        GM.relationship += currentCard.choices[ansIndex].rel;
        GM.education += currentCard.choices[ansIndex].edu;
        GM.ecology += currentCard.choices[ansIndex].eco;

        flipSound.Play();
        StartCoroutine(RotateEpilogue());

        currentCard = currentCard.choices[ansIndex].nextChoice;
    }

    public void EpilogueButton()
    {
        if(currentCard.isEndCard == true || GM.financial <= 0f || GM.relationship <= 0f || GM.education <= 0f || GM.ecology <= 0f)
        {
            flipSound.Play();
            StartCoroutine(RotateEnd());
        }else
        {
            questionText.text = currentCard.questionText;
            for(int i = 0; i < answerText.Length; i++)
            {
                answerText[i].text = currentCard.choices[i].answerText;
            }

            flipSound.Play();
            StartCoroutine(RotateEpilogueQuestion());
        }
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartButton()
    {
        GM.Restart();
        currentCard = firstCard;

        questionText.text = currentCard.questionText;
        for(int i = 0; i < answerText.Length; i++)
        {
            answerText[i].text = currentCard.choices[i].answerText;
        }

        flipSound.Play();
        StartCoroutine(RotateEndQuestion());

    }

    IEnumerator RotateFront()
    {
        LeanTween.rotateY(cardFront, 90f, animTime).setEase(easeType);
        isFlipped = true;
        yield return new WaitForSeconds(animTime);
        LeanTween.rotateY(cardBack, 0f, animTime).setEase(easeType);
    }

    IEnumerator RotateBack()
    {
        LeanTween.rotateY(cardBack, 90f, animTime).setEase(easeType);
        isFlipped = false;
        yield return new WaitForSeconds(animTime);
        LeanTween.rotateY(cardFront, 0f, animTime).setEase(easeType);
    }

    IEnumerator RotateEpilogue()
    {
        LeanTween.rotateY(cardBack, 90f, animTime).setEase(easeType);
        isFlipped = false;
        yield return new WaitForSeconds(animTime);
        LeanTween.rotateY(cardEpilogue, 0f, animTime).setEase(easeType);
    }

    IEnumerator RotateEpilogueQuestion()
    {
        LeanTween.rotateY(cardEpilogue, 90f, animTime).setEase(easeType);
        yield return new WaitForSeconds(animTime);
        LeanTween.rotateY(cardFront, 0f, animTime).setEase(easeType);
    }

    IEnumerator RotateEnd()
    {
        LeanTween.rotateY(cardEpilogue, 90f, animTime).setEase(easeType);
        yield return new WaitForSeconds(animTime);
        LeanTween.rotateY(cardEnd, 0f, animTime).setEase(easeType);
    }

    IEnumerator RotateEndQuestion()
    {
        LeanTween.rotateY(cardEnd, 90f, animTime).setEase(easeType);
        yield return new WaitForSeconds(animTime);
        LeanTween.rotateY(cardFront, 0f, animTime).setEase(easeType);
    }

}
