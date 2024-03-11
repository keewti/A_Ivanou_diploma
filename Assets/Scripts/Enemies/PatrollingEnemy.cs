using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : Enemy
{
    [SerializeField] private GameObject _leftPoint;
    [SerializeField] private GameObject _rightPoint;
    private Rigidbody2D _rb;
    private Transform _destination;
    private SpriteRenderer _spriteRenderer;
    public override void Start()
    {
        base.Start();
        _rb = GetComponent<Rigidbody2D>();
        _destination = _rightPoint.transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        Patrolling();
    }
    public void Patrolling()
    {
        if (_destination == _rightPoint.transform)
        {
            _rb.velocity = new Vector2(_speed, 0);
        }
        else
        {
            _rb.velocity = new Vector2(-_speed, 0);
        }
        if (Vector2.Distance(transform.position, _destination.position) < 0.5f && _destination == _rightPoint.transform)
        {
            _spriteRenderer.flipX = true;
            _destination = _leftPoint.transform;
        }
        if (Vector2.Distance(transform.position, _destination.position) < 0.5f && _destination == _leftPoint.transform)
        {
            _spriteRenderer.flipX = false;
            _destination = _rightPoint.transform;
        }
    }    
}
