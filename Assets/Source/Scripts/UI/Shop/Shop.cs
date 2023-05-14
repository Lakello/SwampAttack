using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContainer;

    private PlayerMoney _playerMoney;
    private PlayerWeapon _playerWeapon;

    private void Start()
    {
        _playerMoney = _player.gameObject.GetComponent<PlayerMoney>();
        _playerWeapon = _player.gameObject.GetComponent<PlayerWeapon>();

        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(weapon);
    }

    private void OnSellButtonClick(Weapon weapon, WeaponView weaponView)
    {
        TrySellWeapon(weapon, weaponView);
    }

    private void TrySellWeapon(Weapon weapon, WeaponView weaponView)
    {
        if (weapon.Price <= _playerMoney.Money)
        {
            _playerWeapon.BuyWeapon(weapon);
            weapon.Buy();
            weaponView.SellButtonClick -= OnSellButtonClick;
        }
    }
}
