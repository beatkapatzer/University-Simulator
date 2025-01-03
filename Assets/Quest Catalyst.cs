using UnityEngine;

public class QuestCatalyst : MonoBehaviour
{
    [SerializeField] private string quest;
    [SerializeField] private GameObject notification;
    private bool questAdded = false;

    public void CreateQuest()
    {
        if (quest != null && !questAdded)
        {
            questAdded = !questAdded;
            MainManeger.mainManeger.questNames.Add(quest);
        }
        if (notification != null && !questAdded)
        {
            notification.SetActive(true);
        }
    }
    public void CompleteQuest() 
    {
        if (quest != null && MainManeger.mainManeger.questNames.Contains(quest)) 
        {
        MainManeger.mainMeneger.questNames.Remove(quest);
        }
    }



}
