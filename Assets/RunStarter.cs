using UnityEngine;

public class RunStarter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject RunModel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RunStart();
        }

    }

    void RunStart()
    {
        Player.SetActive(false);
        RunModel.SetActive(true);

        Destroy(this.gameObject);
    }
}
