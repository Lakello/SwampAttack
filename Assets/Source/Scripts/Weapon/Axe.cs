using UnityEngine;

public class Axe : Weapon
{
    public override string IdleAnimationName => PlayerAnimatorController.States.IdleAxe;

    public override string AttackAnimationName => PlayerAnimatorController.States.AttackAxe;

    public override void Attack(Transform shootpoint)
    {
        Instantiate(Ammo, shootpoint.position, Quaternion.identity);
    }
}
