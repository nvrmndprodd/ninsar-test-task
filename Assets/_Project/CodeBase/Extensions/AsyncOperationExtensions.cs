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
        
        public static Task<T> AsTask<T>(this ResourceRequest resourceRequest) where T : Object
        {
            var tcs = new TaskCompletionSource<T>();
        
            resourceRequest.completed += _ =>
            {
                var result = resourceRequest.asset as T;

                if (result != null)
                {
                    tcs.TrySetResult(result);
                }
                else
                {
                    var error = $"Failed to load asset of type {typeof(T).Name}. " + 
                                $"Asset not found or have another type";
                    tcs.TrySetException(new System.InvalidCastException(error));
                }
            };

            return tcs.Task;
        }
    }
}