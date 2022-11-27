using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public static EnemyAi enemyInstance;

    [SerializeField] GameObject player;
    [SerializeField] float followSpeed = .05f;
    public float _enemyHealth;
    public float enemyDamage = 1f;

    [SerializeField] PlayerHealth playerHealth;

    private Vector2 _directionToPlayer;
    BoxCollider2D bc;

    void Start()
    {
        if(enemyInstance == null)
        {
            enemyInstance = this;
        }
        _enemyHealth = 100f;

        bc = GetComponent<BoxCollider2D>();

        player = GameObject.Find("Player");
        playerHealth = FindObjectOfType<PlayerHealth>();
    }
    private void FixedUpdate()
    {
        MoveEnemy();
        KillEnemy();
    }

    private void MoveEnemy()
    {
        _directionToPlayer = (player.transform.position - transform.position).normalized;
        transform.Translate(new Vector2(_directionToPlayer.x, _directionToPlayer.y) * followSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _enemyHealth -= PlayerMovement.playerInstance.playerDamage;

            if (_enemyHealth <= 50)
            {
                followSpeed += 0.01f;
            }
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            playerHealth._playerHealth -= enemyDamage;
        }
    }
    void KillEnemy()
    {
        if(_enemyHealth <=0)
        {
            Destroy(this.gameObject);
        }
    }
}
