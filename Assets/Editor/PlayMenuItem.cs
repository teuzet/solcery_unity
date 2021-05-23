using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Grimmz.Editor
{
    public class PlayMenuItem : MonoBehaviour
    {
        [MenuItem("Grimmz/Play")]
        static async UniTask Play()
        {
            if (EditorApplication.isPlaying)
            {
                EditorApplication.ExitPlaymode();
                await UniTask.WaitUntil(() => !EditorApplication.isPlaying);
                await UniTask.Yield();
            }

            EditorSceneManager.OpenScene("Assets/_Main/_Main.unity");
            EditorApplication.EnterPlaymode();
        }
    }
}
