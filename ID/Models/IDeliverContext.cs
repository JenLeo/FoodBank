using ID.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iD.Models
{
    public interface IDeliverContext
    {
        void SetStrategy(IDeliver strategy);

        double ExecuteStrategy(double orderTotal);
    }
    public class DeliverContext : IDeliverContext
    {
        private IDeliver _strategy;

        public DeliverContext()
        { }

        public DeliverContext(IDeliver strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IDeliver strategy)
        {
            this._strategy = strategy;
        }

        public double ExecuteStrategy(double orderTotal)
        {
            return this._strategy.CalculateFinalTotal(orderTotal);
        }
    }
}
