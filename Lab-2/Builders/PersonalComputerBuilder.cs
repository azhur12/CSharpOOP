using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Accumulators;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class PersonalComputerBuilder
{
    private Accumulator? _accumulator;
    private Bios? _bios;
    private ComputerCase? _computerCase;
    private CoolingSystem? _coolingSystem;
    private Motherboard? _motherboard;
    private PowerSupply? _powerSupply;
    private Processor? _processor;
    private Ram? _ram;
    private VideoCard? _videoCard;
    private WifiAdapter? _wifiAdapter;
    private XmpProfile? _xmpProfile;

    public PersonalComputerBuilder()
    { }

    public PersonalComputerBuilder(PersonalComputer prototype)
    {
        if (prototype is null) throw new MyNullException("Computer is Null");
        _accumulator = prototype.Accumulator;
        _bios = prototype.Bios;
        _computerCase = prototype.Case;
        _coolingSystem = prototype.CoolingSystem;
        _motherboard = prototype.Motherboard;
        _powerSupply = prototype.PowerSupply;
        _processor = prototype.Processor;
        _ram = prototype.Ram;
        _videoCard = prototype.VideoCard;
        _wifiAdapter = prototype.WifiAdapter;
        _xmpProfile = prototype.XmpProfile;
    }

    public PersonalComputerBuilder WithAccumulator(Accumulator accumulator)
    {
        this._accumulator = accumulator;
        return this;
    }

    public PersonalComputerBuilder WithBios(Bios bios)
    {
        this._bios = bios;
        return this;
    }

    public PersonalComputerBuilder WithComputerCase(ComputerCase computerCase)
    {
        this._computerCase = computerCase;
        return this;
    }

    public PersonalComputerBuilder WithCoolingSystem(CoolingSystem coolingSystem)
    {
        this._coolingSystem = coolingSystem;
        return this;
    }

    public PersonalComputerBuilder WithMotherboard(Motherboard motherboard)
    {
        this._motherboard = motherboard;
        return this;
    }

    public PersonalComputerBuilder WithPowerSupply(PowerSupply powerSupply)
    {
        this._powerSupply = powerSupply;
        return this;
    }

    public PersonalComputerBuilder WithProcessor(Processor processor)
    {
        this._processor = processor;
        return this;
    }

    public PersonalComputerBuilder WithRam(Ram ram)
    {
        this._ram = ram;
        return this;
    }

    public PersonalComputerBuilder WithVideoCard(VideoCard videoCard)
    {
        this._videoCard = videoCard;
        return this;
    }

    public PersonalComputerBuilder WithWifiAdapter(WifiAdapter wifiAdapter)
    {
        this._wifiAdapter = wifiAdapter;
        return this;
    }

    public PersonalComputerBuilder WithXmpProfile(XmpProfile xmpProfile)
    {
        this._xmpProfile = xmpProfile;
        return this;
    }

    public PersonalComputer Build()
    {
        if (_accumulator == null ||
            _bios == null ||
            _computerCase == null ||
            _coolingSystem == null ||
            _motherboard == null ||
            _powerSupply == null ||
            _processor == null ||
            _ram == null)
        {
            throw new InvalidOperationException("Not all required components are provided.");
        }

        var computer = new PersonalComputer(
            _accumulator,
            _bios,
            _computerCase,
            _coolingSystem,
            _motherboard,
            _powerSupply,
            _processor,
            _ram)
        {
            VideoCard = this._videoCard,
            WifiAdapter = this._wifiAdapter,
            XmpProfile = this._xmpProfile,
        };

        ComponentValidator.CheckingCompatibility(computer);
        return computer;
    }
}
