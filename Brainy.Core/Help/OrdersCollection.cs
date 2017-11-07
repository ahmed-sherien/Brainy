using Brainy.Core.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Brainy.Core.Help
{
    public class OrdersCollection : IEnumerable<KeyValuePair<string, string>>
    {
        private Dictionary<string, string> _orders;

        public OrdersCollection()
        {
            _orders = new Dictionary<string, string>();
        }

        public OrdersCollection(Dictionary<string, string> orders)
        {
            _orders = new Dictionary<string, string>();
            orders.ToList().ForEach(o => _orders.Add(o.Key, o.Value));
        }

        public OrdersCollection Add(string order, string description)
        {
            _orders.Add(order, description);
            return this;
        }

        public bool Contains(string order)
        {
            return _orders.ContainsKey(order);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _orders.AsEnumerable().GetEnumerator();
        }

        public override string ToString()
        {
            return _orders.ToList().ToStringTable(new[] { "Skill", "Description" },
                s => s.Key,
                s => s.Value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _orders.GetEnumerator();
        }
    }
}