using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquip : MonoBehaviour {

    public Transform weaponPos;
    public Sword startSword;
    Sword equippedWeapon;

    private void Start()
    {
        if (startSword != null)
        {
            EquipWeapon(startSword);
        }
    }

    public void EquipWeapon(Sword toEquip)
    {
        if (equippedWeapon != null)
        {
            Destroy(equippedWeapon.gameObject);
        }
        equippedWeapon = Instantiate(toEquip, weaponPos.position, weaponPos.rotation) as Sword;
        equippedWeapon.transform.localScale = Vector3.one * 30.0f;
        equippedWeapon.transform.parent = weaponPos;
    }
}
