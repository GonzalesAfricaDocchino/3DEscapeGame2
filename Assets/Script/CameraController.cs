using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // �J������Y�������ɉ�]�����郁�\�b�h
    // �{�^����ʂ��ČĂяo��
    public void RotateCamera(float angle)
    {
        if(angle == 0)
        {
            return;
        }

        cameraTransform.localRotation = Quaternion.Euler(Vector3.up * angle) * cameraTransform.localRotation;
    }
}
