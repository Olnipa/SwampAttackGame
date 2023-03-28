using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarProgress : Bar
{
    [SerializeField] private Spawner _spawner;

    private void Start()
    {
        _slider.value = 0;
        _spawner.EnemyCountChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _spawner.EnemyCountChanged -= OnValueChanged;
    }
}