using UnityEditor;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject[] mSanRings;
    public Material mUnsafeColor;
    public Material mSafeColor;
    public GameObject[] mWings;
    public GameObject mRing;

    private readonly float mDistance = 5.0f;
    private readonly int mMaxUnsafe = 6;
    private readonly int mMinHoles = 2;
    private readonly int mMaxHoles = 4;
    //private int mNumOfRings = 7;
    private float mYSpawn = 0;
    private int mUnsafe = 0;
    private int mHoles = 0;

    public static int NumberOfRings
    { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        NumberOfRings = GameManager.CurrentLevelNum + 5;
        SpawnInitFinal(0);

        for (int i = 0; i < NumberOfRings; i++)
            SpawnRing();

        mYSpawn -= mDistance;
        SpawnInitFinal(mSanRings.Length - 1);
        return;
    }

    public void SpawnRing()
    {
        mHoles = Random.Range(mMinHoles, mMaxHoles);
        mUnsafe = mMaxUnsafe - mHoles;
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
        foreach(GameObject _wing in mWings)
        {
            _wing.transform.GetComponent<MeshRenderer>().material = mSafeColor;
            _wing.SetActive(true);
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
