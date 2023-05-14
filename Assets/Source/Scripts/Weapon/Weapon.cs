using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Ammo Ammo;

    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;

    public abstract string IdleAnimationName { get; }
    public abstract string AttackAnimationName { get; }

    public abstract void Attack(Transform shootpoint);

    public void Buy()
    {
        _isBuyed = true;
    }
}
