using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foodpool : MonoBehaviour
{
    [SerializeField] Food_instance food_prefab;


    List<Food_instance> foods;

    void Start()
    {
        this.foods = new List<Food_instance>();
    }

    public Food_instance getFood(Vector3 position, Vector3 direction)
    {
        Food_instance food;

        
        if (this.foods.Count > 0)
        {
            food = this.foods[0];
            this.foods.Remove(food);
        }
        else
        {
            food = Instantiate(this.food_prefab, position, Quaternion.identity);   //Quaternion.identity ---> (0,0,0,0)
            food.transform.SetParent(this.transform);
        }
        food.Init(this, position, direction);
        food.gameObject.SetActive(true);
        return food;
    }

    public void addFood(Food_instance food)
    {
        
        food.gameObject.SetActive(false);
        this.foods.Add(food);

    }
}
