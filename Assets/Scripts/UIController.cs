using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Enums;
using System.Collections;

public class UIController : MonoBehaviour
{
    [SerializeField] private Transform itemButtonParent;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Color defaultButtonColor;
    [SerializeField] private Color highlightButtonColor;
    [SerializeField] private Transform dialogue;


    public static UIController Instance { get; private set; }
    public CollectibleType Selected { get; private set; }

    private List<(GameObject obj, CollectibleItem item)> itemButtons = new ();
    private Coroutine hideDialogueRoutine;

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

    public void ShowDialogue(string text)
    {
        dialogue.GetComponentInChildren<TextMeshProUGUI>().text = text;
        dialogue.gameObject.SetActive(true);
        dialogue.GetComponent<CanvasGroup>().alpha = 1;

        if (hideDialogueRoutine != null)
        {
            StopCoroutine(hideDialogueRoutine);
        }
        hideDialogueRoutine = StartCoroutine(HideDialogue());
    }

    private IEnumerator HideDialogue()
    {
        yield return new WaitForSeconds(3);

        for (float t = 0; t < 1; t+= Time.deltaTime * 2)
        {
            dialogue.GetComponent<CanvasGroup>().alpha = 1 - t;
            yield return null;
        }

        dialogue.gameObject.SetActive(false);
    }

    private void SelectItem(CollectibleType type)
    {
        Selected = type;
        for (int i = 0; i < itemButtons.Count; i++)
        {
            if (itemButtons[i].item.type == type)
            {
                itemButtons[i].obj.GetComponent<Image>().color = highlightButtonColor;
            }
            else
            {
                itemButtons[i].obj.GetComponent<Image>().color = defaultButtonColor;
            }
        }
    }

    public void UnSelect()
    {
        SelectItem(CollectibleType.None);
    }
}
