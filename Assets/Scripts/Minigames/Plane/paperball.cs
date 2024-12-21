using UnityEngine;

public class paperball : MonoBehaviour
{
    public GameObject paperPrefab; // Prefab kulki papieru
    public Transform throwPoint;   // Punkt startowy rzutu
    public float maxThrowForce = 15f; // Maksymalna si³a rzutu
    public Camera playerCamera;    // Kamera gracza, u¿ywana do celowania

    private float currentForce = 0f; // Aktualna si³a rzutu

    void Update()
    {
        // £adowanie si³y rzutu
        if (Input.GetKey(KeyCode.Space))
        {
            currentForce += Time.deltaTime * 10; // Przytrzymanie klawisza zwiêksza si³ê
            currentForce = Mathf.Clamp(currentForce, 0, maxThrowForce); // Ograniczenie maksymalnej si³y
        }

        // Rzut kulk¹
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ThrowPaper();
        }
    }

    void ThrowPaper()
    {
        // Tworzenie kulki papieru w punkcie startowym
        GameObject paper = Instantiate(paperPrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = paper.GetComponent<Rigidbody>();

        // Wyliczanie kierunku rzutu (w oparciu o kamerê gracza)
        Vector3 throwDirection = GetThrowDirection();

        // Nadanie si³y rzutu
        rb.AddForce(throwDirection * currentForce, ForceMode.Impulse);

        // Reset si³y po rzucie
        currentForce = 0;
    }

    Vector3 GetThrowDirection()
    {
        // Celowanie w przestrzeni 3D za pomoc¹ kamery
        Ray cameraRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Jeœli kamera "widzi" kosz lub inn¹ powierzchniê, kierujemy rzut w to miejsce
        if (Physics.Raycast(cameraRay, out hit))
        {
            return (hit.point - throwPoint.position).normalized; // Kierunek do punktu trafienia
        }
        else
        {
            return throwPoint.forward; // Domyœlny kierunek (przed siebie)
        }
    }
}

