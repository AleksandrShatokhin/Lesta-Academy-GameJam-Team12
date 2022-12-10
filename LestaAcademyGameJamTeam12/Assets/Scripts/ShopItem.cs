using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{

    [SerializeField] private GameObject objectOnScene;
    [SerializeField] protected int itemPrice = 0;
    [SerializeField] protected GameManager gameManager;
    [SerializeField] protected DifficultyManager difficultyManager;
    [SerializeField] protected HeatController heatController;

    private bool isPurchased = false;

    public virtual void OnShopItemButtonClicked()
    {
        if (!isPurchased && CheckForMoney())
        {
            //Поменять спрайт в магазе
            GetComponent<Image>().color = Color.black;

            //Активировать предмет
            objectOnScene.SetActive(true);

            isPurchased = true;
            gameManager.Score -= itemPrice;
            gameManager.AddToSpentGold(itemPrice);
            heatController.ChangeDecreaseRate();

        }
    }

    protected bool CheckForMoney()
    {
        if (gameManager.Score >= itemPrice)
        {
            return true;
        }
        else return false;
    }
}
