using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bleed;

    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
        }
        if (collision.CompareTag("Obstacles"))
        {
            Instantiate(bleed, transform.position, Quaternion.identity);
        }
    }
}
