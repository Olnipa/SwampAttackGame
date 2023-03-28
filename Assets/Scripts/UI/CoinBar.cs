using UnityEngine;
using TMPro;

public class CoinBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinCount;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.CoinsCountChanged += SetCoinCount;
    }

    private void OnDisable()
    {
        _player.CoinsCountChanged -= SetCoinCount;
    }

    private void SetCoinCount(int coinCount)
    {
        _coinCount.text = coinCount.ToString();
    }
}