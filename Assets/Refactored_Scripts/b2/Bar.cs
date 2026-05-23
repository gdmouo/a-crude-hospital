using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField] private GameObject pulsePrefab;
    [SerializeField] private float pulseLifetime = 1.0f;
    [SerializeField] private bool pulseEnabled = false;
    public static Bar Instance {  get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Light()
    {
        if (pulsePrefab == null || !pulseEnabled) return;

        GameObject p = Instantiate(pulsePrefab, transform.position, transform.rotation, transform);
        p.transform.localPosition = new Vector3(0, 22f, 0);
        Destroy(p, pulseLifetime);
    }
}
