using UnityEngine;

public class FPSLocker : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 144;
    }

}
