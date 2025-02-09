namespace GalAmrani;

/// Abstract base class for all commands.
public abstract class BaseCommand
{
    /// The university instance used by the command.
    public readonly University? _university;

    public BaseCommand() { }

    public BaseCommand(University university)
    {
        _university = university;
    }

    /// Executes the command.
    public abstract void Execute();
}

