using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMoney))]
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private PlayerMoney _player;
    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;

    public event UnityAction<Weapon> WeaponChanged;
    public event UnityAction Attacking;

    private void Start()
    {
        _player = GetComponent<PlayerMoney>();

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void OnClickAttackButton()
    {
        Attacking?.Invoke();
    }

    public void OnAttack()
    {
        _currentWeapon.Attack(_shootPoint);
    }

    public void BuyWeapon(Weapon weapon)
    {
        _weapons.Add(weapon);
        _player.RemoveMoney(weapon.Price);
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count - 1)
        {
            _currentWeaponNumber = 0;
        }
        else
        {
            _currentWeaponNumber++;
        }

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
        {
            _currentWeaponNumber = _weapons.Count - 1;
        }
        else
        {
            _currentWeaponNumber--;
        }

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        WeaponChanged?.Invoke(weapon);
    }
}
