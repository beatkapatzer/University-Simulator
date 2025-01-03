using UnityEngine;

public class MainManeger : MonoBehaviour
{
    public List<string> questNames = new List<string>();

    public static MainManeger mainManeger;

    private void Awake() 
    {
        if (mainManeger != null) 
        {
            Destroy(gameObject);
        }

        mainManeger = this;
        DontDestroyOnLoad(gameObject);
    }
    
}
