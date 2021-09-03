using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Choice
{
    [TextArea]
    public string answerText;
    public float fin,rel,edu,eco;
    public string epilogueText;
    public CardChoice nextChoice;

    public Choice(string answerText, float fin, float rel, float edu, float eco, string epilogueText,CardChoice nextChoice)
    {
        this.answerText = answerText;
        this.fin = fin;
        this.rel = rel;
        this.edu = edu;
        this.eco = eco;
        this.epilogueText = epilogueText;
        this.nextChoice = nextChoice;
    }
}
