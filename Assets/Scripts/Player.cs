using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputBehavoiurs _inputs;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _jumpHeight = 3.0f;
    [SerializeField] private float _jumpLenght = 0.3f;
    [SerializeField] private LayerMask _ignoreLayers;
    private CharacterController _charController;
    private void Start()
    {
        _charController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Moving();
        Jumping();
        Gravity();
    }
    private void Moving()
    {
        _charController.Move(_inputs.Directions() * (_speed * 0.01f));
    }
    private void Jumping()
    {
        if (_inputs.Jumping() && IsGrounded())
        {
            StartCoroutine(JumpRoutine(_jumpLenght));
        }
    }
    private void Gravity()
    {
        _charController.Move((Vector3.down * 9.8f) * Time.deltaTime);
    }
    IEnumerator JumpRoutine(float time)
    {
        float counter = 0;
        while (counter <= time)
        {
            counter += Time.deltaTime;
            _charController.Move((_jumpHeight * Vector3.up) * Time.deltaTime);
            yield return null;
        }
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector2.down, 1f, ~_ignoreLayers);
    }
}
