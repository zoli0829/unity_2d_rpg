using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    private PlayerAnimations playerAnimations;
    private PlayerActions actions;
    private Player player;
    private Rigidbody2D rb2d;
    private Vector2 moveDirection;

    private void Awake()
    {
        player = GetComponent<Player>();
        playerAnimations = GetComponent<PlayerAnimations>();
        actions = new PlayerActions();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move() 
    {
        // if the player is dead, we are not going to move
        if (player.Stats.Health <= 0) return;
        rb2d.MovePosition(rb2d.position + moveDirection * (speed * Time.fixedDeltaTime));
    }

    private void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
        if (moveDirection == Vector2.zero )
        {
            playerAnimations.SetMoveBoolTransition(false);
            return;
        }

        // Update our parameters in the animator
        playerAnimations.SetMoveBoolTransition(true);
        playerAnimations.SetMoveAnimation(moveDirection);
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
