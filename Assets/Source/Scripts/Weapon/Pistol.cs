using UnityEngine;

public class Pistol : Weapon
{
    public override string IdleAnimationName => PlayerAnimatorController.States.IdleGun;
    public override string AttackAnimationName => PlayerAnimatorController.States.AttackGun;

    public override void Attack(Transform shootpoint)
    {
        Instantiate(Ammo, shootpoint.position, Quaternion.identity);
    }
}
