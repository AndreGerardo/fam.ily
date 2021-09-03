using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatsManager : MonoBehaviour
{
    
    [Header("Stats")]
    public float financial, relationship, education, ecology;
    private float prev_financial, prev_relationship, prev_education, prev_ecology;
    public Image fin_img, rel_img, edu_img, eco_img;


    void Start()
    {
        Restart();
    }

    public void Restart()
    {
        ecology = 50f;
        education = 50f;
        financial = 50f;
        relationship = 50f;

        prev_ecology = ecology;
        prev_education = education;
        prev_financial = financial;
        prev_relationship = relationship;

        fin_img.fillAmount = financial/100f;
        rel_img.fillAmount = relationship/100f;
        edu_img.fillAmount = education/100f;
        eco_img.fillAmount = ecology/100f;
    }

    void Update()
    {

        StatsUIManager();

    }

    void StatsUIManager()
    {
        if(prev_financial != financial)
        {
            prev_financial = financial;
            fin_img.fillAmount = financial/100f;
        }

        if(prev_relationship != relationship)
        {
            prev_relationship = relationship;
            rel_img.fillAmount = relationship/100f;
        }

        if(prev_education != education)
        {
            prev_education = education;
            edu_img.fillAmount = education/100f;
        }

        if(prev_ecology != ecology)
        {
            prev_ecology = ecology;
            eco_img.fillAmount = ecology/100f;
        }
    }

}
