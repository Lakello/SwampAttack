using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(Transform shootpoint)
    {
        Instantiate(Bullet, shootpoint.position, Quaternion.identity);
    }
}
