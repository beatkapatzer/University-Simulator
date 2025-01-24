using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class SceneTransitionTrigger : MonoBehaviour
{
    public Animator fadeAnimator; // Animator odpowiedzialny za animacjê przyciemniania
    public string sceneToLoad; // Nazwa sceny, na któr¹ chcesz przejœæ
    private bool isTransitioning = false; // Zapobiega wielokrotnemu uruchomieniu

    private void OnTriggerEnter(Collider other)
    {
        if (isTransitioning) return;

        // SprawdŸ, czy gracz wszed³ w trigger
        if (other.CompareTag("Player"))
        {
            isTransitioning = true;
            StartCoroutine(LoadSceneWithFade());
        }
    }

    private IEnumerator LoadSceneWithFade()
    {
        // Uruchom animacjê przyciemniania
        fadeAnimator.SetTrigger("FadeOut");

        // Poczekaj na zakoñczenie animacji
        yield return new WaitForSeconds(fadeAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Za³aduj now¹ scenê
        SceneManager.LoadScene(sceneToLoad);
    }
}
