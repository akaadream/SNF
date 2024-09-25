namespace SNF.Observe
{
    public class Observer(int id)
    {
        /// <summary>
        /// Unique ID of the observer
        /// </summary>
        public int Id { get; set; } = id;

        /// <summary>
        /// Event handlers
        /// </summary>
        private Dictionary<Type, List<Action<IEvent>>> eventHandlers = [];

        /// <summary>
        /// Make the observer listen a new event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler"></param>
        /// <returns>True if the event handler is correctly added</returns>
        public bool AddListener<T>(Action<T> handler) where T : IEvent
        {
            Type eventType = typeof(T);
            if (!eventHandlers.TryGetValue(eventType, out var existing))
            {
                eventHandlers.Add(eventType, []);
                eventHandlers[eventType].Add((e) => handler((T)e));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Remove an event handler from the observer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>True if the event handler is successfully removed</returns>
        public bool RemoveListener<T>()
        {
            return eventHandlers.Remove(typeof(T));
        }

        /// <summary>
        /// Make the observer emit events
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventData"></param>
        public void Emit<T>(T eventData) where T: IEvent
        {
            Type eventType = typeof(T);
            if (eventHandlers.TryGetValue(eventType, out var existing))
            {
                for (int i = 0; i < eventHandlers[eventType].Count; i++)
                {
                    eventHandlers[eventType][i](eventData);
                }
            }
        }
    }
}
