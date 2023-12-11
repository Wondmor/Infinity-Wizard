using UnityEngine;
using Pathfinding;
public class PriestAi : Enemy
{
    [Header("Priest")]
    public float attackRange;
    public GameObject projectile;
    public int projectileNumber;
    public float projectileAngle;
    public float projectileRange;
    public float projectileSpeed ;
    private Transform shootPoint;
    void Start()
    {
        aiPath.endReachedDistance = attackRange;
        shootPoint = transform.Find("ShootPoint");
    }
    
 

    protected override void EnemyAttack()
    {
        animator.SetTrigger("attack");
        int medium = projectileNumber / 2;
        for (int i = 0; i < projectileNumber; i++)
        {
            GameObject bullet = ObjectPool.Instance.GetObject(projectile);
            bullet.transform.position = shootPoint.position;
            if (projectileNumber % 2 == 1)
            {
                bullet.transform.rotation = shootPoint.rotation * Quaternion.AngleAxis(projectileAngle * (i - medium), Vector3.forward);
            }
            else
            {
                bullet.transform.rotation = shootPoint.rotation * Quaternion.AngleAxis(projectileAngle * (i - medium) + projectileAngle/2, Vector3.forward);
            }
            
            bullet.GetComponent<Projectile>().speed = projectileSpeed;
            bullet.GetComponent<Projectile>().range = projectileRange;
            bullet.GetComponent<Projectile>().owner = gameObject;
        }
    }
}
