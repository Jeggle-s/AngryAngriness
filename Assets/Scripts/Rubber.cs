using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubber : MonoBehaviour
{
    public Transform rubberBack;
    public Transform rubberFront;

    //Funktion zur Ausrichtung der Bänder zum Pivot des Steins
    void adjustRubber(Transform ball, Transform rubber)
    {
        //Anpassung Rotation
        Vector2 dir = rubber.position - ball.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rubber.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //Anpassung Länge
        float dist = Vector3.Distance(ball.position, rubber.position);
        dist += ball.GetComponent<Collider2D>().bounds.extents.x;
        rubber.localScale = new Vector2(dist, 1);
    }
    //Passe Bänder dem Stein an, solang dieser im Bereich der Schleider ist
    void OnTriggerStay2D(Collider2D collision)
    {
        adjustRubber(collision.transform, rubberBack);
        adjustRubber(collision.transform, rubberFront);
    }
    //Zurücksetzen der Bänder auf "default"
    private void OnTriggerExit2D(Collider2D collision)
    {
        rubberBack.localScale = new Vector2(0, 1);
        rubberFront.localScale = new Vector2(0, 1);
    }
}
