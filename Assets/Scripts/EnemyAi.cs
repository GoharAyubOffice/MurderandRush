using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public static EnemyAi enemyInstance;

    [SerializeField] GameObject player;
    [SerializeField] float followSpeed = .05f;
    public float _enemyHealth;

    public float enemyDamage = 20f;

    private Vector2 _directionToPlayer;
    BoxCollider2D bc;

    void Start()
    {
        if(enemyInstance == null)
        {
            enemyInstance = this;
        }
        player = GameObject.Find("Player");
        _enemyHealth = 100f;
        bc = GetComponent<BoxCollider2D>();
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
    }
    void KillEnemy()
    {
        if(_enemyHealth <=0)
        {
            Destroy(this.gameObject);
        }
    }
}
