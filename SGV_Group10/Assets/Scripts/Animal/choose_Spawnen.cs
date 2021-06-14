using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choose_Spawnen : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnens;

    int list_length;
    List<GameObject> active_spawnens;

    // Start is called before the first frame update
    void Start()
    {
        this.list_length = spawnens.Count;
        this.allSpawnen_silent();
        this.activate_Spawnen();

    }

    // Update is called once per frame
    void Update()
    {
       
    }


    void allSpawnen_silent()
    {
        for (int i = 0; i < this.list_length; i++)
        {
            this.spawnens[i].SetActive(false);
        }

    }

    void activate_Spawnen()
    {
        int counter = this.activeSpawnen().Count;
        for (int i = 0; i < counter; i++)
        {
            this.active_spawnens[i].SetActive(true);
        }
    }

    List<GameObject> activeSpawnen()
    {
        this.active_spawnens = new List<GameObject>();
        for (int i = 0; i < this.list_length - 1; i++)
        {
            var randomInt = Random.Range(0, this.list_length);
            active_spawnens.Add(spawnens[randomInt]);
        }

        return active_spawnens;

    }
}
