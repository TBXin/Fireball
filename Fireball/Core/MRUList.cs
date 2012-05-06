using System;
using System.Collections.Generic;
using System.Linq;

namespace Fireball.Core
{
    class MRUList
    {
        private const byte maxInQueue = 20;
        private Queue<String> container;

        public List<String> Items
        {
            get { return container.ToList(); }
        }

        public MRUList()
        {
            container = new Queue<string>();
        }

        public MRUList(IEnumerable<string> content)
        {
            container = new Queue<string>(content);

            while (container.Count >= maxInQueue)
                container.Dequeue();
        }

        public void Enqueue(string content)
        {
            if (container.Count == maxInQueue)
            {
                container.Dequeue();
            }

            container.Enqueue(content);
        }
    }
}
