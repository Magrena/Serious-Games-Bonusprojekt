using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_instance : MonoBehaviour
{

    [SerializeField] float speed = 15.0f;
    [SerializeField] float time = 5f;
    [SerializeField] float force = 25f;
   

    Foodpool food_pool;
    Vector3 direction;
    Rigidbody food_rigidbody;
    float time_counter = 0f;

    public virtual Food_instance Init(Foodpool pool, Vector3 position, Vector3 direction)
    {
        this.food_pool = pool; 
        this.transform.position = position; 

        this.direction = direction;
        this.direction = this.direction.normalized;  //we normalize AFTER setting z to 0, otherwise we dont have vectors of size 1 anymore

        //this.Rotate();
        return this;
    }

    
    void Awake()
    {
        this.food_rigidbody = GetComponent<Rigidbody>();
        //this.farmer = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        this.time_counter += Time.deltaTime;      
        if (time_counter >= this.time) this.BackToPool();
    }

    void FixedUpdate()
    {
        this.Move();
        //this.Rotate();
    }

    private void OnCollisionEnter(Collision other)
    {
        Animal animal = other.gameObject.GetComponent<Animal>();
        if (!animal) return;
        //Debug.Log("tag is: " + animal.tag);
        if (animal.tag == this.tag)
        {
            animal.collision();
            Debug.Log("hit target!");
        }
        this.BackToPool();
        Debug.Log("hit");
        
    }

    void Move()
    {
        //farmer.animtor.SetTrigger("Throw_trigger");
        this.food_rigidbody.AddForce(transform.forward * force, ForceMode.Force);
        this.food_rigidbody.MovePosition(this.food_rigidbody.position + (this.direction * Time.fixedDeltaTime * this.speed));
        
        
    }

    //void Rotate()
    //{
    //    Vector3 final_position = this.food_rigidbody.position + this.direction;
    //    Quaternion rotation = Quaternion.LookRotation(final_position);
    
    //}


    //reset the counter and put the food back to pool
    void BackToPool()
    {
        this.time_counter = 0f;
        this.food_pool.addFood(this);
    }


}
