using UnityEngine;

public class BoxController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // Lấy kích thước của hình ảnh hiện tại trong Sprite Renderer
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        // Cập nhật kích thước của Box Collider 2D
        boxCollider.size = spriteSize;
    }
}