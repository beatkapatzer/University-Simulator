using UnityEngine;

public class MInigameFinisher : MonoBehaviour
{
    [SerializeField] string ObjectTag;
    [SerializeField] GameObject MapPlayer;
    [SerializeField] GameObject MinigamePlayer;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ObjectTag)
        {
            MapPlayer.SetActive(true);
            MinigamePlayer.SetActive(false);
        }
        
    }
}
