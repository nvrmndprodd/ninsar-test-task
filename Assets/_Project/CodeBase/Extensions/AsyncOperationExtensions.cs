using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Extensions
{
    public static class AsyncOperationExtensions
    {
        public static Task AsTask(this AsyncOperation asyncOperation)
        {
            var tcs = new TaskCompletionSource<object>();
            asyncOperation.completed += _ => tcs.TrySetResult(null);
            return tcs.Task;
        }
    }
}