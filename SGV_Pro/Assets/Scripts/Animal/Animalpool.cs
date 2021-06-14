using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//basically a copy&paste of ProjectilePool. This couls be refactored in a generic aproach
public class Animalpool : MonoBehaviour
{
    [SerializeField] Animal animal_instance;
    List<Animal> animals;


    void Start()
    {
        this.animals = new List<Animal>();      //for the animal pool
    }

    public Animal getAnimal(Vector3 position)
    {
        Animal animal;

        if (this.animals.Count > 0)
        {
            animal = this.animals[0];
            this.animals.Remove(animal);
        }
        else
        {
            animal = Instantiate(this.animal_instance, position, Quaternion.identity);
            animal.transform.SetParent(this.transform);
        }
        animal.Init(this, position);
        animal.gameObject.SetActive(true);
        return animal;
    }

    public void addAnimal(Animal animal)
    {
        
        animal.gameObject.SetActive(false);
        this.animals.Add(animal);
    }
}
