using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainHUD;
    public GameObject cardMenu;

    public void OpenCardMenu()
    {
        mainHUD.SetActive(false);
        cardMenu.SetActive(true);
    }

    public void CloseCardMenu()
    {
        cardMenu.SetActive(false);
        mainHUD.SetActive(true);
    }
}