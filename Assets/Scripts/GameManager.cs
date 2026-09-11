using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public ClickableBase HoveredClickable { get; private set; }

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
}
