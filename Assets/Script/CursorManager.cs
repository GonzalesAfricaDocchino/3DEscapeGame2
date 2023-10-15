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
        // �}�E�X�����N���b�N���ꂽ��
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

    // �}�E�X�J�[�\���̈ʒu����uRay�v���΂��āA�����̃R���C�_�[�ɓ����邩�ǂ���
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

    // �Ώۂ̃I�u�W�F�N�g�𒲂ׂ�
    /*void LookUpTargetObject()
    {
        if (targetObject == null)
        {
            return;
        }

        SetCursor(true);

        targetObject.GetComponent<InteractableObject>().LookUp();

        // �����ɂ���i���ׂĂ���Œ��ɕʂ̃I�u�W�F�N�g�𒲂ׂ邱�Ƃ��ł��Ȃ��悤�ɂ���j
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
