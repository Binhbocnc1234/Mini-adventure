using UnityEngine;

public class SpringPlatform : MonoBehaviour
{
    public float bounceAmount = 0.2f; // Độ nhún của bậc thềm
    public float bounceSpeed = 3.0f; // Tốc độ hồi phục của bậc thềm sau khi nhún xuống

    private Vector3 initialPosition; // Vị trí ban đầu của bậc thềm
    private bool isBouncing = false;

    private void Start()
    {
        // Lưu vị trí ban đầu của bậc thềm
        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra xem đối tượng va chạm có phải là người chơi không
        if (collision.gameObject.CompareTag("Player"))
        {
            // Nếu người chơi đứng lên bậc thềm, bắt đầu nhún xuống
            StartCoroutine(BouncePlatform());
        }
    }

    private System.Collections.IEnumerator BouncePlatform()
    {
        isBouncing = true;

        // Nhún xuống
        Vector3 targetPosition = initialPosition + new Vector3(0, -bounceAmount, 0);
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, bounceSpeed * Time.deltaTime);
            yield return null;
        }

        // Hồi phục lại vị trí ban đầu
        while (transform.position != initialPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, bounceSpeed * Time.deltaTime);
            yield return null;
        }

        isBouncing = false;
    }
}
