using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInput : InputMap
{
    public override InputMapType GetInputMapType()
    {
        return InputMapType.Dialogue;
    }

    protected override void OnDisableMap(PlayerInputActions p)
    {
    }

    protected override void OnEnableMap(PlayerInputActions p)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
