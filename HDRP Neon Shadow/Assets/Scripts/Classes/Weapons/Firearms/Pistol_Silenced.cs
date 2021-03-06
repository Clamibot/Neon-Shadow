using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the silenced pistol object. It inherits from WeaponObject. This weapon is semi-automatic, and will fire as fast as you can pull the trigger.
/// </summary>
public class Pistol_Silenced : WeaponObject, Saveable
{
    // Weapon constructor
    public Pistol_Silenced()
    {
        maxClipAmmo = 16;
        currentAmmo = 16;
        totalAmmo = 64;
        reloadTime = 1;
        weaponName = "Spiker";
        projectileVelocity = 20;
        projectileDamage = 40;
        projectileLife = 5;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !reloading)
        {
            // Fire the weapon upon left click or throw the held object
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.R) && !reloading)
        {
            // Reload the weapon
            Reload();
        }
        if (reloading)
            reloadTimer += Time.deltaTime;

        if (reloading && reloadTimer > reloadTime)
        {
            //Set to false so that We don't run this again
            reloading = false;
            reloadTimer = 0;
        }
    }
}