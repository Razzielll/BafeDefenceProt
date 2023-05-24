using System;
using UnityEngine;

public class BaseInventory : MonoBehaviour
{
    public event Action OnCounCountChangeBase;

    int countCount=0;
    public void AddCoinToBase()
    {
        countCount++;
        OnCounCountChangeBase?.Invoke();
    }

    public void TakeCoinFromBase()
    {

        countCount--;
        OnCounCountChangeBase?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        Inventory inventory = other.GetComponent<Inventory>();
        if (inventory.GetCoinCountInventory()>0)
        {
            
            inventory.TakeCoin();
            AddCoinToBase();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        Inventory inventory = other.GetComponent<Inventory>();
        if (inventory.GetCoinCountInventory() > 0)
        {

            inventory.TakeCoin();
            AddCoinToBase();
        }
    }

    public int GetCoinCountOnBase()
    {
        return countCount;
    }
}
