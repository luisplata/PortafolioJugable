using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class IntroduccionController : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    private float deltaTimeLocal;
    

    // Update is called once per frame
    void Update()
    {
        deltaTimeLocal += Time.deltaTime;
        if(deltaTimeLocal >= director.duration)
        {
            SceneManager.LoadScene(ServiceLocator.Instance.GetService<IConvertidorDeEnumToInt>().ConvertEnumToInt(EscenasDelJuego.NOVELAVISUAL));
        }
    }
}
