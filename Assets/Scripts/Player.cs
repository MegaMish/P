using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float health = 100;
    public AudioClip death;

    bool alive = true;

    public void TakeDamage(float damage)
    {
        health -= damage;
        print(health);

        if (alive && health <= 0)
        {
            alive = false;
            AudioSource.PlayClipAtPoint(death, transform.position);
            print("death");
            Invoke("RestartLevel",3.0f);
        }

    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
