using System.Collections.Generic;
using UnityEngine;

public class BeatSpawnerManager : MonoBehaviour
{
    [SerializeField] private List<BeatSpawner> beatSpawners;
    [SerializeField] private GameObject defaultProjectilePrefab;
    [SerializeField] private GameObject longProjectilePrefab;

    public void PlayBeat(Note note)
    {
        
        BeatSpawner b = GetBeatSpawnerByLabel(note.TargetPad);

        b.FireBeat(NoteToProjectile(note), note);
    }

    private BeatSpawner GetBeatSpawnerByLabel(PadLabel p)
    {
        foreach (BeatSpawner b in beatSpawners)
        {
            if (b.Label == p) return b;
        }
        return null;
    }

    private GameObject NoteToProjectile(Note n)
    {
        switch (n.GetProjectileType()) {
            case BeatProjectileType.Long:
               // longProjectilePrefab.GetComponent<BeatProjectile>().Init(n, b.transform.position, b.GetTarget().transform.position);
                return longProjectilePrefab;
            case BeatProjectileType.Default:
              //  defaultProjectilePrefab.GetComponent<BeatProjectile>().Init(n, b.transform.position, b.GetTarget().transform.position);
                return defaultProjectilePrefab;
        }
        
        return null;
    }
}