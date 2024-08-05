using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzelFlash : MonoBehaviour
{
    public Transform muzzleImage;
    public float duration;
    // Start is called before the first frame update
    void Start() => HideMuzzle();

    private void HideMuzzle()
    {
        muzzleImage.gameObject.SetActive(false);
    }

    public void ShowMuzzle()
    {
        muzzleImage.gameObject.SetActive(true);
        float angle = Random.Range(0, 360f);
        muzzleImage.localEulerAngles = new Vector3(0, 0, angle);
        CancelInvoke();
        Invoke(nameof(HideMuzzle), duration);
    }
}
