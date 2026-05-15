using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraTransitions : MonoBehaviour
{
    private CameraControl CamController;
    [SerializeField] private Vector3 InMainMenuPosition; 
    [SerializeField] private Quaternion InMainMenuRotation;
    [Space]
    [SerializeField] private Vector3 InGamePosition;
    [SerializeField] private Quaternion InGameRotation;

    private void Awake()
    {
        CamController = GetComponent<CameraControl>();
    }

    private void Start()
    {
        SwitchMainMenuView();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            SwitchMainMenuView();
        if(Input.GetKeyDown(KeyCode.Alpha2))
            SwitchInGameView();
    }

    public void SwitchMainMenuView()
    {
        StartCoroutine(ChangingRotationAndRotation(InMainMenuPosition, InMainMenuRotation));
        CamController.AdjustPitch(InMainMenuRotation.eulerAngles.x);
    }

    // Switches the camera into gameplay view
    public void SwitchInGameView()
    {
        // Starts smooth camera transition
        StartCoroutine(ChangingRotationAndRotation(InGamePosition, InGameRotation));
        // Updates camera pitch rotation
        CamController.AdjustPitch(InGameRotation.eulerAngles.x);
    }

 private IEnumerator ChangingRotationAndRotation(Vector3 TargetPosition, Quaternion TargetRotation, float duration = 3, float delay = 0)
    {
        yield return new WaitForSeconds(delay);

        CamController.EnableCameraControlls(false);

        float time = 0;

        Vector3 StartPosition = transform.position;
        Quaternion StartRotation = transform.rotation;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(StartPosition, TargetPosition, time / duration);
            transform.rotation = Quaternion.Lerp(StartRotation, TargetRotation, time / duration);

            time += Time.deltaTime;
            yield return null;
        }

        transform.position = TargetPosition;
        transform.rotation = TargetRotation;
        CamController.EnableCameraControlls(true);
    }

}
