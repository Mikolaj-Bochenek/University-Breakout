using System;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    
    [Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType) => GetAmmoSlot(ammoType).ammoAmmount;

    public void ReduceCurrentAmmo(AmmoType ammoType) => GetAmmoSlot(ammoType).ammoAmmount--;

    AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (var slot in ammoSlots)
            if (slot.ammoType == ammoType)
                return slot;

        return null;
    }
}
