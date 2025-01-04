using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Transform Camera; // Referencja do kamery
    public float Sensitivity = 100f; // Czu³oœæ myszy
    private float xRotation = 0f; // Rotacja w osi X (góra/dó³)

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Blokowanie kursora na œrodku ekranu
        Cursor.visible = false; // Ukrycie kursora
    }

    void Update()
    {
        // Pobranie ruchu myszy
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        // Obrót gracza w osi Y (lewo/prawo)
        transform.Rotate(Vector3.up * mouseX);

        // Obrót kamery w osi X (góra/dó³)
        xRotation -= mouseY; // Ujemne, poniewa¿ ruch myszy w górê powoduje spadek k¹ta
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Ograniczenie k¹ta (patrzenie tylko w górê i w dó³ w zakresie 90°)

        // Ustawienie rotacji kamery
        Camera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
