using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{

    [SerializeField] private GameObject objectOnScene;
    [SerializeField] private int itemPrice = 0;
    [SerializeField] private GameManager gameManager;

    private bool isPurchased = false;

    public void OnShopItemButtonClicked()
    {
        if (!isPurchased && CheckForMoney())
        {
            //Поменять спрайт в магазе
            GetComponent<Image>().color = Color.black;

            //Активировать предмет
            objectOnScene.SetActive(true);

            isPurchased = true;
            gameManager.Score -= itemPrice;
        }
    }

    public void OnBottleShopItemButtonClicked()
    {
        throw new NotImplementedException();
    }

    private bool CheckForMoney()
    {
        if (gameManager.Score >= itemPrice)
        {
            return true;
        }
        else return false;
    }
}
