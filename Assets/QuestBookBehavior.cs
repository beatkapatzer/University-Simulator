using UnityEngine;

public class QuestBookBehavior : MonoBehaviour
{
    [SerializeField] private GameObject questPage;
    [SerializeField] private Text questTextBox;
    [SerializeField] private GameObject notification;
    [SerializeField] private string[] noQuestsText;
    private bool openBook;

    public void OpenQuestBook() 
    { 
        openBook = !openBook;
    }

    private void CreatePage() 
    {
        if (questPage != null && notification != null) 
        {
            if (openBook)
            {
                questPage.SetActive(true);
                notification.SetActive(false);
            }
            else 
            {
                questPage.SetActive(false);
            }
        }
    }
    private void WriteQuest() 
    {
        if (questTextBox != null)
        {
            if (MainManeger.mainManeger.questNames.Count == 0)
            {
                if (noQuestsText != null)
                {
                    int randomNumber = (Random.Range(0, noQuestsText.Length));
                    questTextBox.text = noQuestsText[randomNumber];
                }
            }
            else 
            {
                StringBuilder stringBuilder = new();
                foreach (string quest in MainManeger.MainManeger.questNames)
                {
                    stringBuilder.AppendLine(quest);
                }
                questTextBox = stringBuilder.ToString();
            }

            questTextBox.rectTransform.sizeDelta = new Vector2(questTextBox.rectTransform.sizeDelta.x, questTextBox.preferredHeight);
        
        }
    }
}
