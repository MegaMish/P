using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Spawner spawner;

    void OnTriggerEnter(Collider other)
    {
        spawner.active = true;
    }
}
