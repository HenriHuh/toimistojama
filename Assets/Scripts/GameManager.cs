using Enums;
using UnityEngine;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour
{
    [field: SerializeField] public SwingingMao SwingingMao { get; private set; }
    [field: SerializeField] public List<SubScene> Scenes { get; private set; }
    [field: SerializeField] public List<CollectibleItem> CollectibleItems { get; private set; }

    public static GameManager Instance { get; private set; }
    public ClickableBase HoveredClickable { get; private set; }
    public List<CollectibleType> collectibles { get; private set; } = new();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance != null)
        {
            Debug.LogError("Multiple game manager instances.");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void ClickableEnter(ClickableBase clickable)
    {
        HoveredClickable = clickable;
    }

    public void ClickableExit(ClickableBase clickable)
    {
        if (HoveredClickable == clickable)
        {
            HoveredClickable = null;
        }
    }

    public void AddCollectible(CollectibleType type)
    {
        collectibles.Add(type);
        CollectibleItem item = GetCollectible(type);
        UIController.Instance.AddItem(item);
    }

    public CollectibleItem GetCollectible(CollectibleType type)
    {
        for (int i = 0; i < CollectibleItems.Count; i++)
        {
            if (type == CollectibleItems[i].type) return CollectibleItems[i]; 
        }

        Debug.LogError("Can't find collectible " + type);
        return default;
    }

    public void ChangeScene(SceneType type)
    {
        for (int i = 0; i < Scenes.Count; i++)
        {
            Scenes[i].gameObject.SetActive(Scenes[i].Type == type);
        }
    }
}
