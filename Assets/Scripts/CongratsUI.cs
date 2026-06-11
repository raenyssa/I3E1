using UnityEngine;
using TMPro;
using System.Collections;

public class PopupText : MonoBehaviour
{
    public static PopupText Instance;

    [Header("UI References")]
    public GameObject popupPanel;
    public TextMeshProUGUI messageText;

    [Header("Settings")]
    public float autoDismissTime = 3f; // 0 = stays until dismissed

    private Coroutine _dismissCoroutine;

    void Awake()
    {
        Instance = this;
        popupPanel.SetActive(false);
    }

    public void Show(string message, float duration = 0f)
    {
        messageText.text = message;
        popupPanel.SetActive(true);

        if (_dismissCoroutine != null)
            StopCoroutine(_dismissCoroutine);

        float time = duration > 0 ? duration : autoDismissTime;
        if (time > 0)
            _dismissCoroutine = StartCoroutine(AutoDismiss(time));
    }

    public void Hide()
    {
        if (_dismissCoroutine != null)
            StopCoroutine(_dismissCoroutine);
        popupPanel.SetActive(false);
    }

    IEnumerator AutoDismiss(float time)
    {
        yield return new WaitForSeconds(time);
        Hide();
    }
}