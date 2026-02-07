using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private bool shootTriggered = false;

    [SerializeField] private Vector2 projSize = new(1f, 1f);
    public Vector2 ProjSize { get { return projSize; } }

    private float speed = 12f;
    private float lifetime = 10f;

    private Vector2 direction;

    [SerializeField] private float displacement;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    private void Start()
    {
        direction = Vector2.up;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (shootTriggered)
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        if (float.IsNaN(speed) || float.IsInfinity(speed))
        {
            return;
        }
        transform.position += (Vector3)(speed * Time.deltaTime * direction);
        /*
        if (target != null) {
            endPos = target.transform.position;
        }
        else
        {
            endPos = startPos;
        }
        transform.position = Vector3.Lerp(transform.position, endPos, travelDuration);
        */
    }

    public void SpawnNote(Vector2 dir, float time)
    {
        direction = dir;
        speed = displacement / time;
        shootTriggered = true;
        Destroy(gameObject, lifetime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, projSize);
    }
}
