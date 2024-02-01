using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Accumulators;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class PersonalComputer
{
    private Accumulator _accumulator;
    private Bios _bios;
    private ComputerCase _computerCase;
    private CoolingSystem _coolingSystem;
    private Motherboard _motherboard;
    private PowerSupply _powerSupply;
    private Processor _processor;
    private Ram _ram;
    private VideoCard? _videoCard;
    private WifiAdapter? _wifiAdapter;
    private XmpProfile? _xmpProfile;
    public PersonalComputer(
        Accumulator accumulator,
        Bios bios,
        ComputerCase @case,
        CoolingSystem coolingSystem,
        Motherboard motherboard,
        PowerSupply powerSupply,
        Processor processor,
        Ram ram)
    {
        _accumulator = accumulator;
        _bios = bios;
        _computerCase = @case;
        _coolingSystem = coolingSystem;
        _motherboard = motherboard;
        _powerSupply = powerSupply;
        _processor = processor;
        _ram = ram;
    }

    public Accumulator Accumulator
    {
        get => _accumulator;
        set
        {
            Accumulator tmp = _accumulator;
            _accumulator = value;
            if (!IsCompatible())
            {
                _accumulator = tmp;
            }
        }
    }

    public Bios Bios
    {
        get => _bios;
        set
        {
            Bios tmp = _bios;
            _bios = value;
            if (!IsCompatible())
            {
                _bios = tmp;
            }
        }
    }

    public ComputerCase Case
    {
        get => _computerCase;
        set
        {
            ComputerCase tmp = _computerCase;
            _computerCase = value;
            if (!IsCompatible())
            {
                _computerCase = tmp;
            }
        }
    }

    public CoolingSystem CoolingSystem
    {
        get => _coolingSystem;
        set
        {
            CoolingSystem tmp = _coolingSystem;
            _coolingSystem = value;
            if (!IsCompatible())
            {
                _coolingSystem = tmp;
            }
        }
    }

    public Motherboard Motherboard
    {
        get => _motherboard;
        set
        {
            Motherboard tmp = _motherboard;
            _motherboard = value;
            if (!IsCompatible())
            {
                _motherboard = tmp;
            }
        }
    }

    public PowerSupply PowerSupply
    {
        get => _powerSupply;
        set
        {
            PowerSupply tmp = _powerSupply;
            _powerSupply = value;
            if (!IsCompatible())
            {
                _powerSupply = tmp;
            }
        }
    }

    public Processor Processor
    {
        get => _processor;
        set
        {
            Processor tmp = _processor;
            _processor = value;
            if (!IsCompatible())
            {
                _processor = tmp;
            }
        }
    }

    public Ram Ram
    {
        get => _ram;
        set
        {
            Ram tmp = _ram;
            _ram = value;
            if (!IsCompatible())
            {
                _ram = tmp;
            }
        }
    }

    public VideoCard? VideoCard
    {
        get => _videoCard;
        set
        {
            VideoCard? tmp = _videoCard;
            _videoCard = value;
            if (_videoCard is null && _processor.IntegratedGraphics == false)
            {
                _videoCard = tmp;
            }
        }
    }

    public WifiAdapter? WifiAdapter
    {
        get => _wifiAdapter;
        set
        {
            WifiAdapter? tmp = _wifiAdapter;
            _wifiAdapter = value;
            if (!IsCompatible())
            {
                _wifiAdapter = tmp;
            }
        }
    }

    public XmpProfile? XmpProfile
    {
        get => _xmpProfile;
        set
        {
            XmpProfile? tmp = _xmpProfile;
            _xmpProfile = value;
            if (!IsCompatible())
            {
                _xmpProfile = tmp;
            }
        }
    }

    public bool IsCompatible()
    {
        double powerConsumption = 0;
        powerConsumption += Processor.PowerConsumption +
                            Ram.PowerConsumption +
                            (VideoCard?.PowerConsumptionWatts ?? 0) +
                            Accumulator.PowerConsumption +
                            (WifiAdapter?.PowerConsumptionWatts ?? 0);
        if (powerConsumption > PowerSupply.PeakLoad)
        {
            return false;
        }

        if (Processor.Socket != Motherboard.CpuSocket)
        {
            return false;
        }

        if (!CoolingSystem.SupportedSockets.Contains(Processor.Socket))
        {
            return false;
        }

        if (Motherboard.DdrStandard != Ram.DdrVersion)
        {
            return false;
        }

        if (VideoCard == null)
        {
            if (Processor.IntegratedGraphics == false)
            {
                return false;
            }
        }

        if (Processor.Tdp > CoolingSystem.MaxTdp)
        {
            return false;
        }

        if (!Case.SupportedMotherboardFormFactors.Contains(Motherboard.FormFactor))
        {
            return false;
        }

        return true;
    }
}