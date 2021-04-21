using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;

    public int GetCurrentAmmo() => ammoAmount;

    public void ReduceCurrenAmmo() => ammoAmount--;
}
