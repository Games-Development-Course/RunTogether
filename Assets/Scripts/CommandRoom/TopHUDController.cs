using UnityEngine;
using TMPro;
using System.Collections;

public class TopHUDController : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public float messageDuration = 2f;

    private Coroutine currentRoutine;

    public void ShowMessage(string msg)
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(MessageRoutine(msg));
    }

    private IEnumerator MessageRoutine(string text)
    {
        messageText.text = text;
        messageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(messageDuration);

        messageText.gameObject.SetActive(false);
    }
}