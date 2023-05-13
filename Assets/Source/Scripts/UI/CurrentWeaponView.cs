using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CurrentWeaponView : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Image _icon;

    private void OnEnable()
    {
        _player.WeaponChanged += OnWeaponChanged;
    }

    private void Start()
    {
        _icon = GetComponent<Image>();
    }

    private void OnDisable()
    {
        _player.WeaponChanged -= OnWeaponChanged;
    }

    private void OnWeaponChanged(Weapon weapon)
    {
        _icon.sprite = weapon.Icon;
    }
}
