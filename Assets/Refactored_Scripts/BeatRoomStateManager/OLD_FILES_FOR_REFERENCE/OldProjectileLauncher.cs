using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OldProjectileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private BeatPad targetPad;
    [SerializeField] private Dir direcrtion;
    [SerializeField] private Dir projectileAttacking;
    public Dir AttackingDir { get { return projectileAttacking; } }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new(targetPad.transform.position.x, transform.position.y, 0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireProjectile(float time)
    {
        GameObject temp = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        temp.transform.SetParent(OldProjectileParent.Instance.transform);
        temp.GetComponent<OldProjectile>().ShootGunn(direcrtion, time);
    }
}