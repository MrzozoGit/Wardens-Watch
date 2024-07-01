using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float _panSpeed = 20f;
    [SerializeField] private float _zoomSpeed = 20f;
    [SerializeField] private float _minZoom = 2f;
    [SerializeField] private float _maxZoom = 20f;
    private float _currentZoom;

    private void Start()
    {
        _currentZoom = Camera.main.orthographicSize;
    }

    void Update()
    {
        Zoom();
        Move();
    }

    void Move()
    {
        // Initialiser le vecteur de mouvement
        Vector3 move = Vector3.zero;

        // Détecter les entrées utilisateur et accumuler le vecteur de mouvement
        if (Input.GetKey("w"))
        {
            move += new Vector3(0.5f, 0, 0.5f);
        }
        if (Input.GetKey("s"))
        {
            move += new Vector3(-0.5f, 0, -0.5f);
        }
        if (Input.GetKey("a"))
        {
            move += new Vector3(-0.5f, 0, 0.5f);
        }
        if (Input.GetKey("d"))
        {
            move += new Vector3(0.5f, 0, -0.5f);
        }

        // Normaliser le vecteur de mouvement pour des vitesses constantes
        if (move != Vector3.zero)
        {
            move.Normalize();
        }

        // Appliquer le mouvement à la caméra
        transform.Translate((_currentZoom / 5) * _panSpeed * Time.deltaTime * move, Space.World);
    }

    void Zoom()
    {
        // Zoom de la caméra
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        _currentZoom -= scroll * _zoomSpeed * 100f * Time.deltaTime;
        _currentZoom = Mathf.Clamp(_currentZoom, _minZoom, _maxZoom);
        Camera.main.orthographicSize = _currentZoom;
    }
}
