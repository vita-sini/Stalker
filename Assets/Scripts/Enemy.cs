using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
   [SerializeField] private Transform _player;

    private float _speed = 2.0f;
    private float _stoppingDistance = 2.0f;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = (_player.position - transform.position).normalized;
        float distance = Vector3.Distance(_player.position, transform.position);

        if (distance > _stoppingDistance)
        {
            _rigidbody.MovePosition(transform.position + direction * _speed * Time.fixedDeltaTime);
        }
    }
}
