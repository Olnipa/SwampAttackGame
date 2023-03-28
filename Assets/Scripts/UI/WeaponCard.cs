using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponCard : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _sellButton;
    
    private Weapon _weapon;
    private const string _damageWord = "Damage: ";

    public event UnityAction<Weapon, WeaponCard> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnSellButtonClick);
        _sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnSellButtonClick);
        _sellButton.onClick.RemoveListener(TryLockItem);
    }

    public void Render(Weapon weapon)
    {
        _icon.sprite = weapon.Icon;
        _damage.text = _damageWord + weapon.Damage.ToString();
        _lable.text = weapon.Lable;
        _price.text = weapon.Price.ToString();
        _weapon = weapon;
    }

    private void TryLockItem()
    {
        if (_weapon.IsBuyed)
            _sellButton.interactable = false;
    }

    private void OnSellButtonClick()
    {
        SellButtonClick?.Invoke(_weapon, this);
    }
}