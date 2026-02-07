using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Condom : MonoBehaviour
{
    [SerializeField] private Dir keyButt;
    [SerializeField] private Vector2 detectorBoxSize;
    public Dir KeyButton { get { return keyButt; } }
    // Start is called before the first frame update

    private OldProjectile projectileTouching;
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collideersfjs();
    }

    public void Interact()
    {
        //Debug.Log(dir.ToString());
        if (projectileTouching != null)
        {
            //the great bojack jerk-off
            //he hates the troops
            float maxDist = detectorBoxSize.y + projectileTouching.ProjSize.y;
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

    private void Collideersfjs()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, detectorBoxSize, 0f);
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
        Gizmos.DrawWireCube(transform.position, detectorBoxSize);
    }

}

public enum Dir
{
    urp,
    durn,
    lurft,
    rut,
    Z,
    X,
    C,
    V,
    B,
    N,
    M
}
