using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Vector2.zero;
        var kb = Keyboard.current;
        if (kb == null) return;

        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed) moveInput.x -= 1f;
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) moveInput.x += 1f;
        if (kb.sKey.isPressed || kb.downArrowKey.isPressed) moveInput.y -= 1f;
        if (kb.wKey.isPressed || kb.upArrowKey.isPressed) moveInput.y += 1f;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}

// була спроба додати крок через промінь і тд, але через не рівний лабіринт пакман рухається 
// дивно і цей апгрейд не дає результату який хотілось би, тому залишу стару версію 
// також нижче додам який код написав gemini про рух по крокам

/*public class PacmanGridMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction = Vector2.zero;
    private Vector2 nextDirection = Vector2.zero;
    
    public LayerMask wallLayer;

    void Update()
    {
        // Зчитуємо введення гравця (напрямок, куди він хоче повернути)
        var kb = Keyboard.current;
        if (kb != null)
        {
            if (kb.wKey.isPressed || kb.upArrowKey.isPressed) nextDirection = Vector2.up;
            if (kb.sKey.isPressed || kb.downArrowKey.isPressed) nextDirection = Vector2.down;
            if (kb.aKey.isPressed || kb.leftArrowKey.isPressed) nextDirection = Vector2.left;
            if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) nextDirection = Vector2.right;
        }

        // Рухаємо персонажа в поточному напрямку
        transform.Translate(direction * speed * Time.deltaTime);

        // Перевіряємо, чи можемо ми повернути у бажаному напрямку (nextDirection)
        if (nextDirection != direction)
        {
            // Робимо невеликий промінь (Raycast) вперед у новому напрямку, щоб перевірити стіну
            RaycastHit2D hit = Physics2D.Raycast(transform.position, nextDirection, 0.6f, wallLayer);
            if (hit.collider == null)
            {
                direction = nextDirection; // Якщо стіни немає — повертаємо туди!
            }
        }

        // Перевіряємо, чи не врізалися ми у стіну в поточному напрямку
        RaycastHit2D forwardHit = Physics2D.Raycast(transform.position, direction, 0.6f, wallLayer);
        if (forwardHit.collider != null)
        {
            direction = Vector2.zero;
        }
    }
}*/