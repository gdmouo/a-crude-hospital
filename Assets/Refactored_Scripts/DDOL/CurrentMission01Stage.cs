using UnityEngine;

public class CurrentMission01Stage : MonoBehaviour
{
    public Mission01StageLabel currentStage;
   // public static PersistentManager Instance { get; private set; }
    private void Awake()
    {
    }

    /*
    [SerializeField] private Mission01StageLabel currentStage;
    [SerializeField] private Mission01 mission01;
    [SerializeField] private bool enableStageBookmark;

    private bool stageSkippedTo = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!enableStageBookmark) return;
        if (stageSkippedTo) return;
        stageSkippedTo = true;

        mission01.SkipToStage(currentStage);
    }*/
}
