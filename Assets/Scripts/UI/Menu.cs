using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    private void Start()
    {
        OpenPanel(_menu);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
