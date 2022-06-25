using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This is the grenade throwing object. It inherits from WeaponObject. You can throw this object as fast as you can click.
/// </summary>
public class Grenade : WeaponObject, Saveable
{
    // Weapon constructor
    public Grenade()
    {
        totalAmmo = 6;
        weaponName = "Grenade";
        projectileVelocity = 5;
        projectileDamage = 100;
    }

    // Use fixed update so game logic isn't tied to framerate
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            // Throw the throwable object
            Throw();
        }
    }
}
