using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/New Card")]
public class CardChoice : ScriptableObject
{
    [TextArea]
    public string questionText;
    public List<Choice> choices;
    public bool isEndCard = false;
}
