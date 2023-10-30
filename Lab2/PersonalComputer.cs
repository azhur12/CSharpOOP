using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Accumulators;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class PersonalComputer
{
    private Accumulator _accumulator;
    private BIOS _bios;
    private ComputerCase _computerCase;
    private CoolingSystem _coolingSystem;
    private Motherboard _motherboard;
    private PowerSupply _powerSupply;
    private Processor _processor;
    private RAM _ram;
    private VideoCard? _videoCard;
    private WifiAdapter? _wifiAdapter;
    private XMPProfile? _xmpProfile;
    public PersonalComputer(
        Accumulator accumulator,
        BIOS bios,
        ComputerCase @case,
        CoolingSystem coolingSystem,
        Motherboard motherboard,
        PowerSupply powerSupply,
        Processor processor,
        RAM ram)
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
            _accumulator = value;
            ComponentValidator.CheckingCompatibility(this);
        }
    }

    public BIOS Bios
    {
        get => _bios;
        set
        {
            _bios = value;
            ComponentValidator.CheckingCompatibility(this);
        }
    }

    public ComputerCase Case
    {
        get => _computerCase;
        set
        {
            _computerCase = value;
            ComponentValidator.CheckingCompatibility(this);
        }
    }

    public CoolingSystem CoolingSystem
    {
        get => _coolingSystem;
        set
        {
            _coolingSystem = value;
            ComponentValidator.CheckingCompatibility(this);
        }
    }

    public Motherboard Motherboard
    {
        get => _motherboard;
        set
        {
            _motherboard = value;
            ComponentValidator.CheckingCompatibility(this);
        }
    }

    public PowerSupply PowerSupply
    {
        get => _powerSupply;
        set
        {
            _powerSupply = value;
            ComponentValidator.CheckingCompatibility(this);
        }
    }

    public Processor Processor
    {
        get => _processor;
        set
        {
            _processor = value;
            ComponentValidator.CheckingCompatibility(this);
        }
    }

    public RAM Ram
    {
        get => _ram;
        set
        {
            _ram = value;
            ComponentValidator.CheckingCompatibility(this);
        }
    }

    public VideoCard? VideoCard
    {
        get => _videoCard;
        set
        {
            _videoCard = value;
            ComponentValidator.CheckingCompatibility(this);
        }
    }

    public WifiAdapter? WifiAdapter
    {
        get => _wifiAdapter;
        set
        {
            _wifiAdapter = value;
            ComponentValidator.CheckingCompatibility(this);
        }
    }

    public XMPProfile? XmpProfile
    {
        get => _xmpProfile;
        set
        {
            _xmpProfile = value;
            ComponentValidator.CheckingCompatibility(this);
        }
    }
}