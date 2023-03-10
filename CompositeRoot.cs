using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    
    [SerializeField] private CoinsPresenter _coinsPresenterTemplate;

    private CoinsPresenter _coinsPresenter;
    private Coins _coins;

    private void Awake()
    {
        _coins = new Coins(PlayerPrefs.GetInt("Coins", 0));
        _coins.OnValueChanged += OnCoinsAmountChanged;

        _coinsPresenter = Instantiate(_coinsPresenterTemplate);
        _coinsPresenter.OnCoinPickedup += _coins.PickupCoin;

    }

    private void OnCoinsAmountChanged(int newAmount)
    {   
        PlayerPrefs.SetInt("Coins", newAmount);
        _coinsPresenter.OnAmountChanged(newAmount);
    }
    

    



    
}
