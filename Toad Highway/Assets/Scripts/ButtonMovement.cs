using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    public RectTransform ButtonTransf;

    public float MoveSpeed = 6f;
    public float MoveQuantity = 5f;
    public float ScaleSpeed = 3f;
    public float ScaleQuantity = 0.3f;

    public Vector3 Scaling;

    private void Start()
    {
        ButtonTransf = GetComponent<RectTransform>();
        Scaling = ButtonTransf.localScale;
        MoveSpeed = Random.Range(1f, 2f);
        MoveQuantity = Random.Range(1f, 4f);
        ScaleSpeed = Random.Range(1f, 3f);
        ScaleQuantity = Random.Range(0.01f, 0.3f);
}
    void Update()
    {
        float wobble = Mathf.Sin(Time.time * MoveSpeed) * MoveQuantity;
        ButtonTransf.localRotation = Quaternion.Euler(0, 0, wobble);

        float scaler = Mathf.Sin(Time.time * ScaleSpeed) * ScaleQuantity + 1;
        ButtonTransf.localScale = Scaling * scaler;
    }

}
