using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private PlayerHealth _playerHealth;

    private void OnEnable()
    {
        _playerHealth.HealthChanged += OnValueChanged;
        Slider.value = 1;
    }

    private void Awake()
    {
        _playerHealth = _player.gameObject.GetComponent<PlayerHealth>();
    }

    private void OnDisable()
    {
        _playerHealth.HealthChanged -= OnValueChanged;
    }
}
