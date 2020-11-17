using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallerServiceLocator : MonoBehaviour
{
    private void Awake()
    {
        IConvertidorDeEnumToInt convertidor = new ConvertidorDeEnumToInt();
        ServiceLocator.Instance.RegisterService<IConvertidorDeEnumToInt>(convertidor);
    }
}
