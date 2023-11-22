using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Whiteboard : MonoBehaviour, IInteraction
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(2048, 2048);
    private Renderer _renderer;

    private int drawSize = 10;
    private int eraseSize = 25;
    private int writeSize = 10;

    private Color[] _writeColor;
    private Color[] _eraseColor;
    private Color[] _color;

    [SerializeField] public GameObject playerCamera;
    [SerializeField] public GameObject whiteBoardCamera;


    [SerializeField] public Camera _whiteBoardCamera;

    private bool lastTouch = false;
    private Vector2 lastPosition;
    private bool _active = false;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        _renderer.material.mainTexture = texture;
        _whiteBoardCamera = whiteBoardCamera.GetComponent<Camera>();

        _writeColor = Enumerable.Repeat(Color.black, writeSize * writeSize).ToArray();
        _eraseColor = Enumerable.Repeat(Color.white, eraseSize * eraseSize).ToArray();

        _color = _writeColor;

    }

    public GameObject GetAttachment()
    {
        return gameObject;
    }

    public void Interact()
    {
        _active = !_active;
        if (_active)
        {
            SwichPlayerCamera();
        }
        else
        {
            SwichPlayerCamera();
        }
    }

    public string GetInteractText()
    {
        if (_active)
        {
            return "End Draw on WhiteBoard";
        }
        return "Draw on WhiteBoard";
    }


    void SwichPlayerCamera()
    {
        playerCamera.SetActive(!_active);
        whiteBoardCamera.SetActive(_active);
    }

    public Transform GetTransform()
    {
        return transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Interact();
        }
        if (_active)
        {
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor while using the whiteboard
            Cursor.visible = true;
            Draw();
            if (Input.GetKeyDown(KeyCode.P))
            {
                _color = _eraseColor;
                drawSize = eraseSize;
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                _color = _writeColor;
                drawSize = writeSize;
            }
        }

    }



    void Draw()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = _whiteBoardCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit,20,64))
            {
                if (hit.collider.gameObject.name == "whiteboard")
                {
                    Vector2 textureCoord = hit.textureCoord;

                    int x = Mathf.RoundToInt(textureCoord.x * textureSize.x);
                    int y = Mathf.RoundToInt(textureCoord.y * textureSize.y);

                    if (x >= 0 && x < textureSize.x && y >= 0 && y < textureSize.y)
                    {
                        if (lastTouch)
                        {
                            DrawLine(lastPosition, new Vector2(x, y));
                        }
                        else
                        {
                            texture.SetPixel(x, y, Color.black);
                            lastTouch = true;
                        }

                        lastPosition = new Vector2(x, y);

                        texture.Apply();
                    }
                }
                else
                {
                    lastTouch = false;
                }
            }
        }

    }

    void DrawLine(Vector2 start, Vector2 end)
    {
        int steps = Mathf.Max(Mathf.Abs((int)(end.x - start.x)), Mathf.Abs((int)(end.y - start.y)));

        for (int i = 0; i <= steps; i++)
        {
            float t = i / (float)steps;
            int x = Mathf.RoundToInt(Mathf.Lerp(start.x, end.x, t));
            int y = Mathf.RoundToInt(Mathf.Lerp(start.y, end.y, t));

            texture.SetPixels(x, y, drawSize, drawSize, _color);
        }
    }


}
