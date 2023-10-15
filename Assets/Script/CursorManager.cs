using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] Texture2D defaultCursor = null;
    [SerializeField] Texture2D interactCursor = null;

    Camera mainCamera;
    RaycastHit hit;
    GameObject targetObject;

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
            //LookUpTargetObject();
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
            targetObject = hit.collider.gameObject;

            SetCursor(false);
        }
        else
        {
            targetObject = null;

            SetCursor(true);
        }
    }

    // 対象のオブジェクトを調べる
    /*void LookUpTargetObject()
    {
        if (targetObject == null)
        {
            return;
        }

        SetCursor(true);

        targetObject.GetComponent<InteractableObject>().LookUp();

        // 無効にする（調べている最中に別のオブジェクトを調べることができないようにする）
        enabled = false;
    }*/

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
