using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Controller : MonoBehaviour
{
    float TTime = 0f;
    Apple_Apple Apple_State;

    private void Awake()
    {

        //사과 오브젝트마다 이펙트를 다르게 만들어줌
        //Apple_State = GetComponentInParent<Apple_Apple>();
        //Debug.Log((int)Apple_State.A_S * transform.localScale.x);
       // transform.localScale = new Vector3((int)Apple_State.A_S * transform.localScale.x, (int)Apple_State.A_S * transform.localScale.y, transform.localScale.z);
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
