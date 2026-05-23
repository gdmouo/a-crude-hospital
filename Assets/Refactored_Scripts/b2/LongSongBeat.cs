using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LongSongBeat : BeatProjectile
{
    [SerializeField] private GameObject beatTail;
    [SerializeField] private float tailY;

    public override void Init(Note note, Vector3 spawnPos, Vector3 targetPos)
    {
        base.Init(note, spawnPos, targetPos);
        tailY = (float) (movementSpeed * note.GetBeatFlyTime());
    }
    public override void Shoot()
    {
        Vector3 tailPos = new Vector3(transform.position.x, tailY, transform.position.z);
        beatTail.transform.position = tailPos;
        base.Shoot();
    }
}


