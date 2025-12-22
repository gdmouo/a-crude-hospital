using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrack_01 : TrackMap
{
    public override List<ProjBeat> GetBeatMap()
    {
        List<ProjBeat> beatMap = new()
        {
            new ProjBeat(1f, Dir.urp),
            new ProjBeat(2f, Dir.durn),
            new ProjBeat(3f, Dir.lurft),
            new ProjBeat(4f, Dir.rut),
            new ProjBeat(5f, Dir.urp),
            new ProjBeat(6f, Dir.durn),
            new ProjBeat(7f, Dir.lurft)
        };

        return beatMap;
    }
}
