using UnityEngine;

public class badcube : MonoBehaviour
{



    public GameObject Player;
    
    public Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;

    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Player.transform.position = startPosition;
        }

    }
}
