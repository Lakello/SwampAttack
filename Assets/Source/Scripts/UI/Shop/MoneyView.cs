using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private Player _player;

    private PlayerMoney _playerMoney;

    private void OnEnable()
    {
        _money.text = _playerMoney.Money.ToString();
        _playerMoney.MoneyChanged += OnMoneyChanged;
    }

    private void Awake()
    {
        _playerMoney = _player.gameObject.GetComponent<PlayerMoney>();
    }

    private void OnDisable()
    {
        _playerMoney.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _money.text = money.ToString();
    }
}
