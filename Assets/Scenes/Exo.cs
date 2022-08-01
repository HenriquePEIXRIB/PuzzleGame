using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exo : MonoBehaviour
{

    [SerializeField] float _positiony;
   


    public void Start()
    {

        

    }

    public void Update()
    {


        //Debug.Log(transform.position);

        if(transform.position.y < _positiony)
        {
            GameObject.Destroy(gameObject);
        }

       



    }


}
