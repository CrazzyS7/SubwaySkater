using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject[] mSanRings;
    public Material mUnsafeColor;
    public Material mSafeColor;
    public GameObject[] mWings;
    public GameObject mRing;

    private readonly float mDistance = 5.0f;
    private readonly int mNumOFRings = 7;
    private float mYSpawn = 0;
    private int mUnsafe = 0;
    private int mHoles = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnInitFinal(0);
        for (int i = 0; i < mNumOFRings; i++)
        {
            SpawnRing();
        }
        mYSpawn -= mDistance;
        SpawnInitFinal(mSanRings.Length - 1);
        return;
    }

    // Update is called once per frame
    void Update()
    {
        return;
    }

    public void SpawnRing()
    {
        mHoles = Random.Range(2, 4);
        mUnsafe = 6 - mHoles;
        mYSpawn -= mDistance;
        GenerateRing(mUnsafe, mHoles);
        GameObject ring = Instantiate(mRing, transform.up * mYSpawn, Quaternion.identity);
        ring.transform.SetParent(transform, false);
        ring.SetActive(true);
        return;
    }

    public void SpawnInitFinal(int _index)
    {
        GameObject ring = Instantiate(mSanRings[_index], transform.up * mYSpawn, Quaternion.identity);
        ring.transform.SetParent(transform, false);
        return;
    }

    public void GenerateRing(int _unsafe, int _holes)
    {
        foreach(GameObject wing in mWings)
        {
            wing.transform.GetComponent<MeshRenderer>().material = mSafeColor;
            wing.SetActive(true);
        }

        for (int i = 0; i < _unsafe; i++)
        {
            int randNum = Random.Range(0, mWings.Length);
            mWings[randNum].transform.GetComponent<MeshRenderer>().material = mUnsafeColor;
        }

        for(int i = 0; i < _holes; i++)
        {
            int randNum = Random.Range(0, mWings.Length);
            mWings[randNum].SetActive(false);
        }
        return;
    }
}
