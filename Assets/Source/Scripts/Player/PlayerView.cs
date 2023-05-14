using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerWeapon))]
public class PlayerView : MonoBehaviour
{
    private Animator _animator;
    private PlayerWeapon _weapon;
    private Weapon _currentWeapon;

    private void Awake()
    {
        _weapon = GetComponent<PlayerWeapon>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _weapon.Attacking += OnAttaking;
        _weapon.WeaponChanged += OnWeaponChanged;
    }

    private void OnDisable()
    {
        _weapon.Attacking -= OnAttaking;
        _weapon.WeaponChanged -= OnWeaponChanged;
    }

    private void OnAttaking()
    {
        _animator.Play(_currentWeapon.AttackAnimationName);
    }

    private void OnWeaponChanged(Weapon weapon)
    {
        _currentWeapon = weapon;
        _animator.Play(_currentWeapon.IdleAnimationName);
    }
}
