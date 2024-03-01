using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void Attack()
    {
        _animator.SetBool("isAttacking", true);
    }
    public void StopAttack()
    {
        _animator.SetBool("isAttacking", false);
    }
    public void Hurt()
    {
        _animator.SetBool("isHurting", true);
    }
    public void StopHurtAnim()
    {
        _animator.SetBool("isHurting", false);
    }
    public void Kill()
    {
        _animator.SetBool("isDead", true);
    }
}
