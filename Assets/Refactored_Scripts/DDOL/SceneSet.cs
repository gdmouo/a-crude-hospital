using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSet : MonoBehaviour
{
    private SceneToGo sceneToGo;
    public static SceneSet Instance { get; private set; }
    public Mission01StageLabel CurrentStage;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMissionStageForReturn(Mission01StageLabel m)
    {
        CurrentStage = m;
    }

    public void LoadBeatLevel(SongTitle sTitle)
    {
        switch (sTitle)
        {
            case SongTitle.Beaty:
                sceneToGo = SceneToGo.BeatRoom;
                break;
        }
    }

    public void LoadMission()
    {
        sceneToGo = SceneToGo.Mission_01;
    }

    public void SwitchRoom()
    {
        SceneManager.LoadScene(sceneToGo.ToString());
    }
}