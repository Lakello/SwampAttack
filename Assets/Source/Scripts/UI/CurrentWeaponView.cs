using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CurrentWeaponView : MonoBehaviour
{
    [SerializeField] private PlayerWeapon _playerWeapon;

    private Image _icon;
   
    private void OnValidate()
    {
        if (_icon == null)
            _icon = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _playerWeapon.WeaponChanged += OnWeaponChanged;
    }

    private void OnDisable()
    {
        _playerWeapon.WeaponChanged -= OnWeaponChanged;
    }

    private void OnWeaponChanged(Weapon weapon)
    {
        Debug.Log(_icon == null);

        _icon.sprite = weapon.Icon;
    }
}
