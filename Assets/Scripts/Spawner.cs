using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject robot;
    public float spawnRate = 2.0f;
    public int botCount = 5;
    public Transform spawnPosition;
    
    public bool active = false;

    int botsSpawned = 0;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        if (active && botsSpawned < botCount)
        {
            timer += Time.deltaTime;

            if (timer > spawnRate)
            {
                Instantiate(robot, spawnPosition.position, Quaternion.identity);
                botsSpawned++;

                print(botsSpawned);
                timer = 0; // reset the timer
            }
        }
    }
}
