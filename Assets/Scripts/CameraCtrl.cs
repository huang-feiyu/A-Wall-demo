// An highlighted block

using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform target;
    private int speed = 2;
    private bool dragging = false;

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            CameraRotate();
        }

        CameraZoom();
    }

    private void CameraRotate()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = -Input.GetAxis("Mouse Y");
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.Translate(Vector3.left * (mouseX * 15f) * Time.deltaTime);
            transform.Translate(Vector3.up * (mouseY * 15f) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.RotateAround(target.transform.position, Vector3.up, mouseX * speed);
            transform.RotateAround(target.transform.position, transform.right, mouseY * speed);
        }
    }

    private void CameraZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            transform.Translate(Vector3.forward * 0.5f);
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            transform.Translate(Vector3.forward * -0.5f);
    }

    void OnGUI()
    {
        dragging = false;
        if (Event.current.type == EventType.MouseDrag)
        {
            dragging = true;
        }
    }
}
