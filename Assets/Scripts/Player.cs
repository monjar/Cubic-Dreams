using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;

    public HealthBar healthBar;
    public ColorPanel colorPanel;

    public new Camera camera;

    public List<GameObject> hitBoxes;
    public List<string> hints;

    // Start is called before the first frame update
    private void Start()
    {
        hitBoxes = new List<GameObject>();
        this.health = 100;
        healthBar.setMaxHealth(this.health);
        this.camera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PortalDoor"))
            InteractWithPortal();
    }

    // Update is called once per frame
    private void Update()
    {
        HandleInteractTry();
    }

    private void HandleInteractTry()
    {
        if (PressedInteract())
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (CanActivate(ray, out GameObject hitObject))
                HandleObjectHit(hitObject);
        }
    }

    private void HandleObjectHit(GameObject hitObject)
    {
        if (HitLightBox(hitObject))
            InteractWithBox(hitObject);
        else if (HitTome(hitObject))
            InteractWithTome(hitObject);
    }

    private static bool PressedInteract()
    {
        return Input.GetMouseButtonDown(1) ||
               (Application.platform == RuntimePlatform.Android && Input.GetMouseButtonDown(0));
    }

    private void InteractWithPortal()
    {
        var gm = GameManager.GetInstance();
        if (gm.IsOrdered(this.hitBoxes)) // The boxes are in order. so, hurray @_@.
            gm.WinGame();
        else // The boxes are not in order. so, something bad happens.//TODO
            print("SOMETHING BAD...");
    }

    private void InteractWithTome(GameObject tomeObject)
    {
        tomeObject.TryGetComponent(out Tome tome);
        if (!tome.IsSeen())
        {
            hints.Add(tome.GetHint());
            print(tome.GetHint());
        }
    }

    private void InteractWithBox(GameObject boxObject)
    {
        boxObject.TryGetComponent(out LightHandler lightBox);
        if (lightBox.IsActive())
        {
            lightBox.DeActivate();
            this.hitBoxes.Remove(boxObject);
        }
        else
        {
            lightBox.Activate();
            this.hitBoxes.Add(boxObject);
        }

        List<Color> colors = new List<Color>();
        foreach (var box in hitBoxes)
        {
            box.TryGetComponent(out Renderer boxRenderer);
            colors.Add(boxRenderer.material.color);
        }

        colorPanel.ChangeColors(colors);
        print("hit: " + lightBox.light.intensity);
    }

    private bool CanActivate(Ray ray, out GameObject hitObject)
    {
        bool flag = hitSomething(ray, out var hit)
                    && IsNear(hit)
                    && IsInLevel(hit);
        hitObject = flag ? hit.transform.gameObject : null;
        return flag;
    }

    private bool hitSomething(Ray ray, out RaycastHit hit)
    {
        return Physics.Raycast(ray, out hit);
    }

    private bool HitTome(GameObject go)
    {
        return go.name.StartsWith("Tome");
    }

    private bool HitLightBox(GameObject go)
    {
        return go.name.Contains("Box");
    }

    private bool HitPortal(GameObject go)
    {
        return go.name.StartsWith("Portal");
    }

    private bool IsNear(RaycastHit hit)
    {
        return HorizontalDist(hit.transform.position, transform.position) < 1.3f;
    }

    private bool IsInLevel(RaycastHit hit)
    {
        var yPlayer = transform.position.y;
        var yObject = hit.transform.position.y;
        return Mathf.Abs(yPlayer - yObject) < 1 &&
               yPlayer <= yObject;
    }


    private float HorizontalDist(Vector3 pos1, Vector3 pos2)
    {
        return Mathf.Sqrt(Mathf.Abs(pos1.x - pos2.x) + Mathf.Abs(pos1.z - pos2.z));
    }

    public void DealDamage(float damage)
    {
        this.health -= damage;
        healthBar.setHealth(this.health);
        if (health <= 0)
            GameManager.GetInstance().GameOver();
    }

    public bool IsAlive()
    {
        return health > 0;
    }
}