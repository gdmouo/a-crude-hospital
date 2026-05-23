using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    [SerializeField] private PadLabel padLabel;
    [SerializeField] private GameObject target;
    public PadLabel Label { get { return padLabel; } }

    private const float BEAT_LIFETIME = 15f;

    public void FireBeat(GameObject beatProjectile, Note note)
    {
        GameObject temp = Instantiate(beatProjectile, transform.position, Quaternion.identity);
        temp.transform.SetParent(transform);

        BeatProjectile beatComponent = temp.GetComponent<BeatProjectile>();

        beatComponent.Init(note, transform.position, GetTarget().transform.position);
        beatComponent.Shoot();

        //Destroy(temp, BEAT_LIFETIME);
    }

    public GameObject GetTarget() { return target; }
}
