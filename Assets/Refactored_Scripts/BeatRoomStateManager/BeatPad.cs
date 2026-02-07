using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatPad : MonoBehaviour
{
    [SerializeField] private KeyControlling keyControlling;
    [SerializeField] private Vector2 colliderSize;
    public KeyControlling KeyButton { get { return keyControlling; } }
    // Start is called before the first frame update

    private OldProjectile projectileTouching;
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnCollide();
    }

    public void Input()
    {
        //Debug.Log(dir.ToString());
        if (projectileTouching != null)
        {
            //the great bojack jerk-off
            //he hates the troops

            float maxDist = colliderSize.y + projectileTouching.ProjSize.y;
            float distToProj = Vector2.Distance(transform.position, projectileTouching.gameObject.transform.position);
            float scale = Mathf.Min(Mathf.Abs(1f - (distToProj / maxDist)), 1f);
            float baseScore = 100f;
            float score = baseScore * scale;

            GameObject temp = projectileTouching.gameObject;
            projectileTouching = null;
            Destroy(temp);

            ScoreManager.Instance.UpdateScore(score);

            Debug.Log(score);
        }
    }

    private void OnCollide()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, colliderSize, 0f);
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.gameObject.TryGetComponent<OldProjectile>(out OldProjectile p))
            {
                p.Touch();
                projectileTouching = p;
            }
        }

        if (hitColliders.Length == 0)
        {
            projectileTouching = null;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, colliderSize);
    }
}

public enum KeyControlling
{
    UP_ARR,
    DOWN_ARR,
    LEFT_ARR,
    RIGHT_ARR,
    W_KEY,
    A_KEY,
    S_KEY,
    D_KEY
}
