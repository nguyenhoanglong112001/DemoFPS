using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
    public Animator anim;
    public Rigidbody[] rigids;

    [ContextMenu("Retrieve Rigibodies")]
    private void RetrieveRigibodies()
    {
        rigids = GetComponentsInChildren<Rigidbody>();
    }

    [ContextMenu("Clear Ragdoll")]
    private void ClearRagdoll()
    {
        CharacterJoint[] joint = GetComponentsInChildren<CharacterJoint>();
        for (int i = joint.Length-1; i>0;i--)
        {
            DestroyImmediate(joint[i]);
        }

        Rigidbody[] rigidlist = GetComponentsInChildren<Rigidbody>();
        for (int i = rigidlist.Length-1; i >0; i--)
        {
            DestroyImmediate(rigidlist[i]);
        }    
        Collider[] colls = GetComponentsInChildren<Collider>();
        for (int i = colls.Length-1; i >0; i++)
        {
            DestroyImmediate(colls[i]);
        }
    }

    [ContextMenu("Enable Ragdoll")]
    public void EnableRagdoll() => SetRagdoll(true);

    [ContextMenu("Disable Ragdoll")]
    public void DisabeRagdoll() => SetRagdoll(false);

    private void SetRagdoll(bool ragdollEnable)
    {
        anim.enabled = !ragdollEnable;
        for (int i = 0;i<rigids.Length;i++)
        {
            rigids[i].isKinematic = !ragdollEnable;
        }
    }

    [ContextMenu("Add HitSurface")]
    private void AddHitSurFace()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach(Collider col in colliders)
        {
            if(gameObject.GetComponent<HitSurface>() == null)
            {
                var hitsurface = col.gameObject.AddComponent<HitSurface>();
                hitsurface.surfaceType = HitSurfaceType.Blood;
            }
        }
    }
}
