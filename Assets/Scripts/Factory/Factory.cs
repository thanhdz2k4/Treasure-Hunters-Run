using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory : MonoBehaviour
{
    public abstract IProduct GetProduct(Transform position);

}
