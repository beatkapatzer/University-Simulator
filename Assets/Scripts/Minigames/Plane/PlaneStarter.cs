using Unity.VisualScripting;
using UnityEngine;

public class PlaneStarter : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Plane;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
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
