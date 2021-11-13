using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBase : MonoBehaviour
{
    public Animator Human_Anim;
    public Rigidbody2D Human_RigBody;

    public HealthBase Health;
    private float Speed;

    // Start is called before the first frame update
    void Start()
    {
        Human_RigBody = GetComponent<Rigidbody2D>();
        //Set the speed of the GameObject
        Speed = 1.0f;
        Health = new HealthBase(30);
    }

    // Update is called once per frame
    void Update()
    {
        Human_RigBody.velocity = transform.right * Speed;
    }

    public void takeHealth(int h)
    {
        Health.takeHealth(h);
        if (Health.getHealth() <= 0)
        {
            Destroy(this);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Duck"))
        {
            Human_Anim.SetBool("humanColliding", true);
            Human_Anim.SetBool("humanAttacking", true);
            foreach (DuckBase g in col.gameObject.GetComponents<DuckBase>())
            {
                g.takeHealth(1);
            }
        }
        else
        {
            Human_Anim.SetBool("humanColliding", false);
            Human_Anim.SetBool("humanAttacking", false);
        }
    }
}
