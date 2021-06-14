using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFood : MonoBehaviour
{
    [SerializeField] Food throwedFood;
    [SerializeField] int food = 0;
    [SerializeField] Text FoodUI;

    // Start is called before the first frame update
    void Start()
    {
        throwedFood.GetNumber += this.Player_GetNumber;
    }

    private void Player_GetNumber(int temp)//
    {
        Food += temp;

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public int Food
    {
        get
        {
            return this.food;
        }
        set
        {
            this.food = value;
            FoodUI.text = this.food.ToString();     
        }
    }

}
