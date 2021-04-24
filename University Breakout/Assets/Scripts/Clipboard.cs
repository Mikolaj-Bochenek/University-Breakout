using TMPro;
using UnityEngine;

public class Clipboard : MonoBehaviour
{
    [SerializeField] int currentClipboardAmount = 0;
    [SerializeField] TextMeshProUGUI clipboardText;
    
    void Update() => DisplayClipboard();

    void DisplayClipboard() => clipboardText.text = $"{currentClipboardAmount}/10";

    public void IncreaseCurrentClipboard() => currentClipboardAmount++;
}
