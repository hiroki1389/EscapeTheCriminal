using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


namespace VarjoExample
{

    public class tairrotation : MonoBehaviour
    {
        public GameObject s;
        public Shoot shoot;
        public Quaternion rotation;
        public Quaternion move_rotation;
        public Vector3 rotatedVector;
        public float conpensate = 0.25f; 

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            /*
            
            s = GameObject.Find("Controller Right");
            shoot = s.GetComponent<Shoot>();
            move_rotation = shoot.controllerRotation;

            
            Vector3 vec3 = move_rotation.eulerAngles;

            vec3.x = 0;

            vec3.z = 0;
            

            vec3.y = vec3.y * conpensate;

            Quaternion qua = Quaternion.Euler(vec3);

            //rotatedVector = vec3 * testVector3;

            //Quaternion.Euler qua = Quaternion.Euler(rotatedVector);

            //rotation = this.transform.rotation;

            this.transform.rotation = qua;

            */
            
            

        }
    }
}
