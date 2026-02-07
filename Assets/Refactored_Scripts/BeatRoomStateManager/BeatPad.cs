using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatPad : MonoBehaviour
{
    [SerializeField] private KeyControlling keyControlling;
    [SerializeField] private Vector2 colliderSize;
    private SpriteRenderer spriteRenderer;
    public KeyControlling KeyButton { get { return keyControlling; } }

    private Color PadYellow;
    private Color PadWhite;
    // Start is called before the first frame update

    private Note noteColliding;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        PadYellow = new Color(1f, 1f, 0f, 1f);
        PadWhite = new Color(1f, 1f, 1f, 1f);
    }
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnCollide();
    }

    public void OnHold()
    {
        ToggleSprite(PadYellow);

        if (noteColliding != null)
        {
            //the great bojack jerk-off
            //he hates the troops

            float maxDist = colliderSize.y + noteColliding.ProjSize.y;
            float distToProj = Vector2.Distance(transform.position, noteColliding.gameObject.transform.position);
            float scale = Mathf.Min(Mathf.Abs(1f - (distToProj / maxDist)), 1f);
            float baseScore = 100f;
            float score = baseScore * scale;

            GameObject temp = noteColliding.gameObject;
            noteColliding = null;
            Destroy(temp);

            ScoreManager.Instance.UpdateScore(score);

            Debug.Log(score);
        }
    }

    public void OnReleased()
    {
        ToggleSprite(PadWhite);
    }

    private void OnCollide()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, colliderSize, 0f);
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.gameObject.TryGetComponent<Note>(out Note p))
            {
                noteColliding = p;
            }
        }

        if (hitColliders.Length == 0)
        {
            noteColliding = null;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, colliderSize);
    }

    private void ToggleSprite(Color c)
    {
        if (spriteRenderer != null && spriteRenderer.color != c)
        {
            spriteRenderer.color = c;
        }
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
