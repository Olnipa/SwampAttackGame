using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons = new List<Weapon>();
    [SerializeField] private Player _player;
    [SerializeField] private WeaponCard _weaponCardTemplate;
    [SerializeField] private GameObject _container;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(Weapon weapon)
    {
        var itemCard = Instantiate(_weaponCardTemplate, _container.transform);
        itemCard.Render(weapon);
        itemCard.SellButtonClick += OnSellButtonClick;
    }

    private void OnSellButtonClick(Weapon weapon, WeaponCard card)
    {
        TrySellItem(weapon, card);
    }

    private void TrySellItem(Weapon weapon, WeaponCard card)
    {
        if (weapon.Price <= _player.Money)
        {
            _player.BuyItem(weapon);
            weapon.SellWeapon();
            card.SellButtonClick -= OnSellButtonClick;
        }
    }
}