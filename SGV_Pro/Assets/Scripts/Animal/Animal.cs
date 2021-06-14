using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    

    Animalpool animal_pool;
    Rigidbody animal;
    Rigidbody farmer;



    public Animal Init(Animalpool pool, Vector3 position)
    {
        this.animal.useGravity = true;
        this.animal_pool = pool;
        this.transform.position = position;
        return this;
    }

    void Awake()
    {
        this.animal = GetComponent<Rigidbody>();
        this.farmer = FindObjectOfType<FarmerController>().GetComponent<Rigidbody>();
        
    }

    void Start()
    {
        
        this.animal.position = transform.position;
        this.animal.rotation = Quaternion.identity;

    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.GetComponent<FarmerController>()) return;
        this.collision();
        
    }

    void FixedUpdate()
    {


        this.Move();
        this.Rotate();
    }

    void Move()
    {
        Vector3 animal_position = this.animal.position;
        animal_position.y = 0;
        this.animal.MovePosition(animal_position + (this.farmer.position - animal_position).normalized * Time.fixedDeltaTime * this.speed);
    }

    void Rotate()
    {
        Vector3 direction = this.farmer.position - this.animal.position;
        direction.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(direction);                      //calculate the value of rotation
        this.animal.MoveRotation(Quaternion.Lerp(this.animal.rotation, targetRotation, Time.deltaTime * speed));   //Quaternion.Lerp---> liner interpolation
    }

    public void collision()
    {
        this.animal_pool.addAnimal(this);
    }



}
