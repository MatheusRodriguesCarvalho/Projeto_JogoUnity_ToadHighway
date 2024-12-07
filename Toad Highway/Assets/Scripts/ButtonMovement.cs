using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    public RectTransform ButtonTransf;

    public float MoveSpeed = 0;
    public float MoveQuantity = 0;
    public float ScaleSpeed = 0;
    public float ScaleQuantity = 0;

    public Vector3 Scaling;

    private void Start()
    {
        ButtonTransf = GetComponent<RectTransform>();
        Scaling = ButtonTransf.localScale;
        MoveSpeed = Random.Range(1f, 2f);
        MoveQuantity = Random.Range(1f, 2f);
        ScaleSpeed = Random.Range(1f, 2f);
        ScaleQuantity = Random.Range(0.01f, 0.09f);
}
    void Update()
    {
        float oscilacao = Mathf.Sin(Time.time * MoveSpeed) * MoveQuantity;
        ButtonTransf.localRotation = Quaternion.Euler(0, 0, oscilacao);

        float escala = Mathf.Sin(Time.time * ScaleSpeed) * ScaleQuantity + 1;
        ButtonTransf.localScale = Scaling * escala;
    }

}
