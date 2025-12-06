using Unity.Netcode;
using UnityEngine;

public class PlayerCamera1P : NetworkBehaviour
{
    public float mouseSensitivity = 200f;
    public Transform playerBody;

    float xRotation = 0f;

    public float lockDuration = 0.5f;
    private bool cameraLocked = true;
    private float timer = 0f;

    void Start()
    {
        if (!IsOwner)
        {
            enabled = false; // ❗ הסקריפט לא עובד אצל שחקנים אחרים
            return;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!IsOwner) return;              // ❗ רק הבעלים מזיז את המצלמה
        if (GameManager.Instance == null) return;
        if (playerBody == null) return;
        if (GameManager.Instance.inPuzzle) return;

        if (cameraLocked)
        {
            timer += Time.deltaTime;

            xRotation = 0f;
            transform.localRotation = Quaternion.identity;
            playerBody.rotation = Quaternion.identity;

            if (timer >= lockDuration)
                cameraLocked = false;

            return;
        }

        // input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    public void LockCameraForSeconds(float duration)
    {
        lockDuration = duration;
        cameraLocked = true;
        timer = 0f;
    }
}
