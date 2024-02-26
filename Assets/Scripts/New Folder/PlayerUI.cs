using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _fillImage;
    [SerializeField] private Gradient _gradient;
    private Player _player;
    private void Start()
    {
        _player = FindAnyObjectByType<Player>();
        _slider.maxValue = _player.PlayerStats.hp;
        _slider.value = _player.PlayerStats.hp;
        Player.HPChanged.AddListener(OnHPChanged);
    }
    private void OnHPChanged(int change)
    {
        _slider.value -= change;
        Debug.Log(_slider.value);
        _fillImage.color = _gradient.Evaluate(_slider.value / _slider.maxValue);
    }
}
