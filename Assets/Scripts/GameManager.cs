
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject RestartMenu;
    [SerializeField] Transform startingPosition;
    public static GameManager Instance { get; private set; }

    public event Action<bool> OnPlayerEnterBase;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one GameManager" + transform + "-" + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        playerController.OnAttackPatternChange += UpdatePlayerOnBase;
        playerController.GetComponent<Health>().OnDie += GameOver;
    }

    private void UpdatePlayerOnBase(bool isOnBase)
    {
        OnPlayerEnterBase?.Invoke(isOnBase);
    }

    public bool GetIsPlayerOnBase()
    {
        return playerController.GetInAttackMode();
    }
    void GameOver()
    {
        Time.timeScale = 0f;
        RestartMenu.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        playerController.SetInBase();
        playerController.GetComponent<Health>().ReplenishHealth();
        playerController.transform.position = startingPosition.position;
        playerController.GetComponent<Inventory>().ClearInventory();
    }
}
