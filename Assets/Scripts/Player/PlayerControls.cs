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
    private CharacterController _charController;
    private SpriteRenderer _spriteRenderer;
    private Player _player;
    private void Start()
    {
        _charController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GetComponent<Player>();
    }
    private void Update()
    {
        Moving();
        Jumping();
        Gravity();
        Attacking();
    }
    private void Moving()
    {
        _charController.Move(_inputs.Directions() * (_player.PlayerStats.speed * 0.01f));
        if (_inputs.Directions().x != 0f)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
        if (_inputs.Directions().x > 0f)
        {
            _spriteRenderer.flipX = false;
        }
        else
        if (_inputs.Directions().x < 0f)
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
    private void Gravity()
    {
        _charController.Move((Vector3.down * 9.8f) * Time.deltaTime);
    }
    IEnumerator JumpRoutine(float time)
    {
        _animator.SetBool("isJumping", true);
        float counter = 0;
        while (counter <= time)
        {
            counter += Time.deltaTime;
            _charController.Move((_jumpHeight * Vector3.up) * Time.deltaTime);
            yield return null;
        }
        _animator.SetBool("isJumping", false);
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector2.down, 1f, ~_ignoreLayers);
    }
}
