using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Core.NetWork
{
    public class WebRequest:IDisposable
    {
        public static IEnumerator Post(string method, string body)
        {
            string result = null;
            var address = $"{NetworkConst.URL}/{method}";
            using (UnityWebRequest w = UnityWebRequest.PostWwwForm(address, body))
            {
                yield return w.SendWebRequest();
                if (w.result == UnityWebRequest.Result.Success)
                {
                    result = w.downloadHandler.text;
                }
            }

          //  return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
