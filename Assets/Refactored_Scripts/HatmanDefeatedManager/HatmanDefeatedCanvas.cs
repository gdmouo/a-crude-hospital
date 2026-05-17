using TMPro;
using UnityEngine;

public class HatmanDefeatedCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private TextMeshProUGUI currentRoomText;
    [SerializeField] private TextMeshProUGUI playerStatusText;
    [SerializeField] private TextMeshProUGUI hatmanChosenRoomText;
    [SerializeField] private GameObject visualParent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        visualParent.SetActive(true);

    }
    public void UpdateStatus(string s)
    {
        statusText.text = s;
    }

    public void UpdateCounter(float f)
    {
        counterText.text = f.ToString();
    }
    public void UpdatePlayerRoom(int f)
    {
        currentRoomText.text = "Player current room: " + f.ToString();
    }

    public void UpdatePlayerStatus(string s)
    {
        playerStatusText.text = s;
    }
    public void UpdateHatmanSelectedRoom(int f)
    {
        hatmanChosenRoomText.text = "Hatman selected room: " + f.ToString();
    }

    public void ClearHatmanSelectedRoom()
    {
        hatmanChosenRoomText.text = string.Empty;
    }
}
