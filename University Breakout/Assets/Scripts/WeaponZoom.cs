using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;

    bool zoomedInToggle = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            zoomedInToggle = !zoomedInToggle;
            fpsCamera.fieldOfView = zoomedInToggle ? zoomedInFOV : zoomedOutFOV;
        }
    }
}
