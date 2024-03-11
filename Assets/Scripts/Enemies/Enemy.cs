using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Creature
{
    [SerializeField] private EnemiesSO _enemy;
    [SerializeField] private Player _player;
    protected EnemyAnimationController _animController;
    private int _maxHP;
    private int _curHP;
    protected float _speed;

    protected override int Dmg => _enemy.DMG;

    private void Awake()
    {
        Initialize();
    }
    public virtual void Start()
    {
        _animController = GetComponent<EnemyAnimationController>();
        _player = FindObjectOfType<Player>(); // TODO: make enemies find player without it
        _curHP = _maxHP;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _player.TakeDMG(_enemy.DMG);
        }
    }
    public override void TakeDMG(int dmg)
    {
        UpdateHealth(dmg);
        DeathCheck();
    }
    public override void DeathCheck() // todo: make elder class for enemies and player to do stuff like this
    {
        if (_curHP <= 0) 
        {
            _curHP = 0;
            _animController.Kill();
            StartCoroutine(DeathRoutine(0.65f));
        }
    }
    IEnumerator DeathRoutine(float time)
    {
        float counter = 0;
        while (counter <= time)
        {
            counter += Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
    }
    private void Initialize()
    {
        _speed = _enemy.Speed;
        _maxHP = _enemy.HP;
    }
    public void UpdateHealth(int deltaHP)
    {
        _curHP -= deltaHP;
    }
}
