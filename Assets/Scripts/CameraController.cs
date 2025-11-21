using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; //referenciará la posición del objeto de juego del jugador
    private Vector3 offset; //establecerá la posición de desplazamiento desde el jugador a la cámara
    
    // Start se llama una vez antes de la primera ejecución de Update después de crear el MonoBehaviour
    void Start()
    {
        //calcula la posición de desplazamiento entre la cámara y el jugador al inicio del juego
        //resta la posición del jugador de la de la cámara
        offset = transform.position - player.transform.position;
        
    }

    // Update se llama una vez por frame
    void Update()
    {
        //establece la cámara donde está el jugador más el desplazamiento definido arriba
        transform.position = player.transform.position + offset;
    }
}
