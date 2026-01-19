using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayGameManager : MonoBehaviour
{
    public static HallwayGameManager Instance { get; private set; }

    [SerializeField] private GameObject hatman;
    [SerializeField] private GameObject hallwayGameTrigger;

    private LoopStep loopStep;
    //private LoopStepFactory lsFactory;


    //case where player finds battlebox at the very end
    [SerializeField] private int loopMax = 13;
        //NUM_END_LOOP + NUM_HIDE_LOOPS + NUM_SEEK_LOOPS - 1;
    
    private int loopCount = 0;

    private bool gameBegun = false;

    public int LoopIndex { get { return loopCount; } }
    public int LoopMax { get { return loopMax; } }

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        LoopStepFactory lsFactory = new LoopStepFactory(LoopStepLabel.Hide);
        loopStep = lsFactory.GetLoopStep();
        HallwayGameCanvasManager.Instance.SetStepIndexText(loopCount.ToString() + "/" + loopMax.ToString());
    }

    // Update is called once per frame
    //loopcounti ncreased everytime a loopstep is created
    void Update()
    {
        if (gameBegun)
        {
            if (loopStep != null && loopCount <= loopMax)
            {
                if (loopStep.UpdateFunction())
                {
                    LoopStepLabel l = loopStep.GetNextStep();
                    LoopStepFactory lsFactory = new LoopStepFactory(l);
                    loopStep = lsFactory.GetLoopStep();
                    HallwayGameCanvasManager.Instance.SetStepIndexText(loopCount.ToString() + "/" + loopMax.ToString());
                    //Debug.Log(loopCount);
                }
            } 
        }
    }

    public void BeginGame()
    {
        gameBegun = true;
    }

    public void IncLoopCount()
    {
        loopCount++;
    }

    public void EnableKeyObjects()
    {
        hatman.SetActive(true);
        hallwayGameTrigger.SetActive(true);
    }

    public void IncLoopMax()
    {
        loopMax++;
    }
}


