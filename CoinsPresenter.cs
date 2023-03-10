using UnityEngine;
using UnityEngine.UI;

public class CoinsPresenter : MonoBehaviour
{
    [SerializeField] private Text _render;
    [SerializeField] private Animator _animator;
    private Coins _coins;


    private void Awake()
    {
        _coins = new Coins(PlayerPrefs.GetInt("Coins", 0));
        _coins.OnValueChanged += OnAmountChanged;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Coin"))
            _coins.PickupCoin();
    }

    public void OnAmountChanged(int amount)
    {
        _render.text = $"Coins: {amount}";
        _animator.SetTrigger("OnPickupCoin");
        PlayerPrefs.SetInt("Coins", amount);
    }
    private void OnDestroy()
    {
        _coins.OnValueChanged -= OnAmountChanged;
    }

}
