using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatmanTriggerDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        /*
        if (other.gameObject.TryGetComponent<Triggerable>(out Triggerable b))
        {
            b.Interact(this);
        }*/

        //if inventory contains the music box, trigger

    }
}
