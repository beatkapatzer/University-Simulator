using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public float speed = 5f; 

    void Update()
    {
        
        Vector3 mousePosition = Input.mousePosition;

        
        
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        
        targetPosition.z = 0; 
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
