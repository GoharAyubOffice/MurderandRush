using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float _playerHealth;
    void Start()
    {
        _playerHealth = 100f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            _playerHealth -= EnemyAi.enemyInstance.enemyDamage;
        }
    }
    private void Update()
    {
        PlayerDead();
    }
    void PlayerDead()
    {
        if(_playerHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
