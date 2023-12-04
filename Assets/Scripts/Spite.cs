using UnityEngine;
public class Spite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // (1)
    public Sprite[] sprites; // (3)
    private int spriteIndex; // (4)
    private void Awake() // (2)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start() // (5)
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void AnimateSprite() // (6)
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
