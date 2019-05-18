using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.25f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<Player>().TakeDamage(10);
        }

        Destroy(gameObject);
    }
}
