using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Controller : MonoBehaviour
{
    float TTime = 0f;
    Apple_Apple Apple_State;

    private void Awake()
    {

        //처음 생성될 때 사과 오브젝트 크기 가져와서 이펙트 스케일을 다르게 만들어줌
        if(gameObject.CompareTag("Effect_Merge"))
        {
            Apple_State = GetComponentInParent<Apple_Apple>();
            Debug.Log((int)Apple_State.A_S * transform.localScale.x);
            transform.localScale = new Vector3((int)Apple_State.A_S * transform.localScale.x, (int)Apple_State.A_S * transform.localScale.y, transform.localScale.z);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TTime += Time.deltaTime;
        if(TTime >1f)
        {
            Destroy(gameObject);
        }
    }

   



}
