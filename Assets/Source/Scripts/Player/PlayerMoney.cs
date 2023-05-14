using UnityEngine;
using UnityEngine.Events;

public class PlayerMoney : MonoBehaviour
{
    public int Money { get; private set; }

    public event UnityAction<int> MoneyChanged;

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void RemoveMoney(int money)
    {
        Money -= money;
        MoneyChanged?.Invoke(Money);
    }
}
