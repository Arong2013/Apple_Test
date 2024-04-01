using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class AppleObj : MonoBehaviour
{
    [SerializeField] AppleData appleData; public AppleData AppleData => appleData;

    Rigidbody2D rigidbody2D;  
    private Vector3 screenPoint;
    private float offsetX;

    bool isDragable = true;
    private bool ismoveAble = true; public bool IsMoveable => ismoveAble;   
    private bool isCrash = false;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        if(this == GameManager.Instance.CunObj)
           rigidbody2D.gravityScale = 0;
        else
        {
            ismoveAble = false;
            isDragable = false;
        }    
    }

    void OnMouseDown()
    {
        if (ismoveAble)
        {
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offsetX = Input.mousePosition.x - screenPoint.x;
        }
    }

    void OnMouseUp()
    {
        rigidbody2D.gravityScale = 5f;
        isDragable = false;
    }

    void OnMouseDrag()
    {
        if (ismoveAble || isDragable)
        {
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);
            rigidbody2D. MovePosition(new Vector2(currentPosition.x, transform.position.y));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("SideWall"))
        {
            isDragable = false;
        }
        // 2D 충돌 감지
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.GetComponent<AppleObj>())
        {
            ismoveAble = false;
        }

        if (collision.gameObject.TryGetComponent<AppleObj>(out AppleObj component) && !ismoveAble && !isCrash)
        {
            if(component.appleData == appleData)
            {
                this.isCrash = true;
                component.isCrash = true;
                var pos = collision.contacts;
                var posc = pos[Random.Range(0, pos.Length)];
                GameManager.Instance.AddScore(this,posc.point);
                Destroy(this.gameObject);
                Destroy(component.gameObject);
            }
        }
    }
}