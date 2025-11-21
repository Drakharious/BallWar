using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public TMP_Text countText;
    public TMP_Text levelText;
    public TMP_Text winTextLv1;
    public TMP_Text winText;
    public TMP_Text loseText;
    public Button nextLevelButton;
    public Button restartButton;
    private Rigidbody rb;
    public float speed = 20.0f;
    public float jumpForce = 5.0f;
    private int count;
    private bool canLose = false; //controla si el jugador puede perder

    //almacena el movimiento en x e y
    private float movementX;
    private float movementY;

    // Start se llama una vez antes de la primera ejecución de Update después de crear el MonoBehaviour
    void Start()
    {
        count = 0; //inicializa el contador en 0
        SetCountText(); //llama a la función SetCountText para actualizar el texto del contador al inicio del juego
        SetLevelText(); //muestra el nivel actual
        rb = GetComponent<Rigidbody>(); //asigna el componente rigidbody a rb
        if (winTextLv1 != null) winTextLv1.gameObject.SetActive(false); //asegura que el texto de victoria nivel 1 esté desactivado al inicio
        if (winText != null) winText.gameObject.SetActive(false); //asegura que el texto de victoria esté desactivado al inicio del juego
        loseText.gameObject.SetActive(false); //asegura que el texto de derrota esté desactivado al inicio del juego
        if (nextLevelButton != null) nextLevelButton.gameObject.SetActive(false); //oculta el botón de siguiente nivel al inicio
        restartButton.gameObject.SetActive(false); //oculta el botón de reinicio al inicio
        if (nextLevelButton != null) nextLevelButton.onClick.AddListener(LoadNextLevel); //asigna la función LoadNextLevel al botón
        restartButton.onClick.AddListener(RestartGame); //asigna la función RestartGame al botón
        Invoke("EnableLose", 3f); //activa la posibilidad de perder después de 3 segundos
    }
    
    void OnMove(InputValue movementValue) {
        //crea una variable vector 2 y almacena los valores de movimiento x e y en ella
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    
    void OnJump(InputValue jumpValue) {
        //aplica una fuerza hacia arriba cuando se presiona el botón de salto
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // FixedUpdate se llama una vez por frame de física
    void FixedUpdate()
    {
        //establece el movimiento en las variables x y z (mantiene y en 0)
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        
        //si el jugador cae por debajo de -10 en el eje Y, termina la partida
        if (transform.position.y < -10f)
        {
            GameOver();
        }
    }
    
    void EnableLose()
    {
        canLose = true; //permite que el jugador pueda perder
    }
    
    void GameOver()
    {
        loseText.gameObject.SetActive(true); //muestra el texto de derrota
        restartButton.gameObject.SetActive(true); //muestra el botón de reinicio
        Time.timeScale = 0; //pausa el juego
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            //incrementa el contador en 1 cada vez que se recoge un PickUp 
            count++;
            SetCountText(); //llama a la función SetCountText para actualizar el texto del contador
        }
        
        if (other.gameObject.CompareTag("Enemy") && canLose)
        {
            GameOver(); //termina la partida si toca un enemigo
        }
    }
    
    void SetCountText() 
    {
        countText.text = "Count: " + count.ToString();
        //si el contador es 12 o más, pasa al siguiente nivel o muestra victoria
        if (count >= 12) 
        {
            NextLevel();
        }
    }
    
    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        
        //si hay más niveles, muestra el botón de siguiente nivel
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            if (winTextLv1 != null) winTextLv1.gameObject.SetActive(true); //muestra el texto de victoria nivel 1
            if (nextLevelButton != null) nextLevelButton.gameObject.SetActive(true); //muestra el botón de siguiente nivel
            Time.timeScale = 0; //pausa el juego
        }
        else //si es el último nivel, muestra victoria
        {
            if (winText != null) winText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            Time.timeScale = 0; //pausa el juego
        }
    }
    
    void LoadNextLevel()
    {
        Time.timeScale = 1; //restaura el tiempo del juego
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex); //carga el siguiente nivel
    }
    
    void SetLevelText()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        levelText.text = "Nivel " + currentLevel;
    }
    
    void RestartGame()
    {
        Time.timeScale = 1; //restaura el tiempo del juego
        SceneManager.LoadScene(0); //carga el nivel 1 (primera escena)
    }
    

}
