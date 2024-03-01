using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] public Stats PlayerStats = new(100, 5, 1f);
    [SerializeField] private float _iframes = 0.5f;
    private GameObject _dmgZone;
    private Animator _animator;
    private PlayerAnimationController _animController;
    private float _curSpeed;
    private bool _isInvulerable = false;
    public static UnityEvent IsAlive = new();
    public static UnityEvent<int> HPChanged = new();
    public static UnityEvent IsDead = new();
    private void Start()
    {
        _curSpeed = PlayerStats.speed;
        _dmgZone = transform.GetChild(0).gameObject;
        _dmgZone.SetActive(false);
        _animator = GetComponent<Animator>();
        _animController = GetComponent<PlayerAnimationController>();
    }
    public void Attack()
    {
        PlayerStats.speed = 0;
        _animController.Attack();
        _dmgZone.SetActive(true);
    }
    private void StopAttack()
    {
        _animController.StopAttack();
        PlayerStats.speed = _curSpeed;
        _dmgZone.SetActive(false);
    }
    public void TakeDMG(int DMG)
    {
        if (_isInvulerable)
        {
            return;
        }
        PlayerStats.hp -= DMG;
        HPChanged.Invoke(DMG);
        StartCoroutine(InvulRoutine(_iframes));
        DeathCheck();
    }
    private void DeathCheck()
    {
        if (PlayerStats.hp <= 0) 
        { 
            PlayerStats.hp = 0;
            _isInvulerable = true;
            _animController.Kill();
        }
    }
    private void Death()
    {
        IsDead.Invoke();
    }

    IEnumerator InvulRoutine(float time)
    {
        _animController.Hurt();
        _isInvulerable = true;
        float counter = 0;
        while (counter <= time)
        {
            counter += Time.deltaTime;
            yield return null;
        }
        _isInvulerable = false;
    }
}
