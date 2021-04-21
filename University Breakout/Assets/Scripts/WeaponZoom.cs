using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .5f;

    RigidbodyFirstPersonController fpsController;

    bool zoomedInToggle = false;

    void Start()
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

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
