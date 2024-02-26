using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private InputBehavoiurs _inputs;
    [SerializeField] private float _jumpHeight = 3.0f;
    [SerializeField] private float _jumpLenght = 0.3f;
    [SerializeField] private LayerMask _ignoreLayers;
    private Animator _animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Player _player;
    private bool _isAlive = true;
    private void OnEnable()
    {
        Player.IsAlive.AddListener(IsPlayerAlive);
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GetComponent<Player>();
    }
    private void Update()
    {
        if (_isAlive)
        {
            Attacking();
            Jumping();
        }
    }
    private void FixedUpdate()
    {
        if (_isAlive)
        {
            Moving();
        }
    }
    private void Moving()
    {
        _rb.velocity = new Vector2(_inputs.Directions() * _player.PlayerStats.speed * Time.deltaTime, _rb.velocity.y);
        if (_rb.velocity.x != 0f)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
        if (_rb.velocity.x > 0f)
        {
            _spriteRenderer.flipX = false;
        }
        else
        if (_rb.velocity.x < 0f)
        {
            _spriteRenderer.flipX = true;
        }
    }
    private void Jumping()
    {
        if (_inputs.Jumping() && IsGrounded() && (_animator.GetBool("isAttacking") != true))
        {
            StartCoroutine(JumpRoutine(_jumpLenght));
        }
    }
    private void Attacking()
    {
        if (_inputs.Attacking())
        {
            _player.Attack();
        }
    }
    IEnumerator JumpRoutine(float time)
    {
        _animator.SetBool("isJumping", true);
        float counter = 0;
        while (counter <= time)
        {
            counter += Time.deltaTime;
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpHeight);
            yield return null;
        }
        _animator.SetBool("isJumping", false);
    }
    private bool IsGrounded()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, ~_ignoreLayers);
        return hit.collider != null;
    }
    private void IsPlayerAlive() => _isAlive = false;

}
