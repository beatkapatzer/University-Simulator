using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Transform Camera; // Referencja do kamery
    public float Sensitivity = 100f; // Czu³oœæ myszy
    private float xRotation = 0f; // Rotacja w osi X (góra/dó³)
    private Vector2 currentMouseDelta; // Aktualny ruch myszy
    private Vector2 smoothedMouseDelta; // Wyg³adzony ruch myszy
    public float SmoothTime = 0.05f; // Czas wyg³adzania ruchu myszy

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Blokowanie kursora na œrodku ekranu
        Cursor.visible = false; // Ukrycie kursora
    }

    void Update()
    {
        // Pobranie ruchu myszy
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * Sensitivity * 0.01f;

        // Wyg³adzanie ruchu myszy
        currentMouseDelta = Vector2.Lerp(currentMouseDelta, mouseDelta, 1f / SmoothTime);
        smoothedMouseDelta = Vector2.Lerp(smoothedMouseDelta, currentMouseDelta, SmoothTime);

        // Obrót gracza w osi Y (lewo/prawo)
        transform.Rotate(Vector3.up * smoothedMouseDelta.x);

        // Obrót kamery w osi X (góra/dó³)
        xRotation -= smoothedMouseDelta.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Ustawienie rotacji kamery
        Camera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}