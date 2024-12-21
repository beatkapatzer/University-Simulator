using Unity.VisualScripting;
using UnityEngine;

public class PlaneStarter : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Plane;
    [SerializeField] bool UnlockCursor;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (UnlockCursor)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
                

            PlaneStart();
        }
        
    }

    void PlaneStart()
    {
        Player.SetActive(false);
        Plane.SetActive(true);

        Destroy(this.gameObject);
    }
}
