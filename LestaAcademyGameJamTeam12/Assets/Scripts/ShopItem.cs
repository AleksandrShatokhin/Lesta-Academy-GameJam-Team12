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
            difficultyManager.AddToSpentGold(itemPrice);

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
