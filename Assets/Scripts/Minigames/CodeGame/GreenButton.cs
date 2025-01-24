using UnityEngine;

public class CheckButton : MonoBehaviour
{
    public InputOutput[] inputFields;
    public InputOutput[] outputFields;

    public void OnCheckClick()
    {
        bool isCorrect = true;

        for (int i = 0; i < inputFields.Length; i++)
        {
            if (inputFields[i].value != outputFields[i].value)
            {
                isCorrect = false;
                outputFields[i].fieldValue.color = Color.red;
            }
            else
            {
                outputFields[i].fieldValue.color = Color.green;
            }
        }

        if (isCorrect)
        {
            Debug.Log("Konto zosta³o zhakowane poprawnie!");
        }
    }
}

