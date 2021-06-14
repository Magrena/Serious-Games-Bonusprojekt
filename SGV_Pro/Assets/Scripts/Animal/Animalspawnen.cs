using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animalspawnen : MonoBehaviour
{
    [SerializeField] Animalpool animal_pool;
    [SerializeField] float spawnFrequency = 15f;

    Transform init_transform;

    float counter = 0f;

    void Awake()
    {
        this.init_transform = transform;

    }

    void Update()
    {
        this.counter += Time.deltaTime;

        if (this.counter >= this.spawnFrequency && this.spawnFrequency >= 0.5 * Time.deltaTime)
        {
            this.animal_spawnen();
            this.spawnFrequency = this.spawnFrequency - 0.5f;
        }
    }


    void animal_spawnen()
    {
        Vector3 init_position = this.init_transform.position;
        init_position.y = 0;
        this.animal_pool.getAnimal(init_position);
        this.counter = 0f;
    }
}
