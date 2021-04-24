using UnityEngine;

public class ClipboardPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Clipboard>().IncreaseCurrentClipboard();
            Destroy(gameObject);
        }   
    }
}
