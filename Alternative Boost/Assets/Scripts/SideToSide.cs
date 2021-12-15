using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class SideToSide : MonoBehaviour
{
    // increments for balanced and delayed movement
    int mover = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(mover == 0)
        {
            StartCoroutine(backAndForth());
        }    
    }

    IEnumerator backAndForth()
    {
        // =1
        mover++;

        // delay
        yield return new WaitForSeconds(1.5f);

        // back
        if (mover == 1)
        {
            GetComponent<Rigidbody>().AddForce(4.0f, 0.0f, 0.0f, ForceMode.Impulse);
        }

        // =2
        mover++;

        // delay
        yield return new WaitForSeconds(1.5f);

        // even
        if (mover == 2)
        {
            GetComponent<Rigidbody>().AddForce(-4.0f, 0.0f, 0.0f, ForceMode.Impulse);
        }

        // =3
        mover++;

        // delay
        yield return new WaitForSeconds(1.5f);

        // forth
        if (mover == 3)
        {
            GetComponent<Rigidbody>().AddForce(-4.0f, 0.0f, 0.0f, ForceMode.Impulse);
        }

        // =4
        mover++;

        // delay
        yield return new WaitForSeconds(1.5f);

        // even
        if (mover == 4)
        {
            GetComponent<Rigidbody>().AddForce(4.0f, 0.0f, 0.0f, ForceMode.Impulse);
        }

        // reset
        if (mover == 4)
        {
            mover = 0;
        }

        // delay
        yield return new WaitForSeconds(1.5f);
    }
}
