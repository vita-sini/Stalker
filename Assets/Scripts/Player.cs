using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _speed = 3;

    private Transform _transform;
    private CharacterController _characterController;

    private void Awake()
    {
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_characterController != null)
        {
            Vector3 playerInput = new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));

            playerInput *= Time.deltaTime * _speed;

            if (_characterController.isGrounded)
            {
                _characterController.Move(playerInput + Vector3.down);
            }
            else
            {
                _characterController.Move(_characterController.velocity + Physics.gravity * Time.deltaTime);
            }
        }
    }
}
