using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.AI;

public class CreateEmployee : MonoBehaviour
{
    private static float probabilityIsMale = 0.55f;
    private static float probabilityHasHairMale = 0.8f;
    private static float probabiltyHasGlasses = 0.5f;
    private static float probabiltyHasFacialHair = 0.5f;

    [MenuItem("Assets/Create/TycoonGame/Generate Employee", priority = 50)]
    static void CreateNewEmployee()
    {
        GameObject charPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/EmptyCharPrefab.prefab");

        GameObject[] maleModels = GetAtPath<GameObject> ( "Models/_Characters/Male" );
        GameObject[] femaleModels = GetAtPath<GameObject> ( "Models/_Characters/Female" );
        GameObject[] facialHair = GetAtPath<GameObject> ( "Models/_Characters/Accessories/FacialHair" );
        GameObject[] glasses = GetAtPath<GameObject> ( "Models/_Characters/Accessories/Glasses" );
        GameObject[] maleHair = GetAtPath<GameObject> ( "Models/_Characters/Accessories/HairMale" );
        GameObject[] femaleHair = GetAtPath<GameObject> ( "Models/_Characters/Accessories/HairFemale" );

        GameObject newCharacter;
        bool isFemale = false;

        if ( Random.Range ( 0f, 1f ) < probabilityIsMale )
        {
            newCharacter = Instantiate ( maleModels [ Random.Range ( 0, maleModels.Length ) ] );
            isFemale = false;
        }
        else
        {
            newCharacter = Instantiate ( femaleModels [ Random.Range ( 0, femaleModels.Length ) ] );
            isFemale = true;
        }

        if ( !isFemale && Random.Range (0f,1f) < probabilityHasHairMale )
            Instantiate ( maleHair [ Random.Range ( 0, maleHair.Length ) ], newCharacter.transform, false ).transform.position = Vector3.zero;

        if ( isFemale )
            Instantiate ( femaleHair [ Random.Range ( 0, femaleHair.Length ) ], newCharacter.transform, false ).transform.position = Vector3.zero;

        if ( !isFemale && Random.Range ( 0f, 1f ) < probabiltyHasFacialHair )
            Instantiate ( facialHair [ Random.Range ( 0, facialHair.Length ) ], newCharacter.transform, false ).transform.position = Vector3.zero;

        if ( Random.Range ( 0f, 1f ) < probabiltyHasGlasses )
            Instantiate ( glasses [ Random.Range ( 0, glasses.Length ) ], newCharacter.transform, false ).transform.position = Vector3.zero;

        newCharacter.SetActive ( true );
        newCharacter.transform.position = new Vector3 ( Random.Range ( 0f, 20f ), 0, Random.Range ( 0f, 20f ) );

        //Copy Components
        CopyComponent(charPrefab.GetComponent<Animator>(), newCharacter);
        CopyComponent(charPrefab.GetComponent<NavMeshAgent>(), newCharacter);
        CopyComponent(charPrefab.GetComponent<Agent>(), newCharacter);
        CopyComponent(charPrefab.GetComponent<Worker>(), newCharacter);
    }

    static T CopyComponent<T> ( T original, GameObject destination ) where T : Component
    {
        System.Type type = original.GetType();
        var dst = destination.GetComponent(type) as T;
        if ( !dst ) dst = destination.AddComponent ( type ) as T;
        var fields = type.GetFields();
        foreach ( var field in fields )
        {
            if ( field.IsStatic ) continue;
            field.SetValue ( dst, field.GetValue ( original ) );
        }
        var props = type.GetProperties();
        foreach ( var prop in props )
        {
            if ( !prop.CanWrite || prop.Name == "name" || prop.Name == "destination" || prop.Name == "path" || prop.Name == "bodyPosition" || prop.Name == "bodyRotation" || prop.Name == "ikGoals" || prop.Name == "lookAt" || prop.Name == "playbackTime" ) continue;
            prop.SetValue ( dst, prop.GetValue ( original, null ), null );
        }
        return dst as T;
    }

    static T [ ] GetAtPath<T> ( string path )
    {

        ArrayList al = new ArrayList();
        string[] fileEntries = Directory.GetFiles(Application.dataPath + "/" + path);

        foreach ( string fileName in fileEntries )
        {
            int assetPathIndex = fileName.IndexOf("Assets");
            string localPath = fileName.Substring(assetPathIndex);

            Object t = AssetDatabase.LoadAssetAtPath(localPath, typeof(T));

            if ( t != null )
                al.Add ( t );
        }
        T[] result = new T[al.Count];
        for ( int i = 0 ; i < al.Count ; i++ )
            result [ i ] = ( T ) al [ i ];

        return result;
    }
}
