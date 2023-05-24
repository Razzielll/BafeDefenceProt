
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinCountInventory;
    [SerializeField] Inventory inventory;

    int countCount;
    // Start is called before the first frame update
    private void OnEnable()
    {
        inventory.OnCoinCountChange += UpdateCountCountInventory;
    }

    private void Start()
    {
        UpdateCountCountInventory();
    }

    void UpdateCountCountInventory()
    {
       coinCountInventory.text = "Couns in inventory: " + inventory.GetCoinCountInventory().ToString();
    }
}
