using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GazeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float gazeTimeRequired = 1.5f; // Time player must look at the card
    public UnityEvent OnGazeCompleted;
    public Image fillIndicator; // Optional: A UI image that fills up as you look

    private bool isBeingLookedAt = false;
    private float gazeTimer = 0f;

    void Update()
    {
        if (isBeingLookedAt)
        {
            gazeTimer += Time.deltaTime;
            if (fillIndicator != null) fillIndicator.fillAmount = gazeTimer / gazeTimeRequired;

            if (gazeTimer >= gazeTimeRequired)
            {
                OnGazeCompleted.Invoke();
                ResetGaze();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isBeingLookedAt = true; // BCI headset says player is looking here
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResetGaze(); // Player looked away
    }

    private void ResetGaze()
    {
        isBeingLookedAt = false;
        gazeTimer = 0f;
        if (fillIndicator != null) fillIndicator.fillAmount = 0f;
    }
}