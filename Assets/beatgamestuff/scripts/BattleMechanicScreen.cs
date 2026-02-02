using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMechanicScreen : MonoBehaviour
{
    public bool IsActivated {  get; private set; }
    [SerializeField] private GameObject visuals;
    public static BattleMechanicScreen Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        IsActivated = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        Testtogle();
        //IsActivated = !IsActivated;
        //visuals.SetActive(IsActivated);
        //GameInput.Instance.TogglePlayerControls(IsActivated);
        //GameInput.Instance.ToggleMouse(IsActivated);
    }

    private void Testtogle()
    {
        if (!visuals.activeSelf)
        {
            visuals.SetActive(true);
        }
       // GameInput.Instance.TogglePlayerControls(true);
       // GameInput.Instance.ToggleMouse(true);
    }
}
