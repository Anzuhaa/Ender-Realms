using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
    private Animator animator;
    private CharacterController _characterController;
    private Vector2 _input;
    private Vector3 _direction;
    private Vector3 _velocity;
    private float _currentVelocity;
    [SerializeField] private float smoothTime = 0.05f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -9.81f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_input.sqrMagnitude > 0)
        {
            animator.SetBool("Moving", true);

            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;

            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();

            _direction = forward * _input.y + right * _input.x;

            var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

            _characterController.Move(_direction * speed * Time.deltaTime);

            Debug.Log($"Moving in direction: {_direction}");
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        _velocity.y += gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);

        if (_characterController.isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();

        Debug.Log($"Input: {_input}, Direction: {_direction}");
    }
}
