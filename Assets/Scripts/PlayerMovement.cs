using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerInstance;
    [SerializeField] float _playerSpeed = 5.0f;
    [SerializeField] float _jumpPower = 5.0f;
    [SerializeField] float distance = 1f;
    public float playerDamage = 50f;

    private Vector3 targetRot;

    public LayerMask _tileLayer;

    public Rigidbody2D _playerRigidbody;
    private void Start()
    {
        if(playerInstance == null)
        {
            playerInstance = this;
        }
        _playerRigidbody = GetComponent<Rigidbody2D>();

        targetRot = new Vector3(0, 0, 0);
    }
    private void Update()
    {
        MovePlayer();

        if (Input.GetButton("Jump"))
        {
            Jump();
        }
    }
    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * _playerSpeed, _playerRigidbody.velocity.y);

        if(horizontalInput > 0)
        {
            targetRot.y = 0;
        }
        if(horizontalInput < 0)
        {
            targetRot.y = 180;
        }
        transform.eulerAngles = targetRot;
    }
    void Jump()
    {
        if (!IsGrounded())
        {
            return;
        }
        else
        {
            _playerRigidbody.velocity = new Vector2(0, _jumpPower);
        }
    }
     bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, _tileLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
}
