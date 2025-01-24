using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public InputOutput[] outputFields; 

    void Start()
    {
        foreach (var field in outputFields)
        {
            int randomValue = Random.Range(0, 10); 
            field.SetValue(randomValue);
        }
    }
}