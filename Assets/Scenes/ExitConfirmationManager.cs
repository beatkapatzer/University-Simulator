using UnityEngine;

public class ExitConfirmationManager : MonoBehaviour
{
    public GameObject confirmationPanel; // Panel z potwierdzeniem
    public GameObject mainMenuPanel;    // Panel g³ównego menu (jeœli istnieje)

    // Metoda do pokazania panelu potwierdzenia
    public void ShowConfirmation()
    {
        Debug.Log("ShowConfirmation wywo³ane");
       
        confirmationPanel.SetActive(true);
       
    }

    // Metoda do ukrycia panelu potwierdzenia
    public void HideConfirmation()
    {

        confirmationPanel.SetActive(false);
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true); // Poka¿ menu, jeœli by³o ukryte
        }
    }

    // Metoda do wyjœcia z gry
    public void QuitGame()
    {
        Debug.Log("Exiting the game..."); // Dzia³a tylko w buildzie gry
        Application.Quit();
    }
}
