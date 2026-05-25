using System.Collections.Generic;
using UnityEngine;

public class PadManager : MonoBehaviour
{
    [SerializeField] private List<Pad> pads;

    public static PadManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Pad GetPadByLabel(PadLabel p)
    {
        foreach (Pad b in pads)
        {
            if (b.Label == p) return b;
        }
        return null;
    }
}
