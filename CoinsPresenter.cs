using UnityEngine;
using UnityEngine.UI;
using System;

public class CoinsPresenter : MonoBehaviour
{   
    public Action OnCoinPickedup;
    [SerializeField] private Text _render;
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Coin"))
            OnCoinPickedup?.Invoke();
    }

    public void OnAmountChanged(int newAmount)
    {
        _render.text = $"Coins: {newAmount}";
        _animator.SetTrigger("OnPickupCoin");
    }
    




}