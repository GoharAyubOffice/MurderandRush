using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] float HealthPower = 5f;
    [SerializeField] PlayerHealth playerHealth;


    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerHealth._playerHealth += HealthPower;
            Destroy(this.gameObject);
        }
    }
}
