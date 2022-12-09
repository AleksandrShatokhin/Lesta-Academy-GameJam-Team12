using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscoreText;
    [SerializeField] Button shopButton;
    [SerializeField] private string defaultText;

    // Start is called before the first frame update
    void Start()
    {
        defaultText = highscoreText.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShopButtonClicked()
    {

    }

    public void SetHighscoreText(int value) => highscoreText.text = defaultText + value;
}
