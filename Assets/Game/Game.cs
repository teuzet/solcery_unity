using Cysharp.Threading.Tasks;
using Grimmz.FSM.Game;
using Grimmz.Utils;
using Grimmz.Modules.Wallet;
using Grimmz.Modules.CardCollection;
using Grimmz.WebGL;
using Grimmz.Modules.FightModule;
using UnityEngine;

namespace Grimmz
{
    public class Game : Singleton<Game>
    {
        public void Init()
        {
            UnityEngine.Debug.Log("Game Init");

            Wallet.Instance?.Init();
            CardCollection.Instance?.Init();
            FightModule.Instance?.Init();
            //var tstJson = "{\"Cards\":[{\"MintAdress\":\"HWVXywE79r8qMPYRYbSiC1LEA7vbteET5NbSo1yesjnv\",\"Metadata\":{\"Picture\":1,\"Name\":\"Card\",\"Description\":\"Description\"}},{\"MintAdress\":\"6CAULXj7jf1pbqr9L99KBvMSXeFAzcFsvocVxXBg4xab\",\"Metadata\":{\"Picture\":1,\"Name\":\"Card\",\"Description\":\"Description\"}},{\"MintAdress\":\"9dBXbL6hzef8uKGsomLGbb7qZQYKQSMJNRvVCynR9kTe\",\"Metadata\":{\"Picture\":1,\"Name\":\"Card\",\"Description\":\"Description\"}}]}";
            //var collection = JsonUtility.FromJson<Collection>(tstJson);
            //Debug.Log(collection.Cards[0].Metadata.Name);
            //CardCollection.Instance?.UpdateCollection(collection);
            //Debug.Log(CardCollection.Instance?.Collection.Value.Cards[0].Metadata.Name);
            //UnityToReact.Instance?.CallOnUnityLoaded();
            GameSM.Instance?.PerformInitialTransition().Forget();
        }

        public void DeInit()
        {
            UnityEngine.Debug.Log("Game DeInit");

            Wallet.Instance?.DeInit();
            CardCollection.Instance?.DeInit();
            FightModule.Instance?.DeInit();
        }
    }
}
