# Brainy
#### A simple AI framework

Brainy is an idea of easing the way you build AI systems by introducing concepts like Brain, Sensors, Skills, Presenters.

#### Usage

###### Build your Order
``` csharp
public class TextOrder : IBrainOrder
{
    public string Order { get; private set; }

    public List<string> Parameters { get; private set; }

    public Dictionary<string, object> Options { get; private set; }

    public TextOrder(string order, 
                     List<string> parameters, 
                     Dictionary<string, object> options)
    {
        Order = order;
        Parameters = parameters;
        Options = options;
    }
}
```

###### Build your Sensor
``` csharp
public class ConsoleSensor : IBrainSensor
{
    public IBrainOrder Sense()
    {
        Console.Write("You: ");
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
```

###### Build your Result
``` csharp
public class TextResult : IBrainResult
{
    private string _text;

    public TextResult(string text)
    {
        this._text = text;
    }

    public override string ToString()
    {
        return _text;
    }
}
```

###### Build your Result
``` csharp
public class TextResult : IBrainResult
{
    private string _text;

    public TextResult(string text)
    {
        this._text = text;
    }

    public override string ToString()
    {
        return _text;
    }
}
```

###### Build your Skill
``` csharp
public class GreetingSkill : IBrainSkill
{
    public void AssignOrders(Action<string> assign)
    {
        assign("hi");
    }

    public HelpResult HelpMe()
    {
        var orders = new OrdersCollection()
            .Add("hi", "Brainy 'hi's you back");
        return new HelpResult(orders);
    }

    public IBrainResult Process(IBrainOrder order)
    {
        return new TextResult($"Brainy: {order.Order}, I'm Brainy");
    }
}
```

###### Build your Presenter
``` csharp
public class ConsolePresenter : IBrainPresenter
{
    public void Present(IBrainResult result)
    {
        Console.WriteLine(result.ToString());
    }
}
```

###### Build your Brain
``` csharp
var brainBuilder = BrainBuilder.CreateBrain()
                               .AddSensor<ConsoleSensor>()
                               .AddPresenter<ConsolePresenter>()
                               .AddSkill<GreetingSkill>();
var brain = brainBuilder.Build();
```

###### Run your Brain
``` csharp
brain.Run();
```

###### Interact with your Brain
``` shell
 | Skill          | Description                       |
 |----------------------------------------------------|
 | helpme         | prints this info!                 |
 | helpme skills  | prints help for all known skills. |
 | helpme <skill> | prints help for a specific skill. |

> hi
Brainy: hi, I'm Brainy
```