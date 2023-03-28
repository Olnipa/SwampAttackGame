using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Button _nextWaveButton;
    [SerializeField] private Spawner _spawner;
    
    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemyDied;
        _nextWaveButton.onClick.AddListener(OnNextWaveButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemyDied;
        _nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClick);
    }

    private void OnAllEnemyDied()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }

    public void OnNextWaveButtonClick()
    {
        _spawner.StartWave();
        _nextWaveButton.gameObject.SetActive(false);
    }
}
