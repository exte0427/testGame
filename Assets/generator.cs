using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    public class Info
    {
        public Vector2 pos;
        public Vector2 size;
        public float angle;
        public float mass;

        public Info(Vector2 pos_, Vector2 size_, float angle_, float mass_)
        {
            mass = mass_;
            pos = pos_;
            size = size_;
            angle = angle_;
        }
    }

    public abstract class Mass : MonoBehaviour
    {
        public abstract void onStart(Info info);
        public abstract void onUpdate();

        public Info info;
        public Rigidbody2D rigid;
    }

    public GameObject boxPrefab;

    public GameObject generateBox(BoxSetter boxInfo)
    {
        var myGo = Instantiate(boxPrefab);
        var setter = myGo.GetComponent<sizedBox>();
        setter.set(boxInfo);

        return myGo;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
