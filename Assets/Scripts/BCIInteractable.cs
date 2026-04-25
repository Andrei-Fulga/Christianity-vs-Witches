using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BCIInteractable : MonoBehaviour
{
    public float gazeTimeRequired = 1.2f;
    private float timer = 0f;
    private bool isGazing = false;
    public UnityEvent onGazeCompleted;
    public Image loadingBar; // Optional: fill a circle while looking

    public void OnPointerEnter() { isGazing = true; }
    public void OnPointerExit() { isGazing = false; timer = 0; if(loadingBar) loadingBar.fillAmount = 0; }

    void Update()
    {
        if (isGazing)
        {
            timer += Time.deltaTime;
            if(loadingBar) loadingBar.fillAmount = timer / gazeTimeRequired;

            if (timer >= gazeTimeRequired)
            {
                onGazeCompleted.Invoke();
                timer = 0; // Reset after trigger
                isGazing = false;
            }
        }
    }
}