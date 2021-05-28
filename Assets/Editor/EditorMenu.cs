using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Grimmz.Editor
{
    public class EditorMenu : MonoBehaviour
    {
        [MenuItem("Grimmz/Play")]
        static async UniTask Play()
        {
            await StopPlayingAndOpenScene("Assets/_Main/_Main.unity");
            EditorApplication.EnterPlaymode();
        }

        [MenuItem("Grimmz/Farm")]
        static async UniTask OpenFarmScene()
        {
            await StopPlayingAndOpenScene("Assets/Game/Farm/Farm.unity");
        }

        [MenuItem("Grimmz/Create")]
        static async UniTask OpenCreateScene()
        {
            await StopPlayingAndOpenScene("Assets/Game/Create/Create.unity");
        }

        [MenuItem("Grimmz/Sandbox")]
        static async UniTask OpenSandboxScene()
        {
            await StopPlayingAndOpenScene("Assets/Game/Sandbox/Sandbox.unity");
        }

        static async UniTask StopPlayingAndOpenScene(string scenePath)
        {
            if (EditorApplication.isPlaying)
            {
                EditorApplication.ExitPlaymode();
                await UniTask.WaitUntil(() => !EditorApplication.isPlaying && !EditorApplication.isCompiling);
                await UniTask.Yield();
            }

            EditorSceneManager.OpenScene(scenePath);
        }
    }
}
