using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
   private void OnTriggerEnter(Collider collision){
    if(collision.tag == "Player")
    {
        Debug.Log("Koniec");
    }
   }
}
