using UnityEngine;

public class Pad : MonoBehaviour
{
    [SerializeField] private PadLabel keyControlling;

    private Vector3 colliderSize;
    public PadLabel Label { get { return keyControlling; } }


    private BeatProjectile beatProjectileColliding;

    [SerializeField] private GameObject lightUpObject;

    private void Awake()
    {
        colliderSize = transform.localScale;
        // spriteRenderer = GetComponent<SpriteRenderer>();
        //  PadYellow = new Color(1f, 1f, 0f, 1f);
        // PadWhite = new Color(1f, 1f, 1f, 1f);
        //the great bojack jerk-off
        //he hates the troops
    }
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleCollisions();
    }

    public void OnHold()
    {
        ToggleLight(true);

        if (beatProjectileColliding != null)
        {

            float maxDist = colliderSize.y + beatProjectileColliding.ColliderSize.y;
            float distToProj = Vector3.Distance(transform.position, beatProjectileColliding.gameObject.transform.position);

            GameObject temp = beatProjectileColliding.gameObject;
            beatProjectileColliding = null;
            Destroy(temp);
        }
    }

    public void OnReleased()
    {
        ToggleLight(false);
    }

    private void HandleCollisions()
    {
        BeatProjectile thisColliding = null;
        Collider[] hitColliders = Physics.OverlapBox(
                transform.position,
                colliderSize * 0.5f
        );

        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.TryGetComponent<BeatProjectile>(out BeatProjectile b))
            {
                thisColliding = b;
                break;
            }
        }

        if (thisColliding == null)
        {
            beatProjectileColliding = null;
        } else
        {
            beatProjectileColliding = thisColliding;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, colliderSize);
    }

    private void ToggleLight(bool b)
    {
        if (lightUpObject.activeSelf != b)
        {
            lightUpObject.SetActive(b);
        }
    }
}
