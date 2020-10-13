using System.Collections.Generic;
using UnityEngine;

public class Folk : MonoBehaviour
{
    private Personality personality;
    private GameObject target;
    private Vector3 direction;

    public GameObject house = null;
    public float moveSpeed = 5f;
    public GameData gameData = null;

    public FolkState folkState = FolkState.Idle;
    private List<ActionNode> actionQueue;

    private struct ActionNode
    {
        float duration;
        Vector3 direction;
        float distance;

        public float getVector(float dt, ref Vector3 vectRef)
        {
            vectRef = new Vector3(direction.x, direction.y, direction.z);

            float dd = distance / duration;

            duration -= dt;

            if (duration < 0f)
            {
                vectRef *= distance;
                return -duration;
            }

            vectRef *= dd * dt;
            return 0f;
        }
    }
    
    public enum FolkState
    {
        Idle,
        Wandering,
        Travelling
    }

    void Start()
    {
        actionQueue = new List<ActionNode>();
        personality = new Personality();
    }
    
    void Update()
    {
        float dt = Time.deltaTime;

        //Process state
        switch (this.folkState)
        {
            default:
            case FolkState.Idle:
                idleState(dt);
                break;

            case FolkState.Wandering:
                wanderingState(dt);
                break;

            case FolkState.Travelling:
                travellingState(dt);
                break;

        }

        //Process actions

        Vector3 vect = new Vector3();

        float d = dt;
        while (actionQueue.Count > 0 && d > 0f)
        {
            ActionNode an = actionQueue[0];
            
            d = an.getVector(d, ref vect);

            transform.position += transform.TransformVector(vect);

            if (d > 0f) actionQueue.Remove(an);
        }
    }

    private float iT = 0f;
    private const float idleTime = 5f;

    private void idleState(float dt)
    {
        print("Idle state");

        iT += dt;
        for (; iT >= idleTime; iT -= idleTime)
        {

        }
    }

    private float wT = 0f;
    private const float wanderTime = 10f;

    private void wanderingState(float dt)
    {
        print("Wandering state");

        wT += dt;
        for (; wT >= wanderTime; wT -= wanderTime)
        {
            //Pick a direction
            int d = Random.Range(0, 8);

            switch (d)
            {
                default:
                case 0:
                    direction = new Vector3(0f, 0f, 1f);
                    break;

                case 1:
                    direction = new Vector3(0.707f, 0f, 0.707f);
                    break;

                case 2:
                    direction = new Vector3(1f, 0f, 0f);
                    break;

                case 3:
                    direction = new Vector3(0.707f, 0f, -0.707f);
                    break;

                case 4:
                    direction = new Vector3(0f, 0f, -1f);
                    break;

                case 5:
                    direction = new Vector3(-0.707f, 0f, -0.707f);
                    break;

                case 6:
                    direction = new Vector3(-1f, 0f, 0f);
                    break;

                case 7:
                    direction = new Vector3(-0.707f, 0f, 0.707f);
                    break;

            }
        }
    }

    private float tT = 0f;
    private const float travelTime = 20f;

    private void travellingState(float dt)
    {
        print("Travelling state");

        tT += dt;
        for (; tT >= travelTime; tT -= travelTime)
        {

        }
    }

    public class Personality
    {
        public float curiosity;
        public float scrutiny;
        public float resillience;
        public float honesty;
        public float extroversion;
        
        public Personality()
        {
            curiosity    = Random.Range(0f, 10f);
            scrutiny     = Random.Range(0f, 10f);
            resillience  = Random.Range(0f, 10f);
            honesty      = Random.Range(0f, 10f);
            extroversion = Random.Range(0f, 10f);
        }

    }

}
