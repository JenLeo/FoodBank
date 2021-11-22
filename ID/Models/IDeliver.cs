using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
   public interface IDeliver
    { 
    double CalculateFinalTotal(double orderTotal);
    }
    public class NoExtra : IDeliver
    {
        public double CalculateFinalTotal(double orderTotal)
        {
            return orderTotal;
        }
    }
    public class Extra1 : IDeliver
    {
        public double CalculateFinalTotal(double orderTotal)
        {
            return orderTotal + 1;
        }
    }
    public class Extra5 : IDeliver
    {
        public double CalculateFinalTotal(double orderTotal)
        {
            return orderTotal + 5;
        }
    }
    public class Extra10 : IDeliver
    {
        public double CalculateFinalTotal(double orderTotal)
        {
            return orderTotal + 10;
        }
    }
    public class Extra15 : IDeliver
    {
        public double CalculateFinalTotal(double orderTotal)
        {
            return orderTotal + 15;
        }
    }
    public class Extra25 : IDeliver
    {
        public double CalculateFinalTotal(double orderTotal)
        {
            return orderTotal + 25;
        }
    }
    public class Extra50 : IDeliver
    {
        public double CalculateFinalTotal(double orderTotal)
        {
            return orderTotal + 50;
        }
    }
}