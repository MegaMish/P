using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{

    public float speed = 0.05f;
    public float health = 30;
    public float stoppingDistance = 6.0f;
    public float attackDistance = 8.0f;
    public float attackRate = 2.0f;

    public GameObject deathVfx;
    public AudioClip hitSound;
    public AudioClip deathSound;
    public GameObject attackVfx;
    public AudioClip attackSound;
    public GameObject bullet;

    GameObject target;
    bool alive = true;

    float attackTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("PlayerHead");

    }

    // Update is called once per frame
    void Update()
    {
    if (alive)
        {
            if (!target) return;

            if (Vector3.Distance(transform.position, target.transform.position) > stoppingDistance)
            {

                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);

            }
            transform.LookAt(target.transform.transform.position);


            AttackCycle();
        }

    }

    void AttackCycle()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < attackDistance)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer > attackRate)
            {
                attackTimer = 0; // reset the attack timer
                Instantiate(attackVfx, transform.position, transform.rotation); // lighting
                AudioSource.PlayClipAtPoint(attackSound, transform.position); // play the lighting sound
                Bullet b = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Bullet>();
                b.transform.rotation = transform.rotation; // point bullet at player
            }
        }
    }

    public virtual void TakeDamage(Vector3 location, Vector3 direction, float damage)
    {
        print("TakeDamage");
        health -= damage;

        AudioSource.PlayClipAtPoint(hitSound, transform.position);


        if (health <= 0)
        {
            alive = false;

            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Instantiate(deathVfx, location, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
