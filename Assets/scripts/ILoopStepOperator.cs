using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoopStepOperator
{
    public LoopStepLabel GetNextStep();

    public void Meantime();
}
