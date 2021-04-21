using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .5f;


    bool zoomedInToggle = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            zoomedInToggle = !zoomedInToggle;
            fpsCamera.fieldOfView = zoomedInToggle ? zoomedInFOV : zoomedOutFOV;
            fpsController.mouseLook.XSensitivity = zoomedInToggle ? zoomInSensitivity : zoomOutSensitivity;
            fpsController.mouseLook.YSensitivity = zoomedInToggle ? zoomInSensitivity : zoomOutSensitivity;
        }
    }
}
