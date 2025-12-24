using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public static ResultManager Instance { get; private set; }
    [SerializeField] private GameObject endRoundVisuals;
    [SerializeField] private ResultButtonVisuals buttonVisuals;
    
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        //
        if (!endRoundVisuals.activeSelf)
        {
            buttonVisuals.ShowDaCorrectButton(ScoreManager.Instance.Passed(), ScoreManager.Instance.GetCurrentScore());
            endRoundVisuals.SetActive(true);
            
        }




        //
    }
}
