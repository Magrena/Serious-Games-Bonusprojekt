using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] float wait_time = 0.5f;
    [SerializeField] Foodpool food_pool;
    [SerializeField] float speed = 5.5f;
    //[SerializeField] FarmerController farmer;

    Rigidbody r_body;

    public delegate void ThrowedFood(int temp);  // for food
    public ThrowedFood GetNumber;

    Camera follow_camera;
    float counter = 0f;      



    void Start()
    {
        this.r_body = GetComponent<Rigidbody>();
        this.follow_camera = Camera.main;
    }

    void Update()
    {
        this.counter += Time.deltaTime;
    }

    public void food_throw(Transform food)
    {
        if ((!Input.GetMouseButtonUp(0))|| this.counter < this.wait_time) return;  //do nothing if not click mous or in the wait time
        if (GetNumber != null)     //check wether the event is null
        {
            GetNumber(1);  //when farmer throw a food,
        }

        Vector3 mous_Position = Input.mousePosition;

        float angle = food.localRotation.eulerAngles.y;
        if (-45.0f <= angle && angle <= 45.0f)
            mous_Position.z = 15 + food.position.z;
        if (135.0f <= angle && angle <= -135.0f)
            mous_Position.z = 5 + food.position.z;
        else mous_Position.z = 10 + food.position.z;

        Vector3 throw_direction = this.follow_camera.ScreenToWorldPoint(mous_Position) - food.position;
        this.food_pool.getFood(food.position, throw_direction);
        this.counter = 0f;
        //this.farmer.animator.SetBool("Throw", true);
 
    }


    

}
