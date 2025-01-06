using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private  RectTransform background; // Referencja do t³a
    [SerializeField] private float speed = 50f; // Prêdkoœæ przesuwania
    [SerializeField] private float moveDistance = 500f; // Maksymalna odleg³oœæ przesuniêcia (poza ekran)

    private Vector2 startPosition; // Pozycja pocz¹tkowa
    private bool movingRight = true; // Kierunek ruchu

    private void Start()
    {
        // Zapamiêtaj pocz¹tkow¹ pozycjê t³a
        startPosition = background.anchoredPosition;
    }

    private void Update()
    {
        // Oblicz now¹ pozycjê w zale¿noœci od kierunku ruchu
        float moveStep = speed * Time.deltaTime;
        if (movingRight)
        {
            background.anchoredPosition += new Vector2(moveStep, 0);

            // Jeœli osi¹gniêto maksymaln¹ odleg³oœæ, zmieñ kierunek
            if (background.anchoredPosition.x >= startPosition.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            background.anchoredPosition -= new Vector2(moveStep, 0);

            // Jeœli wrócono do pocz¹tkowej pozycji, zmieñ kierunek
            if (background.anchoredPosition.x <= startPosition.x - moveDistance)
            {
                movingRight = true;
            }
        }
    }
}
