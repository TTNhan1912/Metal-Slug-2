using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomItems : MonoBehaviour
{
    public List<GameObject> items;
    private Vector2 shutdownPosition;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // trúng đạn
        if (collision.gameObject.CompareTag("BulletPistol"))
        {
            // Lưu vị trí của quái vật trước khi bị hủy
            shutdownPosition = transform.position;

            // Kiểm tra xem danh sách prefab có phần tử hay không
            if (items.Count > 0)
            {
                // Chọn một prefab ngẫu nhiên từ danh sách
                int randomIndex = Random.Range(0, items.Count);
                GameObject randomPrefab = items[randomIndex];

                // Tạo một phiên bản của prefab ngẫu nhiên tại vị trí quái vật bị hủy
                Instantiate(randomPrefab, shutdownPosition, Quaternion.identity);
            }
        }
    }
    
}
