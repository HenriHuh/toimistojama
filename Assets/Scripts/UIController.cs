using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Enums;

public class UIController : MonoBehaviour
{
    [SerializeField] private Transform itemButtonParent;
    [SerializeField] private GameObject buttonPrefab;
    public static UIController Instance { get; private set; }
    public CollectibleType Selected { get; private set; }

    private List<(GameObject obj, CollectibleItem item)> itemButtons = new ();

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

    public void AddItem(CollectibleItem item)
    {
        GameObject btn = Instantiate(buttonPrefab, itemButtonParent);
        btn.transform.GetChild(0).GetComponent<Image>().sprite = item.sprite;
        btn.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.name;
        btn.GetComponent<Button>().onClick.AddListener(() => SelectItem(item.type));
        itemButtons.Add((btn, item));

    }

    public void RemoveItem(CollectibleType type)
    {
        for (int i = 0; i < itemButtons.Count; i++)
        {
            if (itemButtons[i].item.type == type)
            {
                Destroy(itemButtons[i].obj);
                itemButtons.RemoveAt(i);
                if (Selected == type) Selected = CollectibleType.None;
                return;
            }
        }
    }

    private void SelectItem(CollectibleType type)
    {
        Selected = type;
    }
}
