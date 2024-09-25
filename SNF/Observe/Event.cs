namespace SNF.Observe
{
    public class Event<T>(T id)
    {
        public T Id { get; set; } = id;

        // List of callbacks registered on this event
        private List<Action<T>> _callbacks { get; set; } = [];

        /// <summary>
        /// Add the given callback to this event
        /// </summary>
        /// <param name="callback"></param>
        public void AddListener(Action<T> callback)
        {
            if (!_callbacks.Contains(callback))
            {
                _callbacks.Add(callback);
            }
        }

        /// <summary>
        /// Remove the given callback from this event
        /// </summary>
        /// <param name="callback"></param>
        public void RemoveListener(Action<T> callback)
        {
            _callbacks.Remove(callback);
        }

        /// <summary>
        /// Remove all the callbacks registered for this event
        /// </summary>
        public void RemoveAllListener()
        {
            _callbacks.Clear();
        }

        public void Emit()
        {
            for (int i = 0; i < _callbacks.Count; i++)
            {
                _callbacks[i]?.Invoke(Id);
            }
        }
    }
}
