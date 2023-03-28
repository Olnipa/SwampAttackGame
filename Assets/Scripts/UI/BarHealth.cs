using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarHealth : Bar
{
    [SerializeField] private Player _player;

    private void Start()
    {
        _slider.value = 1;
        _player.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }
}