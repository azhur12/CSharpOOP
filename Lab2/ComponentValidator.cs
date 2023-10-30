using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public static class ComponentValidator
{
    public static void ValidateObject(object component)
    {
        var context = new ValidationContext(component);
        var results = new List<ValidationResult>();
        if (!Validator.TryValidateObject(component, context, results, true))
        {
            var exceptionText = new StringBuilder();
            exceptionText.Append("\nFailed to create an object " + component?.GetType().Name + "\n");
            foreach (ValidationResult error in results)
            {
                exceptionText.Append(error.ErrorMessage + '\n');
            }

            throw new ComponentException(exceptionText.ToString());
        }
    }

    public static bool CheckingCompatibility(PersonalComputer computer)
    {
        if (computer is null) throw new MyNullException("computer is null");
        double powerConsumption = 0;
        bool disclaimerOfObligations = false;
        powerConsumption += computer.Processor.PowerConsumption +
                            computer.Ram.PowerConsumption +
                            (computer.VideoCard?.PowerConsumptionWatts ?? 0) +
                            computer.Accumulator.PowerConsumption +
                            (computer.WifiAdapter?.PowerConsumptionWatts ?? 0);
        if (powerConsumption > computer.PowerSupply.PeakLoad)
        {
            disclaimerOfObligations = true;
        }

        if (computer.Processor.Socket != computer.Motherboard.CpuSocket)
        {
            throw new ComponentException("CPU Socket doesn't match MotherBoard Socket");
        }

        if (!computer.CoolingSystem.SupportedSockets.Contains(computer.Processor.Socket))
        {
            throw new ComponentException("CPU Socket doesn't match cooling system");
        }

        if (computer.Motherboard.DdrStandard != computer.Ram.DDRVersion)
        {
            throw new ComponentException("DDR version doesn't match");
        }

        if (computer.VideoCard == null)
        {
            if (computer.Processor.IntegratedGraphics == false)
            {
                throw new ComponentException("No graphic processor");
            }
        }

        if (computer.Processor.TDP > computer.CoolingSystem.MaxTDP)
        {
            disclaimerOfObligations = true;
        }

        if (!computer.Case.SupportedMotherboardFormFactors.Contains(computer.Motherboard.FormFactor))
        {
            throw new ComponentException("Form factor doesn't match");
        }

        return disclaimerOfObligations;
    }
}