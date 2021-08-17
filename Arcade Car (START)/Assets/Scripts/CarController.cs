using UnityEngine;

public class CarController : MonoBehaviour
{
    // Tốc độ của xe

    public float speed;
    public float turnSpeed;
    public float horizontalInput;

    public float forwardInput;

    void Start()
    {
        // Start dùng để khởi tạo trước lúc vào game

        speed = 10;
        turnSpeed = 30;
    }
    
    void Update()
    {
        // Cập nhật run-time trong game.
        
        // Lấy thông số khi nhấn vào nút trái/phải
        horizontalInput = Input.GetAxis("Horizontal");
        
        // Lấy thông số khi nhấn vào nút tiến/lùi
        forwardInput = Input.GetAxis("Vertical");
        
        // Di chuyển xe dựa vào forward input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
       
        // Xoay xe dựa vào horizon input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
