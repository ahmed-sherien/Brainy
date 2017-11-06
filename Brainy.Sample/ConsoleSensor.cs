using Brainy.Core;
using System;
using System.Linq;

namespace Brainy.Sample
{
    public class ConsoleSensor : IBrainSensor
    {
        public IBrainOrder Sense()
        {
            var text = Console.ReadLine();
            var splitOptions = text.Split('-');
            var splitParamters = splitOptions[0].Split(' ');
            var options = splitOptions.Skip(1)
                                      .Select(o => o.Split(' '))
                                      .ToDictionary(o => o[0], o => o[1] as object);
            var parameters = splitParamters.Skip(1).ToList();
            var order = splitParamters[0];
            return new TextOrder(order, parameters, options);
        }
    }
}