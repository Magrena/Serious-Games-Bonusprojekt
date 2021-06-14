using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    [SerializeField] FarmerController farmer;
    [SerializeField] int score = 30;
    [SerializeField] Text ScoreUI;


    void Start()
    {
        
        farmer.GetScore += this.Player_GetScore;
        



    }

    private void Player_GetScore(int temp)
    {
        Score += temp;
        
    }

 

    void Update()
    {
    
    }

    public int Score  
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value; 
            ScoreUI.text = this.score.ToString();     //change the score number
        }
    }

}
