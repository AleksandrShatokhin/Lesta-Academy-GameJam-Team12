using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscoreText;
    [SerializeField] Button shopButton;
    [SerializeField] GameObject shopMenu;
    [SerializeField] private string defaultText;
    [SerializeField] private Slider heatSlider;
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        defaultText = highscoreText.text;
    }

    public void OnShopButtonClicked()
    {
        shopMenu.SetActive(true);
        //this.gameObject.SetActive(false);
        Camera.main.GetComponent<ClickToDestroy>().CanMouseClick(false);
        Time.timeScale = 0;
    }

    public void OnContinueGameButtonClicked()
    {
        shopMenu.SetActive(false);
        this.gameObject.SetActive(true);
        Camera.main.GetComponent<ClickToDestroy>().CanMouseClick(true);
        Time.timeScale = 1;
    }

    public void SetHighscoreText(int value) => highscoreText.text = defaultText + value;
}
