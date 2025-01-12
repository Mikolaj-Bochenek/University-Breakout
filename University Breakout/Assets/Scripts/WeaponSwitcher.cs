using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    [SerializeField] Canvas gunReticleCanvas;

    void Start() => SetWeaponActive();
    void Update()
    {
        int previousWeapon = currentWeapon;
        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
            if (currentWeapon == 3)
            {
                gunReticleCanvas.enabled = false;
                Debug.Log("laptop");
            }
            else
            {
                gunReticleCanvas.enabled = true;
            }
        }
    }

    void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            currentWeapon = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            currentWeapon = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            currentWeapon = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            currentWeapon = 3;
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            weaponIndex++;
        }
    }

    void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon >= transform.childCount - 1)
                currentWeapon = 0;
            else
                currentWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon <= 0)
                currentWeapon = transform.childCount - 1;
            else
                currentWeapon--;
        }
    }
}
