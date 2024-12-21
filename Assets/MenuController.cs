using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuController : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    
    public void QuitGame()
    {
        Debug.Log("Wyjœcie z gry...");
        Application.Quit(); 

        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    
    public void OpenOptions()
    {
        Debug.Log("Otwieranie opcji...");
    }

    public void OpenCredits()
    {
        Debug.Log("Otwieranie kredytów...");
    }
}
