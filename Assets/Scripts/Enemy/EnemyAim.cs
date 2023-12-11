using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    private GameObject player;

    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        player = GameObject.FindWithTag("Player");
        Vector2 playerPositon = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 thisgam = new Vector2(this.transform.position.x, this.transform.position.y);
        float angle = anglewhat(playerPositon, thisgam);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    
    private float anglewhat(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
