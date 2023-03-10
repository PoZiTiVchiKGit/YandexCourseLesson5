using System;

public class Coins
{

    private int _amount;
    public Action<int> OnValueChanged;

    public Coins(int startAmount)
    {
        _amount = startAmount;
    }


    public void PickupCoin()
    {
        _amount++;
        OnValueChanged?.Invoke(_amount);
        
    }

    public bool TryDiscard(int price)
    {
        if (_amount < price)
            return false;
        _amount -= price;
        OnValueChanged?.Invoke(_amount);
        return true;
    }
}