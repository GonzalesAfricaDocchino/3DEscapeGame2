using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] Texture2D defaultCursor;
    [SerializeField] Texture2D interactCursor;

    Camera mainCamera;
    RaycastHit hit;

    void Start()
    {
        mainCamera = Camera.main;

        SetCursor(true);
    }

    void Update()
    {
        // マウスが左クリックされたら
        if (Input.GetMouseButtonDown(0))
        {
            return;
        }
        CastRay();
    }

    void OnDisable()
    {
        SetCursor(true);
    }

    // マウスカーソルの位置から「Ray」を飛ばして、何かのコライダーに当たるかどうか
    void CastRay()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
        {
            SetCursor(false);
        }
        else
        {
            SetCursor(true);
        }
    }

    public void SetCursor(bool isDefault)
    {
        if (isDefault)
        {
            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(interactCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}
