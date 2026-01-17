using System;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine;

public class SetComponetVariable : Unit
{
    [DoNotSerialize] // No need to serialize ports.
    public ControlInput inputTrigger; //Adding the ControlInput port variable

    [DoNotSerialize] // No need to serialize ports.
    public ControlOutput outputTrigger; //Adding the ControlOutput port variable.
    
    [DoNotSerialize] // No need to serialize ports
    public ValueInput Gameobject; // Adding the ValueInput variable for myValueA

    [DoNotSerialize] // No need to serialize ports
    public ValueInput Component; // Adding the ValueInput variable for myValueB
    
    [DoNotSerialize] // No need to serialize ports
    public ValueInput Variable; // Adding the ValueInput variable for myValueB
    
    [DoNotSerialize] // No need to serialize ports
    public ValueOutput result; // Adding the ValueOutput variable for result
    
    private string resultValue; // Adding the string variable for the processed result value

    protected override void Definition()
    {
        //The lambda to execute our node action when the inputTrigger port is triggered.
        inputTrigger = ControlInput("inputTrigger", (flow) =>
        { 
            //Making the resultValue equal to the input value from myValueA concatenating it with myValueB.
            //resultValue = flow.GetValue<string>(Component) + flow.GetValue<string>(myValueB) + "!!!";
            return outputTrigger;
        });
        
        //Making the ControlInput port visible, setting its key and running the anonymous action method to pass the flow to the outputTrigger port.
        inputTrigger = ControlInput("inputTrigger", (flow) => { return outputTrigger; });
        //Making the ControlOutput port visible and setting its key.
        outputTrigger = ControlOutput("outputTrigger");
        
        
        //Making the myValueA input value port visible, setting the port label name to myValueA and setting its default value to Hello.
        Gameobject = ValueInput<GameObject>("Gameobject", null);
        Component = ValueInput<Component>("Component", null);
        //Making the myValueB input value port visible, setting the port label name to myValueB and setting its default value to an empty string.
       Variable = ValueInput<String>("Variable", string.Empty);
       
        //Making the result output value port visible, setting the port label name to result and setting its default value to the resultValue variable.
        result = ValueOutput<string>("result", (flow) => { return resultValue; });
    }
}
