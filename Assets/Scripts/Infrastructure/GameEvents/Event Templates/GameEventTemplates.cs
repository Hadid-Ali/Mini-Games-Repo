using System;
using UnityEngine;

namespace Infrastructure.GameEvents
{
    public class GameEvent : IGameEvent
    {
        private event Action Event;

        public void Register(Action method)
        {
            if (method == null)
                return;

            Event += method;
        }

        public void UnRegister(Action method)
        {
            Event -= method;
        }

        public void Raise()
        {
            Event?.Invoke();
        }

        public void UnRegisterAll()
        {
            Event = null;
        }
    }

    public class GameEvent<T> : IGameEvent
    {
        private event Action<T> Event;

        public void Register(Action<T> method)
        {
            if (method == null)
                return;

            Event += method;
        }

        public void UnRegister(Action<T> method)
        {
            Event -= method;
        }

        public void Raise(T param)
        {
            if (Event != null)
                Event?.Invoke(param);
        }

        public void UnRegisterAll()
        {
            Event = null;
        }
    }

    public class GameEvent<T1, T2> : IGameEvent
    {
        private event Action<T1, T2> Event;

        public void Register(Action<T1, T2> method)
        {
            Event += method;
        }

        public void UnRegister(Action<T1, T2> method)
        {
            Event -= method;
        }

        public void Raise(T1 param, T2 paramB)
        {
            Event?.Invoke(param, paramB);
        }

        public void UnRegisterAll()
        {
            Event = null;
        }
    }

    public class GameEvent<T1, T2, T3> : IGameEvent
    {
        private event Action<T1, T2, T3> Event;

        public void Register(Action<T1, T2, T3> method)
        {
            Event += method;
        }

        public void UnRegister(Action<T1, T2, T3> method)
        {
            Event -= method;
        }

        public void Raise(T1 param, T2 paramB, T3 paramC)
        {
            Event?.Invoke(param, paramB, paramC);
        }

        public void UnRegisterAll()
        {
            Event = null;
        }
    }
}