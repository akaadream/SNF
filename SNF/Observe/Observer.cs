namespace SNF.Observe
{
    public class Observer(int id, Event<int> @event)
    {
        public int Id { get; set; } = id;
        public Event<int> Event { get; set; } = @event;


        private List<Observable> Callbacks { get; set; } = [];

        public void Observe(int id, Func<bool> callback)
        {
            Callbacks.Add(new(id, callback));
        }

        public void AddEvent(Action<int> callback)
        {
            Event.AddListener(callback);
        }

        public void Run()
        {
            for (int i = 0; i < Callbacks.Count; i++)
            {
                if (Callbacks[i].Condition())
                {
                    Emit(id);
                }
            }
        }

        public void Emit(int id)
        {
            Event.Emit(id);
        }
    }
}
