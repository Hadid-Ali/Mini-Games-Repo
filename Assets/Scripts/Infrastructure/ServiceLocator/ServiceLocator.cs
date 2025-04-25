    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public static class ServiceLocator
    {
        private static Dictionary<Type, IGameService> _services = new();

        public static void ClearAll()
        {
            _services.Clear();
        }
        
        public static void RegisterService<T>(T service) where T : IGameService
        {
            var type = typeof(T);
            _services[type] = service;
        }

        public static T GetService<T>()
        {
            var type = typeof(T);

            try
            {
                return (T)_services[type];
            }
            catch (Exception e)
            {
                Debug.LogError(e.StackTrace);
                return default;
            }
        }
    }