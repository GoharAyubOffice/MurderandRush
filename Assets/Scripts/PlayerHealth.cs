using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth playerHealthInstance;
    public float _playerHealth;
    float maxHealth = 100f;
    void Start()
    {
        playerHealthInstance = this;
        _playerHealth = 100f;
    }
    private void Update()
    {
        DefaultHealth();
        PlayerDead();
    }
    void PlayerDead()
    {
        if(_playerHealth <= 0)
        {
            Destroy(this.gameObject);
            GameManager.gameManagerInstacne.MainMenu(); //If player die Go to Main Menu Scene
        }
    }
    void DefaultHealth()
    {
        if(_playerHealth >= maxHealth)
        {
            _playerHealth = maxHealth;
        }
    }
}
