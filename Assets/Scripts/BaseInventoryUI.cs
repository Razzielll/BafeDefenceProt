using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseInventoryUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinCountBase;
    [SerializeField] BaseInventory baseInventory;
    private void OnEnable()
    {
        baseInventory.OnCounCountChangeBase += UpdateCoinOnBase;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateCoinOnBase();
    }
    void UpdateCoinOnBase()
    {
        coinCountBase.text = "Coins On Base: " + baseInventory.GetCoinCountOnBase().ToString();
    }
}
