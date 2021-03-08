using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCling : MonoBehaviour
{
    public LayerMask IgnoreLayers;

    private PlayerManager _playerManager;
    public Rigidbody2D CathObjects;
    public Image img;
    public HingeJoint2D HingeJoint;
    public float hover_time;
    public float recovery_time;
    //private float stamina = 1;
    public bool catched = false;
    private bool _iscatch;
    private void Start()
    {
        //_fixedjoint = gameObject.GetComponent<FixedJoint2D>();
        _playerManager = FindObjectOfType<PlayerManager>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (_iscatch)
            {
                if (img.fillAmount >= 0.001)
                    _iscatch = true;
                else
                    _iscatch = false;
            }
            else
            {
                if (img.fillAmount >= 0.2)
                    _iscatch = true;
                else                      
                    _iscatch = false;
            }
        }
        else
        {
            _iscatch = false;
        }
        if (catched)
        {
              img.fillAmount -= Time.deltaTime / hover_time;
        }
        else
        {
            img.fillAmount += Time.deltaTime / recovery_time;
        }
        //im.fillAmount = stamina;
        
    }

    private void FixedUpdate()
    {
            if (_iscatch)
            {
                Catch();
            }
            else
            {
                UnCatch();
            }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameobject = collision.gameObject;
        if (gameobject.layer == IgnoreLayers) return;

        Rigidbody2D rigidbody = collision.GetComponent<Rigidbody2D>();
        if (rigidbody == null) return;

        if (!catched || CathObjects == null)
        {
            CathObjects = rigidbody;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject gameobject = collision.gameObject;
        if (gameobject.layer == IgnoreLayers) return;

        Rigidbody2D rigidbody = collision.GetComponent<Rigidbody2D>();
        if (rigidbody == null) return;

        if (CathObjects == rigidbody/* && !catched*/)
        {
            CathObjects = null;
        }
    }

    public void Catch()
    {
        if (CathObjects != null)
        {
            catched = true;
            HingeJoint.connectedBody = CathObjects;
            HingeJoint.enabled = true;
        }
    }

    public void UnCatch()
    {
        catched = false;
        HingeJoint.enabled = false;
        HingeJoint.connectedBody = null;
    }
}
